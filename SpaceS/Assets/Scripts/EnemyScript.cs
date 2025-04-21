using System;
using UnityEngine;

 class EnemyScript : MonoBehaviour //skrypt do obs³ugi przeciwnika
{
    [SerializeField] public AiScriptable dane;
    [SerializeField] public EnemySpawner _enemySpawner;
    [SerializeField] public UIManager _uiManager;
    [SerializeField] int health;
    [SerializeField] MoneyController _moneyManager;
    [SerializeField] private int _moneyFromEnemy;
    [SerializeField] private AudioSource _deadAudio;
    [SerializeField] private AudioSource _getHit;
    void Awake()
    {
        health = dane.health;
        _moneyFromEnemy = dane.iloscMonet;
    }
    public void minusHP(int obrazenia) //funkcja do dostawania obra¿eñ
    {
        if (health > 0)
        {
            health -= obrazenia;
            _getHit.Play();
        }
        if (health <= 0) //je¿eli stan zdrowia jest poni¿ej lub zero
        {
            _deadAudio.Play();  
            _moneyManager.AddMoney(_moneyFromEnemy); //to dodaj kaske za niego
            _enemySpawner.MinusOneEnemy(); //
            _uiManager.ShowMoney();
            Destroy(gameObject); //zniszcz przeciwnika
        }
    }
}
