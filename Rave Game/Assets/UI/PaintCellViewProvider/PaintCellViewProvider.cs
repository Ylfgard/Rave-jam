using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PaintCellViewProvider
{
    [SerializeField]
    private PaintCellView _paintCellViewPrefab;
    [SerializeField]
    private int _paintCellViewsCount;
    public List<PaintCellView> Provide(Transform parent = null)
    {
        List<PaintCellView> paintCellViews = new List<PaintCellView>();
        for (int i = 0; i < _paintCellViewsCount; i++)
        {
            paintCellViews.Add(Object.Instantiate(_paintCellViewPrefab));
            paintCellViews[i].SetParent(parent);
        }
        return paintCellViews;
    }
}
