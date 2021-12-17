using System.Collections.Generic;
using UnityEngine;
public class PaletteMenu : Menu
{
    [SerializeField]
    private Mediator _mediator;
    [SerializeField]
    private PaintCellProvider _paintPanelProvider;
    private List<PaintCell> _paints;
    private List<PalettePaintView> _paintPanels;
    private void Awake()
    {
        _mediator.Subscribe<PaintCellSendCommand>(RecivePaintCells);
    }
    private void Start()
    {
        _paintPanelProvider.SetPaints(_paints);
        _paintPanels = _paintPanelProvider.Provide(_menuPanel.transform);
    }
    private new void OnEnable()
    {
        base.OnEnable();
        Shown += UpdatePaintPanels;
    }
    private new void OnDisable()
    {
        base.OnDisable();
        Shown -= UpdatePaintPanels;
    }
    private void RecivePaintCells(PaintCellSendCommand callback)
    {
        _paints = callback.PaintCells;
    }
    private void UpdatePaintPanels()
    {
        foreach (PalettePaintView palettePaintView in _paintPanels)
            palettePaintView.UpdatePaintView();
    }
}