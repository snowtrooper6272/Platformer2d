using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public void GetMoney(int accruedMoney) 
    {
        _money += accruedMoney;
    }
}
