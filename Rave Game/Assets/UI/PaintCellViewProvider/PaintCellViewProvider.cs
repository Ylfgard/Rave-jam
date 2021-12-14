using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PaintCellViewProvider
{
    [SerializeField]
    private PalettePaintCellView _paintCellViewPrefab;
    [SerializeField]
    private int _paintCellViewsCount;
    public List<PalettePaintCellView> Provide(Transform parent = null)
    {
        List<PalettePaintCellView> paintCellViews = new List<PalettePaintCellView>();
        for (int i = 0; i < _paintCellViewsCount; i++)
        {
            paintCellViews.Add(Object.Instantiate(_paintCellViewPrefab));
            paintCellViews[i].SetParent(parent);
        }
        return paintCellViews;
    }
}
