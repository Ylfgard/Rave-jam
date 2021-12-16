using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyPanel : MonoBehaviour
{
    [SerializeField]
    private Button _nextStoreItemButton;
    [SerializeField]
    private Button _previousItemButton;
    [SerializeField]
    private NumberView _itemIndexView;
    [SerializeField]
    private List<StoreItem> _storeItems;
    private StoreItem _currentItem;
    private int _count;
    private void OnEnable()
    {
        _nextStoreItemButton.onClick.AddListener(MoveToNextItem);
        _previousItemButton.onClick.AddListener(MoveToPreviousItem);
        
    }
    private void OnDisable()
    {
        _nextStoreItemButton.onClick.RemoveListener(MoveToNextItem);
        _previousItemButton.onClick.RemoveListener(MoveToPreviousItem);
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
}