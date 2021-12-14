using System.Collections.Generic;
using UnityEngine;
public class PaletteMenu : Menu
{
    private List<PalettePaintCellView> _paintPanels;
    [SerializeField]
    private PaintCellViewProvider _paintCellViewProvider;
    [SerializeField]
    private Mediator _mediator;
    private void Awake()
    {
        _mediator.Subscribe<PaintCellChangedCommand>(UpdatePaintPanels);
    }
    private void Start()
    {
        _paintPanels = _paintCellViewProvider.Provide(_menuPanel.transform);
    }
    private void UpdatePaintPanels(PaintCellChangedCommand callback)
    {
        int index = 0;
        foreach (PalettePaintCellView paintPanels in _paintPanels)
        {
            paintPanels.SetPaintCell(callback.PaintCells[index]);
            index++;
        }
            
    }

}
