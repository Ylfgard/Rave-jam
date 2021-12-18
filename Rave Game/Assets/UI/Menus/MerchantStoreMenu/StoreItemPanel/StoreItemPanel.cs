using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class StoreItemPanel : ItemSwitcher
{
    public void BuyCurrentItem(List<MerchantPaintCellPanel> _paintPanels)
    {
        int totalMoney = 0;
        foreach (MerchantPaintCellPanel paintCellView in _paintPanels)
            totalMoney += paintCellView.GetCount();
        if (_currentItem.Buy(totalMoney))
            foreach (MerchantPaintCellPanel paintCellView in _paintPanels)
                paintCellView.UsePaintCell(_currentItem.GetPrice());
    }
    private void UsePaintCells(int totalMoney)
    {
        while (totalMoney > 0)
        {
            totalMoney--;
        }

    }
}