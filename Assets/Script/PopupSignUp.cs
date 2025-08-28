using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupSignUp : MonoBehaviour
{
    public GameObject SignUpForm;
    public InputField signupId;
    public InputField signupName;
    public InputField signupPw;
    public InputField confirmPw;
    public Text warningText;

    public void UserSingUp()
    {
        string enteredId = signupId.text;
        string enteredName = signupName.text;
        string enteredPw = signupPw.text;
        string enteredConfirmPw = confirmPw.text;

        // ✅ 1. 빈칸 체크
        if (string.IsNullOrEmpty(enteredId))
        {
            warningText.text = "아이디를 입력하세요.";
            return;
        }
        if (string.IsNullOrEmpty(enteredName))
        {
            warningText.text = "이름을 입력하세요.";
            return;
        }
        if (string.IsNullOrEmpty(enteredPw))
        {
            warningText.text = "비밀번호를 입력하세요.";
            return;
        }
        if (string.IsNullOrEmpty(enteredConfirmPw))
        {
            warningText.text = "비밀번호 확인을 입력하세요.";
            return;
        }

        // ✅ 2. 비밀번호 일치 체크
        if (enteredPw != enteredConfirmPw)
        {
            warningText.text = "비밀번호와 비밀번호 확인이 일치하지 않습니다.";
            return;
        }

        // ✅ 3. 아이디 중복 체크
        bool idExists = GameManager.Instance.dataList.Exists(u => u.Id == enteredId);
        if (idExists)
        {
            warningText.text = "이미 존재하는 아이디입니다.";
            return;
        }

        UserData user = new UserData(enteredId, enteredPw, enteredName);
    
        GameManager.Instance.LoadUserData();
        GameManager.Instance.dataList.Add(user);
        GameManager.Instance.SaveUserData();
        warningText.text = "회원가입 성공! 로그인 해주세요.";
        SignUpForm.SetActive(false);
           
    }
      public void ExitAlert()
    {
        SignUpForm.SetActive(false);
    }
}
