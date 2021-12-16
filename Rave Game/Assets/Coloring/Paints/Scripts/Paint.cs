using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Paint", menuName = "Coloring/Paint", order = 4)]
public class Paint : StoreItem
{
    [SerializeField] private int _value;
    [SerializeField] private string _name;
    [SerializeField] private Color _color;
    public string Name => _name;
    public Color Color => _color;
    public int Count => _count;
    public bool AddCount(int count)
    {
        if (_count + count >= 0)
        {
            _count += count;

            return true;
        }
        else
        {
            return false;
        }
    }
    public void RemoveCount(int count)
    {
        if (count > 0 && _count >= count)
            _count -= count;
        else
            throw new InvalidOperationException();
    }
}
public class PaintNameComparer : IComparer<Paint>
{
    public int Compare(Paint a, Paint b)
    {
        return a.Name.CompareTo(b.Name);
    }
}