using System.Collections.Generic;
using UnityEngine;
public class PaletteMenu : Menu
{
    [SerializeField]
    private List<PaintCellView> _paintPanels;
    [SerializeField]
    private PaintCellViewProvider _paintCellViewProvider;
    private void Start()
    {
        _paintPanels = _paintCellViewProvider.Provide(_menuPanel.transform);
    }
}
