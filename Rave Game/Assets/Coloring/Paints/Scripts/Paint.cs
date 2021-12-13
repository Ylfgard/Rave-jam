using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Paint", menuName = "Coloring/Paint", order = 4)]
public class Paint : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Color _color;
    [SerializeField] private int _price;

    public string Name => _name;

    public Color Color => _color;

    public int Price => _price; 
}

public class PaintNameComparer : IComparer<Paint>
{
    public int Compare(Paint a, Paint b)
    {
        return a.Name.CompareTo(b.Name);
    }
}
