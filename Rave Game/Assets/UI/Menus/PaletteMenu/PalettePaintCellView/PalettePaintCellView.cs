using UnityEngine;
public class PalettePaintCellView : PaintCellView
{
    [SerializeField]
    private ColorView _paintColorView;
    [SerializeField]
    private StringView _paintNameView;
    [SerializeField]
    private NumberView _paintCountView;
    public override void SetPaintCell(PaintCell PaintCell)
    {
        _paintNameView.SetString(PaintCell.Paint.name);
        _paintCountView.SetNumber(PaintCell.Count);
        _paintColorView.SetColor(PaintCell.Paint.Color);
    }
}