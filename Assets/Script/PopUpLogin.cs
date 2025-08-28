using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpLogin : MonoBehaviour
{
    public InputField inputId;
    public InputField inputPw;
    public GameObject LoginForm;
    public GameObject SignUpForm;
    public GameObject Determine;
    public GameObject UserInfo;
    public GameObject ATM;
    public Text warningText;

    public void LoginButton()
    {
        string enteredId = inputId.text;
        string enteredPw = inputPw.text;

        if (string.IsNullOrEmpty(enteredId))
        {
            warningText.text = "아이디를 입력하세요.";
            Determine.SetActive(true);
        }
        else if (string.IsNullOrEmpty(enteredPw))
        {
            warningText.text = "비밀번호를 입력하세요.";
            Determine.SetActive(true);
        }
        else
        {
            warningText.text = "회원정보가 일치하지 않습니다.";
            Determine.SetActive(true);
        }

        UserData user = GameManager.Instance.dataList.Find(u => u.Id == enteredId && u.Password == enteredPw);

        if (user != null) // 로그인 성공
        {
            LoginForm.SetActive(false);
            Determine.SetActive(false);
            UserInfo.SetActive(true);
            ATM.SetActive(true);
           
            GameManager.Instance.userData = user; // 현재 로그인 유저 등록
            GameManager.Instance.userInfo.Refresh();
        }
    }
    public void SingUpButton()
    {
        SignUpForm.SetActive(true);
    }
    public void ExitAlert()
    {
        Determine.SetActive(false);
    }
}
