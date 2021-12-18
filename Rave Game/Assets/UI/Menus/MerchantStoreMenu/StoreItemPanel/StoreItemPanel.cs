using System;
using UnityEngine;
[Serializable]
public class StoreItemPanel : ItemSwitcher
{
    [SerializeField]
    private float _priceMultiplierIfItemIsNotAvailable;
    public int GetCurrentItemPrice()
    {
        if (_currentItem.Available)
            return _currentItem.Price;
        else
            return Convert.ToInt32(_currentItem.Price * _priceMultiplierIfItemIsNotAvailable);
    }
    public bool CanBuyCurrentItem(int money)
    {
        return _currentItem.HasEnoughMoneyToBuy(money);
    }
    public void BuyItem(int money)
    {
        if (_currentItem.Available)
        {
            _currentItem.Buy(money);
        }
        else
        {
            _currentItem.Buy(money, _priceMultiplierIfItemIsNotAvailable);
        }
    }
}