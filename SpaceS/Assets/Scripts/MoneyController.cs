using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public int money;


    public void AddMoney(int howManyAdd)
    {
        money += howManyAdd;
    }
    public void DissMoney(int howManyDiss)
    {
        money -= howManyDiss;
    }
}
