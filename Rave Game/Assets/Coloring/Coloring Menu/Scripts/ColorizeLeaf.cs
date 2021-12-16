using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorizeLeaf : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private Palette _palette;
    [SerializeField] private Image _colorOutput;
    [SerializeField] private TextMeshProUGUI _countOutput;
    [SerializeField] private int _coloringPrice;
    private CloseColoringMenuCommand _closeCommand = new CloseColoringMenuCommand();
    private Leaf _leaf;
    private PaintCell _paintCell;

    private void Awake()
    {
        _mediator.Subscribe<Leaf>(GetSelectedLeaf);
        _mediator.Subscribe<SelectedPaintChangedCommand>(UpdateSelectedPaint);
    }

    private void GetSelectedLeaf(Leaf leaf)
    {
        _leaf = leaf;
    }

    private void UpdateSelectedPaint(SelectedPaintChangedCommand callback)
    {
        _paintCell = callback.PaintCell;
        _colorOutput.color = _paintCell.Paint.Color;
        _countOutput.text = _paintCell.Count.ToString();
    }

    private void UpdateSelectedPaint()
    {
        _countOutput.text = _paintCell.Count.ToString();
    }

    public void Colorize()
    {
        if (_leaf.Colorized == false && _palette.ChangePaintCount(_paintCell, -_coloringPrice))
        {
            _leaf.Colorize(_paintCell.Paint);
            UpdateSelectedPaint();
            _mediator.Publish(_closeCommand);
        }
        else
        {
            CantColorize();
        }
    }

    private void CantColorize()
    {
        Debug.Log("Cant Colorize");
    }
}