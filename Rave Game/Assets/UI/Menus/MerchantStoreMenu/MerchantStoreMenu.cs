using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MerchantStoreMenu : PaintMenu<MerchantPaintCellPanel>
{
    [SerializeField]
    private StoreItemPanel _storeItemBuyPanel;
    [SerializeField]
    private Button _buyCurrentItemButton;
    private new void Start()
    {
        base.Start();
        List<StoreItem> storeItems = new List<StoreItem>();
        for (int i = 0; i < _paints.Count; i++)
            storeItems.Add(_paints[i]);
        _storeItemBuyPanel.Initialize(storeItems);
    }
    private new void OnEnable()
    {
        base.OnEnable();
        _buyCurrentItemButton.onClick.AddListener(BuyCurrentItem);
        _storeItemBuyPanel.OnEnable();
    }
    private new void OnDisable()
    {
        base.OnDisable();
        _buyCurrentItemButton.onClick.RemoveListener(BuyCurrentItem);
        _storeItemBuyPanel.OnDisable();
    }
    private void BuyCurrentItem()
    {
        int totalMoney = 0;
        foreach (MerchantPaintCellPanel paintCellView in _paintPanels)
            totalMoney += paintCellView.GetCount();
        if (_storeItemBuyPanel.CanBuyCurrentItem(totalMoney))
        {
            _storeItemBuyPanel.BuyItem(totalMoney);
            foreach (MerchantPaintCellPanel paintCellView in _paintPanels)
                paintCellView.UsePaintCell(_storeItemBuyPanel.GetCurrentItemPrice());
        }
    }
}