using UnityEngine;
public abstract class PaintView : MonoBehaviour, IParentable
{
    protected PaintCell _paint;
    public void Initialize(PaintCell paint)
    {
        _paint = paint;
    }
    public abstract void UpdatePaintView();
    public virtual void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}