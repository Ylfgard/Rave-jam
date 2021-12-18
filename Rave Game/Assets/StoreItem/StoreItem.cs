using System;
using UnityEngine;
[Serializable]
public class StoreItem : IBuyable, ICountable
{
    [SerializeField]
    private int _price;
    [SerializeField]
    protected int _count;
    public int Count => _count;
    public void Buy(int money)
    {
        if (money >= _price)
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