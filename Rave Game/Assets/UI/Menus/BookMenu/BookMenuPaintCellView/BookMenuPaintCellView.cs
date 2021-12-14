using UnityEngine;
public class BookMenuPaintCellView : PaintCellView
{
    [SerializeField]
    private ColorView _paintColorView;
    [SerializeField]
    private StringView _paintNameView;
    public override void SetPaintCell(PaintCell PaintCell)
    {
        _paintColorView.SetColor(PaintCell.Paint.Color);
        _paintNameView.SetString(PaintCell.Paint.name);
    }
}