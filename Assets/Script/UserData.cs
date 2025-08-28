using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string Id;
    public string Password;
    public string name;
    public int Balance; // User가 가진 현금
    public int cash; // 통장 잔액

    public UserData(string targetid, string targetpassword, string targetname, int targetbalance=150000, int targetcash=50000)
    {
        this.Id = targetid;
        this.Password = targetpassword;
        this.name = targetname;
        this.Balance = targetbalance;
        this.cash = targetcash;
    }
}

[System.Serializable]
public class Serialization<T>
{
    public Serialization(List<T> _target) => target = _target;
    public List<T> target;
}