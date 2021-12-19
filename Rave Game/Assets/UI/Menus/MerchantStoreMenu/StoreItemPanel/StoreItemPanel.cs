using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class StoreItemPanel : StoreItemSwitcher
{
    public void BuyCurrentItem(List<MerchantPaintCellPanel> _paintPanels, ref int money)
    {
        if (_currentItem.HasEnoughMoneyToBuy(money))
        {
            _currentItem.Buy(money);
            money = 0;
            foreach (MerchantPaintCellPanel paintCellView in _paintPanels)
            {
                paintCellView.UsePaintCell();
            }
        }
    }
    public int GetCurrentItemPrice()
    {
        return _currentItem.GetPrice();
    }
}