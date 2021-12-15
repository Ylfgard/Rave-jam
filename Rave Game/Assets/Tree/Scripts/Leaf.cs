using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour, ICommand
{
    [SerializeField] private SpriteRenderer _leafSprite;
    private bool _colorized = false;
    private Paint _paint;

    public bool Colorized => _colorized;

    public Paint Paint => _paint;

    public void Colorize(Paint paint)
    {
        _paint = paint;
        _leafSprite.color = _paint.Color;
    }
}
