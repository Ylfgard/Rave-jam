using System.Collections.Generic;
using UnityEngine;
using System;

public class Palette : MonoBehaviour
{
    [SerializeField] private List<PaintCell> _paintCells;
    [SerializeField] private int _desaturationCount;
    [SerializeField] private Mediator _mediator;
    private PaintCellChangedCommand _paintCellChangedCommand = new PaintCellChangedCommand();
    private PaintCellSendCommand _paintCellSendCommand = new PaintCellSendCommand();
    public List<PaintCell> PaintCells => _paintCells;
    private void Start()
    {
        SendPaintCells();
        _paintCellChangedCommand.PaintCells = new List<PaintCell>();
        foreach (PaintCell paintCell in _paintCells)
            if (paintCell.Available)
                _paintCellChangedCommand.PaintCells.Add(paintCell);
        _mediator.Publish(_paintCellChangedCommand);
    }

    public void UnblockPaint(string paintName)
    {
        foreach (PaintCell paintCell in _paintCells)
            if (paintCell.Paint.Name == paintName)
            {
                _paintCellChangedCommand.PaintCells.Add(paintCell);
                _mediator.Publish(_paintCellChangedCommand);
                paintCell.MakeAvailable();
            }
    }

    public int GetDesaturationCount()
    {
        return _desaturationCount;
    }

    public bool UseDesaturation()
    {
        if (_desaturationCount > 0)
        {
            _desaturationCount--;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ChangePaintCount(PaintCell paintCell, int count)
    {
        if (paintCell.Available)
        {
            if (paintCell.ChangeCount(count))
            {
                _mediator.Publish(_paintCellChangedCommand);
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public bool ChangePaintCount(string paintName, int count)
    {
        foreach (PaintCell paintCell in _paintCells)
            if (paintCell.Paint.Name == paintName)
            {
                ChangePaintCount(paintCell, count);
            }
        return false;
    }
    private void SendPaintCells()
    {
        _paintCellSendCommand.PaintCells = _paintCells;
        _mediator.Publish(_paintCellSendCommand);
    }
}

[Serializable]
public class PaintCell : StoreItem
{
    [SerializeField] private Paint _paint;
    [SerializeField] private bool _available;
    private PaintCellChangedCommand _paintCellChangedCommand = new PaintCellChangedCommand();
    public Paint Paint => _paint;
    public bool Available => _available;
    public string Name => _paint.Name;
    public Color Color => _paint.Color; 
    public void MakeAvailable()
    {
        _available = true;
    }
    public bool ChangeCount(int count)
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
}