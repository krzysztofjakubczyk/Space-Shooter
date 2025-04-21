using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _maxHealth;
    [SerializeField] UIManager _uiManager;
    [SerializeField]EnemySpawner _enemySpawner;
    [SerializeField] private AudioSource _getShoot;
    int _round;
    public int getHealth()
    {
        return _health;
    }
    public int getMaxHealth() 
    { 
        return _maxHealth; 
    }

    private void Start()
    {
        _health = _maxHealth;
    }
   
    public void SetMaxHealth()
    {
        _round = _enemySpawner.GetNumberOfRound();
        if (_round % 5 == 0 && _round > 0)
        {
            Debug.Log("Dodano jedno zycie");
            _health += 1;
            _uiManager.ShowHeart(false);
        }
    }

    public void minusHP(int obrazenia)
    {
        if (_health > 0)
        {
            _uiManager.ShowHeart(true);
            _health -= obrazenia;
            _getShoot.Play();
        }
        if (_health == 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
        }
    }
}
