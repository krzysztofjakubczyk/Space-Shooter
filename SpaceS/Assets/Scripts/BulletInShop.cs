using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletInShop : MonoBehaviour
{
    [SerializeField] TMP_Text _priceText;
    [SerializeField] TMP_Text _damageText;
    [SerializeField] int _buttonId;
    [SerializeField] int _buttonPrice;
    [SerializeField] BulletInShop bulletInShop;
    [SerializeField] Bullet _bullet;
    [SerializeField] ShopManager shopManager;
    void Start()
    {
        bulletInShop = GetComponent<BulletInShop>();
        _priceText.SetText("Price: " + _bullet.getPrice().ToString());
        _damageText.SetText("Damage: " + _bullet.getDamage().ToString());
    }
    
    public int buttonPriceGet() { return _buttonPrice; }
    public int buttonIdGet() { return _buttonId; }
    public void onClickButton()
    {
        shopManager.bought(bulletInShop);
    }
}
