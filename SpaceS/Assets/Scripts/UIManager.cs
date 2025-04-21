using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public HealthController healthController;
    public MoneyController moneyController;
    [SerializeField] EnemySpawner _enemySpawner;
    [SerializeField] List<GameObject> heartsAdded;
    [SerializeField] Transform heartsParent;         // Transformacja okreœlaj¹ca rodzica dla kontenerów serc
    [SerializeField] GameObject heartContainerPrefab;
    [SerializeField] TMP_Text _moneyText;
    [SerializeField] int _iterator;// Prefabrykat kontenera serca 
    [SerializeField] TMP_Text _roundText;
    [SerializeField] TMP_Text _damageText;
    [SerializeField] int _round;
    [SerializeField] int _maxRound;
    [SerializeField] List<Sprite> images;
    [SerializeField] UnityEngine.UI.Image _image;
    [SerializeField] ShopManager _shopManager;
    void Start()
    {
        ShowRound();
        ShowMoney();
        showHearts(healthController.getMaxHealth());
    }
    void showHearts(int howMay) {
        for (int i = 0; i < howMay; i++)
        {
            GameObject heart = Instantiate(heartContainerPrefab, heartsParent);
            heartsAdded.Add(heart);
        }
        _iterator = heartsAdded.Count - 1;
    }
    public void ShowHeart(bool _addOrNot)
    {
        if (_addOrNot)
        {
            if (heartsAdded != null && _iterator < heartsAdded.Count && heartsAdded[_iterator] != null)
            {
                Transform childTransform = heartsAdded[_iterator].transform.GetChild(0);
                if (childTransform != null)
                {
                    GameObject heartObject = childTransform.gameObject;
                    if (heartObject != null)
                    {
                        heartObject.SetActive(false);
                    }
                }
            }
            _iterator--;
            if (_iterator < 0)
            {
                _iterator = heartsAdded.Count - 1;
            }
        }
        else
        {
            if (heartsAdded != null && _iterator < heartsAdded.Count && heartsAdded[_iterator] != null)
            {
                _iterator++;
                showHearts(1);
                Transform childTransform = heartsAdded[_iterator].transform.GetChild(0);
                if (childTransform != null)
                {
                    GameObject heartObject = childTransform.gameObject;
                    if (heartObject != null)
                    {
                        heartObject.SetActive(true);
                    }
                }
            }
        }
    }
    public void ShowMoney()
    {
        ShowRound();
        _moneyText.text = moneyController.money.ToString();
        ShowImage();
    }
    public void ShowRound()
    {
        _round = _enemySpawner.GetNumberOfRound() + 1; //bo w tablicy jest od 0
        _maxRound = _enemySpawner.GetRandomNumberForLengthGame();
        _roundText.text = "R: " + _round.ToString() + "/" + _maxRound.ToString();
    }
    private void ShowImage()
    {
        _image.sprite = images[_shopManager.GetBoughtId()];
        _damageText.text = _shopManager.getbulletInShop()[_shopManager.GetBoughtId()].getDamage().ToString();
    }
}
