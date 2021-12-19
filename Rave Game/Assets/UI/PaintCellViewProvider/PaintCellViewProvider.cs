using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PaintCellProvider<T> where T : PaintView
{
    [SerializeField]
    private T _paintViewPrefab;
    private List<PaintCell> _paints;
    public List<T> Provide(Transform parent = null)
    {
        List<T> paintViews = new List<T>();
        Debug.Log(_paints.Count);
        for (int i = 0; i < _paints.Count; i++)
        {
            
            paintViews.Add(Object.Instantiate(_paintViewPrefab));
            paintViews[i].Initialize(_paints[i]);
            paintViews[i].SetParent(parent);
        }
        return paintViews;
    }
    public void SetPaints(List<PaintCell> paints)
    {
        _paints = paints;
        Debug.Log("i got paints");
    }
}