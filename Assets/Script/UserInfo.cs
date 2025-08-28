using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{

    public Text userNameText;
    public Text balanceText;
    public Text cashText;

    void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        var data = GameManager.Instance.userData; 

        userNameText.text = data.name;
        balanceText.text = string.Format("{0:#,##0}", data.Balance);
        cashText.text = string.Format("{0:#,##0}", data.cash);
    }
}

