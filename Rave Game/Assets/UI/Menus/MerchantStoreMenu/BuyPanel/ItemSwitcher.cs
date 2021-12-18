using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class ItemSwitcher
{
    [SerializeField]
    private Button _nextStoreItemButton;
    [SerializeField]
    private Button _previousItemButton;
    [SerializeField]
    private NumberView _itemIndexView;
    private List<StoreItem> _storeItems;
    private StoreItem _currentItem;
    private int _count;
    public void OnEnable()
    {
        _nextStoreItemButton.onClick.AddListener(MoveToNextItem);
        _previousItemButton.onClick.AddListener(MoveToPreviousItem);
    }
    public void OnDisable()
    {
        _nextStoreItemButton.onClick.RemoveListener(MoveToNextItem);
        _previousItemButton.onClick.RemoveListener(MoveToPreviousItem);
    }
    public void Initialize(List<StoreItem> storeItems)
    {
        _storeItems = storeItems;
        SetDefaultStoreItem();
    }
    private void MoveToNextItem()
    {
        if (_count + 1 >= _storeItems.Count)
        {
            _count = 0;
            _currentItem = _storeItems[_count];
        }
        else
        {
            _count++;
            _currentItem = _storeItems[_count];
        }
        _itemIndexView.SetNumber(_count);
    }
    private void MoveToPreviousItem()
    {
        if (_count - 1 < 0)
        {
            _count = _storeItems.Count - 1;
            _currentItem = _storeItems[_count];
        }
        else
        {
            _count--;
            _currentItem = _storeItems[_count];
        }
        _itemIndexView.SetNumber(_count);
    }
    private void SetDefaultStoreItem()
    {
        _currentItem = _storeItems[0];
    }
    public bool CanBuyCurrentItem(int money)
    {
        return _currentItem.HasEnoughMoneyToBuy(money);
    }
    public void BuyItem(int money)
    {
        _currentItem.Buy(money);
    }
}
