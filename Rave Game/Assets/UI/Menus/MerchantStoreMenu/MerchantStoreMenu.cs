using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MerchantStoreMenu : Menu
{
    [SerializeField]
    private List<MerchantPaintPanel> _buyPanels;
    [SerializeField]
    private Button _useCellsButton;
    private void OnEnable()
    {
        _useCellsButton.onClick.AddListener(UsePaintCells);
    }
    private void OnDisable()
    {
        _useCellsButton.onClick.RemoveListener(UsePaintCells);
    }
    public void UsePaintCells()
    {
        foreach (MerchantPaintPanel buyPanel in _buyPanels)
            buyPanel.UsePaintCell();
    }
}