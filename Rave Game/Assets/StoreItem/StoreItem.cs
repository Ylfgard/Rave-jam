using System;
using UnityEngine;
[Serializable]
public class StoreItem : IBuyable, ICountable
{
    [SerializeField]
    private int _price;
    public int Price => _price;
    [SerializeField]
    protected int _count;
    public int Count => _count;
    protected bool _available;
    public bool Available;
    public void Buy(int money, float priceMultiplier = 1)
    {
        int itemPrice = Convert.ToInt32(_price * priceMultiplier);
        if (money >= itemPrice)
            _count++;
        else
            throw new InvalidOperationException();
    }
    public void AddCount(int count)
    {
        if (count > 0)
            _count += count;
        else
            throw new InvalidOperationException();
    }
    public void RemoveCount(int count)
    {
        if (count > 0 && _count >= count)
            _count -= count;
        else
            throw new InvalidOperationException();
    }
    public bool HasEnoughMoneyToBuy(int money)
    {
        if (money >= _price)
            return true;
        else
            return false;
    }

}