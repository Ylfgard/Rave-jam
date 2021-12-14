using UnityEngine;
public class PaintCellView : MonoBehaviour, IParentable
{
    [SerializeField]
    private PaintColorView _paintColorView;
    [SerializeField]
    private PaintNameView _paintNameView;
    [SerializeField]
    private PaintCountView _paintCountView;
    [SerializeField]
    public void UpdatePaintPanel(PaintCell PaintCell)
    {
        _paintNameView.SetName(PaintCell.Paint.name);
        _paintCountView.SetCount(PaintCell.Count);
        _paintColorView.SetColor(PaintCell.Paint.Color);
    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}