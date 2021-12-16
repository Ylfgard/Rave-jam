using UnityEngine;
[RequireComponent(typeof(PaintCellCounter))]
public class MerchantPaintPanel : MonoBehaviour, IParentable
{
    private PaintCellCounter _paintCellCounter;
    [SerializeField]
    private PaintCell _paintCell;
    private void Awake()
    {
        _paintCellCounter = GetComponent<PaintCellCounter>();
    }
    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }
    public void UsePaintCell()
    {
        _paintCell.RemoveCount(_paintCellCounter.PaintCellCount);
        _paintCellCounter.ReseCount();
    }
}