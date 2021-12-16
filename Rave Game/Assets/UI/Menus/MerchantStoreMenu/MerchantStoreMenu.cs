using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MerchantStoreMenu : Menu
{
    [SerializeField]
    private List<MerchantPaintCellPanel> _buyPanels;
    [SerializeField]
    private Button _useCellsButton;
    private new void OnEnable()
    {
        base.OnEnable();
        _useCellsButton.onClick.AddListener(UsePaintCells);
    }
    private new void OnDisable()
    {
        base.OnDisable();
        _useCellsButton.onClick.RemoveListener(UsePaintCells);
    }
    private void UsePaintCells()
    {
        foreach (MerchantPaintCellPanel buyPanel in _buyPanels)
            buyPanel.UsePaintCell();
    }
}