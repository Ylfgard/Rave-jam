using UnityEngine;
public abstract class PaintCellView : MonoBehaviour, IParentable
{
    public abstract void SetPaintCell(PaintCell PaintCell);
    public virtual void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}