using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMoney : MonoBehaviour
{
    MoneyController moneyController;
    public TMP_Text instance;
    private void Start()
    {
        
    }
    void Update()
    {

        instance.text = "Kaska: " + moneyController.money;
    }
}
