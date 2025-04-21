using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<AiScriptable> ScriptableObjects; // wszystkie SO do wyboru
    [SerializeField] ShopManager _shopManager;
    [SerializeField] UIManager _uiManager;
    [SerializeField] HealthController _healthController;
    [SerializeField] EnemyScript EnemyPrefabs; // Prefab 
    [SerializeField] List<Vector3> _positionsForSpawn;
    [SerializeField] List<int> _isThisInPosition;
    [SerializeField] List<int> maxEnemies; // maksymalna ilo�� wrog�w na tur�/rund�
    int _randomNumberForSO;
    Quaternion rotacja = Quaternion.Euler(0f, 0f, 0f);
    int nrOfRound = 0; // nr rundy - b�dzie zawsze inna, bo ilo�� wrog�w jest losowa
    int howManyDestroyed; // zliczanie ile wrog�w zosta�o zabitych
    int howToSpawn;
    int _randomNumberForLengthGame;
    int randomNumberForNumberOfEnemies;
    int randomNumberForList;
    int EnemiesOnScene;
    public static event Action StartRound;
    bool isGamePaused = false;
    [SerializeField] GameObject[] toSleepOnShop;

    private void Awake()
    {
        _randomNumberForLengthGame = UnityEngine.Random.Range(18, 20);
        randomNumberForNumberOfEnemies = UnityEngine.Random.Range(8, 12); // Zwi�kszenie zakresu ilo�ci przeciwnik�w
        for (int i = 0; i < _randomNumberForLengthGame; i++)
        {
            randomNumberForList = randomNumberForNumberOfEnemies + (UnityEngine.Random.Range(0, 2)); // Losujemy warto�� z wi�kszego zakresu
            maxEnemies.Add(randomNumberForList);
        }
        StartCoroutine(StartSpawning());
    }
public void MinusOneEnemy() // funkcja odpalana gdy gracz zabije przeciwnika
    {
        if (nrOfRound == maxEnemies.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
        else
        {
            howToSpawn = maxEnemies[nrOfRound] - howManyDestroyed; // ilo�� zespawowanych
            if (EnemiesOnScene >= 1 && maxEnemies[nrOfRound] > howManyDestroyed)
            {
                EnemiesOnScene--;
                howManyDestroyed++;
            }
            if (EnemiesOnScene == 0 && maxEnemies[nrOfRound] > howManyDestroyed)
            {
                StopAllCoroutines();
                StartCoroutine(StartSpawning());
            }
            if (maxEnemies[nrOfRound] == howManyDestroyed && nrOfRound < _randomNumberForLengthGame)
            {
                Debug.Log("Zatrzymano gr� i w��czono sklep");
                _shopManager.MakeShopVisible();
                PauseGame();
            }
        }
    }

    public void ExitButton()
    {
        _shopManager.MakeShopNotVisible();
        _healthController.SetMaxHealth();
        ResumeGame();
    }

    void ResumeGame()
    {
        Debug.Log("Wgrano kolejn� rund�"); // wypisz na ekranie
        for (int i = 0; i < toSleepOnShop.Length; i++)
        {
            toSleepOnShop[i].gameObject.SetActive(true);
        }
        Time.timeScale = 1f;
        nrOfRound++; // zmien runde na nast�pn�
        howManyDestroyed = 0;
        _uiManager.ShowRound();
        StartCoroutine(StartSpawning());
    }

    public int GetNumberOfRound()
    {
        return nrOfRound;
    }

    public int GetRandomNumberForLengthGame()
    {
        return _randomNumberForLengthGame;
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        for (int i = 0; i < toSleepOnShop.Length; i++)
        {
            toSleepOnShop[i].gameObject.SetActive(false);
        }
    }

    IEnumerator StartSpawning()
    {
        int randomNumberForMount = UnityEngine.Random.Range(1, howToSpawn); // ilo�� generowanych przeciwnik�w
        EnemiesOnScene = randomNumberForMount;
        for (int i = 0; i < randomNumberForMount; i++) // utworz tylu przeciwnik�w co mo�na 
        {
            int _randomNumberForPosition = 0;
            if (_positionsForSpawn.Count > 0)
            {
                for (int j = 0; j < _positionsForSpawn.Count; j++)
                {
                    _randomNumberForPosition = UnityEngine.Random.Range(1, _positionsForSpawn.Count);

                    if (!_isThisInPosition.Contains(_randomNumberForPosition))
                    {
                        _isThisInPosition.Add(_randomNumberForPosition);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            if (nrOfRound / 5 < 1)
            {
                _randomNumberForSO = UnityEngine.Random.Range(0, 2); // kt�ry z SO do wyboru
            }
            else if (nrOfRound / 5 == 1 && nrOfRound / 5 < 2)
            {
                _randomNumberForSO = UnityEngine.Random.Range(0, 3); // kt�ry z SO do wyboru
            }
            else if (nrOfRound / 5 == 2 && nrOfRound / 5 < 3)
            {
                _randomNumberForSO = UnityEngine.Random.Range(0, 4);
            }
            else if (nrOfRound / 5 >= 3)
            {
                _randomNumberForSO = UnityEngine.Random.Range(0, 5);
            }

            EnemyPrefabs.dane = ScriptableObjects[_randomNumberForSO]; // przypisz prefab
            Instantiate(EnemyPrefabs, _positionsForSpawn[_randomNumberForPosition], rotacja); // utworz przeciwnika  
            yield return new WaitForSeconds(2.0f);
        }
    }
}
