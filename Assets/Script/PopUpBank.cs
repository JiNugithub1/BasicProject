using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBank : MonoBehaviour
{
    public Button DepositBtn;
    public Button WithdrawBtn;
    public Button RemitButton;
    public GameObject DepositMenu;
    public GameObject WithdrawMenu;
    public GameObject remitmenu;
    public InputField depositInput;
    public InputField withdrawInput;
    public InputField remitPerson;
    public InputField remitCount;
    public GameObject LackCash;
    public GameObject incorrectValue;
    public GameObject alertForm;
    public Text warningText;

    void Start()
    {
        DepositBtn.onClick.AddListener(() => showMenu(DepositMenu));
        WithdrawBtn.onClick.AddListener(() => showMenu(WithdrawMenu));
        RemitButton.onClick.AddListener(() => showMenu(remitmenu));
    }
    void showMenu(GameObject menu)
    {
        menu.SetActive(true);
        DepositBtn.gameObject.SetActive(false);
        WithdrawBtn.gameObject.SetActive(false);
        RemitButton.gameObject.SetActive(false);
    }

    public void ExitMenu(GameObject menu)
    {
        menu.SetActive(false);
        DepositBtn.gameObject.SetActive(true);
        WithdrawBtn.gameObject.SetActive(true);
        RemitButton.gameObject.SetActive(true);
    }

    //입금
    public void DepositMoney(int Deposit)
    {
        if (GameManager.Instance.userData.cash >= Deposit)
        {
            GameManager.Instance.userData.Balance += Deposit;
            GameManager.Instance.userData.cash -= Deposit;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.userInfo.Refresh();
        }
        else
        {
            LackCash.SetActive(true);
        }
    }
    public void InputDeposit()
    {
        if (int.TryParse(depositInput.text, out int DepositInput) && DepositInput >= 0)
        {
            DepositMoney(DepositInput);
        }
        else
        {
            incorrectValue.SetActive(true);
        }

    }
    //출금
    public void WithdrawMoney(int Withdraw)
    {
        if (GameManager.Instance.userData.Balance >= Withdraw)
        {
            GameManager.Instance.userData.Balance -= Withdraw;
            GameManager.Instance.userData.cash += Withdraw;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.userInfo.Refresh();
        }
        else
        {
            LackCash.SetActive(true);
        }
    }
    public void InputWithdraw()
    {
        if (int.TryParse(withdrawInput.text, out int WithdrawInput) && WithdrawInput >= 0)
        {
            WithdrawMoney(WithdrawInput);
        }
        else
        {
            incorrectValue.SetActive(true);
        }
    }
    public void Remittance()
    {
        string sendPerson = remitPerson.text;
        int sendCount;
        // 입력 값이 숫자로 변환 가능한지 먼저 검사
        if (!int.TryParse(remitCount.text, out sendCount))
        {
            warningText.text = "송금 금액을 입력해주세요.";
            alertForm.SetActive(true);
            return; // 함수 종료
        }

        // 현재 로그인된 사용자 (보낸 사람)
        UserData currentUser = GameManager.Instance.userData;

        // 송금 받을 사람 찾기
        UserData sendUser = GameManager.Instance.dataList.Find(u => u.name == sendPerson);

        if (currentUser.cash >= sendCount)
        {
            currentUser.cash -= sendCount;
            sendUser.cash += sendCount;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.userInfo.Refresh();
        }
        else if (string.IsNullOrEmpty(sendPerson))
        {
            warningText.text = "송금 대상을 입력해주세요";
            alertForm.SetActive(true);
            return;
        }
        else if (sendUser == null)
        {
            warningText.text = "등록되지 않은 사용자입니다.";
            alertForm.SetActive(true);
        }
        else if (currentUser.cash < sendCount)
        {
            warningText.text = "잔액이 부족합니다.";
            alertForm.SetActive(true);
        }
        else
        {
            warningText.text = "입력 정보를 확인해주세요.";
            alertForm.SetActive(true);
        }
    }
    public void ExitAlert()
    {
        LackCash.SetActive(false);
        incorrectValue.SetActive(false);
        alertForm.SetActive(false);
    }
}
