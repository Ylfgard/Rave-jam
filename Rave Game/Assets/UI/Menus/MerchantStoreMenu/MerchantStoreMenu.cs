using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MerchantStoreMenu : PaintMenu<MerchantPaintCellPanel>
{
    [SerializeField]
    private ItemSwitcher _itemSwitcher;
    [SerializeField]
    private Button _useCellsButton;
    private BuyPanel _buyPanel;
    private new void Start()
    {
        base.Start();
        List<StoreItem> storeItems = new List<StoreItem>();
        for (int i = 0; i < _paints.Count; i++)
            storeItems.Add(_paints[i]);
        _itemSwitcher.Initialize(storeItems);
    }
    private new void OnEnable()
    {
        base.OnEnable();
        _useCellsButton.onClick.AddListener(BuyCurrentItem);
        _itemSwitcher.OnEnable();
    }
    private new void OnDisable()
    {
        base.OnDisable();
        _useCellsButton.onClick.RemoveListener(BuyCurrentItem);
        _itemSwitcher.OnDisable();
    }
    private void BuyCurrentItem()
    {
        int totalMoney = 0;
        foreach (MerchantPaintCellPanel paintCellView in _paintPanels)
            totalMoney += paintCellView.GetCount();
        if (_itemSwitcher.CanBuyCurrentItem(totalMoney))
        {
            _itemSwitcher.BuyItem(totalMoney);
            foreach (MerchantPaintCellPanel paintCellView in _paintPanels)
                paintCellView.UsePaintCell();
        }
    }
}