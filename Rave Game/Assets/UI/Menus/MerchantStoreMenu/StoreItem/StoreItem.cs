using System;
using UnityEngine;
[Serializable]
public class StoreItem : ScriptableObject, IBuyable
{
    [SerializeField]
    private int _price;
    [SerializeField]
    protected int _count;
    public void Buy(int money)
    {
        if (money >= _price)
            _count++;
        else
            throw new InvalidOperationException();
    }
}