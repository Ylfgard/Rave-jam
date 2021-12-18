using System;
using UnityEngine;
[Serializable]
public abstract class StoreItem : IBuyable, ICountable
{
    [SerializeField]
    protected int _price;
    [SerializeField]
    protected int _count;
    public int Count => _count;
    public abstract bool Buy(int money);
    public abstract int GetPrice();
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