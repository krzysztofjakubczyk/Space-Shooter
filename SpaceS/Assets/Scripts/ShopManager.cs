using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] MoneyController moneyController;
    [SerializeField] Bullet[] bulletInShop;
    [SerializeField] TMP_Text _stanKonta;
    [SerializeField] GameObject shopLook;
    [SerializeField] GameObject dontHaveEnoughMoney;
    [SerializeField] ShootManager shootingManager;
    [SerializeField] int bought_id = 0;
    [SerializeField] UIManager boughtManager;
    [SerializeField] EnemySpawner _enemySpawner;
    private bool _doPlayerBoughtAntyhing = false;
    void Start()
    {
        shootingManager.chooseAPrefab(bulletInShop[bought_id]);
    }

    public int GetBoughtId()
    {
        return bought_id;
    }
    public void MakeShopNotVisible()
    {
        shopLook.SetActive(false);
    }

    public void MakeShopVisible()
    {
        shopLook.SetActive(true);
        _stanKonta.SetText("Stan konta: " + moneyController.money);
    }
    // Update is called once per frame
    public void bought(BulletInShop bullet)
    {
        if (moneyController.money >= bullet.buttonPriceGet() && _doPlayerBoughtAntyhing == false)
        {
            bought_id = bullet.buttonIdGet();
            shootingManager.chooseAPrefab(bulletInShop[bought_id]);
            moneyController.DissMoney(bullet.buttonPriceGet());
            boughtManager.ShowMoney();
            _stanKonta.SetText("Stan konta: " + moneyController.money);
            _doPlayerBoughtAntyhing = true;
        }
        else
        {
            dontHaveEnoughMoney.gameObject.SetActive(true);
        }
        if (_doPlayerBoughtAntyhing == true)
        {
            _enemySpawner.ExitButton();
            _doPlayerBoughtAntyhing = false;
        }
    }
    public void dontHaveEnoughMoneyClose()
    {
        dontHaveEnoughMoney.gameObject.SetActive(false);
    }
    public Bullet[] getbulletInShop()
    {
        return bulletInShop;
    }
}
