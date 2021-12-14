using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Palette : MonoBehaviour
{
    [SerializeField] private List<PaintCell> _paintCells;
    [SerializeField] private Mediator _mediator; 
    [SerializeField] private PaintCellChangedCommand _paintCellChangedCommand = new PaintCellChangedCommand();
    public void UnblockPaint(string paintName)
    {
        foreach(PaintCell paintCell in _paintCells)
            if(paintCell.Paint.Name == paintName)
            {
                _paintCellChangedCommand.PaintCells.Add(paintCell);
                _mediator.Publish(_paintCellChangedCommand);
                paintCell.MakeAvailable();
            }
    }

    public bool ChangePaintCount(string paintName, int count)
    {
        int index = 0;
        foreach(PaintCell paintCell in _paintCells)
            if(paintCell.Available && paintCell.Paint.Name == paintName)
            {
                if(paintCell.ChangeCount(count))
                {
                    _paintCellChangedCommand.PaintCells[index] = paintCell;
                    _mediator.Publish(_paintCellChangedCommand);
                    index++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        return false;
    }
}
[Serializable]
public class PaintCell
{
    [SerializeField] private Paint _paint;
    [SerializeField] private bool _available;
    [SerializeField] private int _count;
    private PaintCellChangedCommand _paintCellChangedCommand = new PaintCellChangedCommand();
    public Paint Paint => _paint;    
    public bool Available => _available;
    public int Count => _count;
    public void MakeAvailable()
    {
        _available = true;
    }
    public bool ChangeCount(int count)
    {
        if(_count + count >= 0)
        {
            _count += count;

            return true;
        }
        else
        {
            return false;
        }
    }
}
