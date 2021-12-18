using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MerchantStoreMenu : PaintMenu<MerchantPaintCellPanel>
{
    [SerializeField]
    private StoreItemPanel _storeItemBuyPanel;
    [SerializeField]
    private Button _buyCurrentItemButton;
    [SerializeField]
    private int _combinationPrice;
    [SerializeField]
    private float _priceIfAnimalIsNotAvailable;
    private new void Start()
    {
        base.Start();
        List<StoreItem> storeItems = new List<StoreItem>();
        for (int i = 0; i < _paints.Count; i++)
        {
            _paints[i].Initialize(_combinationPrice, _priceIfAnimalIsNotAvailable);
            storeItems.Add(_paints[i]);
        }
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

    }
}