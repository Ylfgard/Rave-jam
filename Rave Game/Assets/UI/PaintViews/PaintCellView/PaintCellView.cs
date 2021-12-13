using UnityEngine;
public class PaintCellView : MonoBehaviour
{
    [SerializeField]
    private PaintColorView _paintColorView;
    [SerializeField]
    private PaintNameView _paintNameView;
    [SerializeField]
    private PaintCountView _paintCountView;
    public void UpdatePaintPanel(PaintCell paintCell)
    {
        _paintNameView.SetName(paintCell.Paint.name);
        _paintCountView.SetCount(paintCell.Count);
        _paintColorView.SetColor(paintCell.Paint.Color);
    }
}