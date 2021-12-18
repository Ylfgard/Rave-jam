using System.Collections.Generic;
using UnityEngine;
using System;

public class Palette : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private int _desaturationCount;
    [SerializeField] private List<PaintCell> _paintCells;
    private PaintCellChangedCommand _paintCellChangedCommand = new PaintCellChangedCommand();
    private PaintCellSendCommand _paintCellSendCommand = new PaintCellSendCommand();
    public List<PaintCell> PaintCells => _paintCells;

    private void Awake()
    {
        _mediator.Subscribe<MakePaintPriceNormalCommand>(MakePriceNormal);    
    }

    private void Start()
    {
        SendPaintCells();
        _paintCellChangedCommand.PaintCells = new List<PaintCell>();
        foreach (PaintCell paintCell in _paintCells)
            if (paintCell.Available)
                _paintCellChangedCommand.PaintCells.Add(paintCell);
        _mediator.Publish(_paintCellChangedCommand);
    }

    public void UnblockPaint(Paint paint)
    {
        foreach (PaintCell paintCell in _paintCells)
            if (paintCell.Paint == paint)
            {
                _paintCellChangedCommand.PaintCells.Add(paintCell);
                _mediator.Publish(_paintCellChangedCommand);
                paintCell.MakeAvailable();
            }
    }

    private void MakePriceNormal(MakePaintPriceNormalCommand callback)
    {
        foreach(PaintCell paintCell in _paintCells)
            if(paintCell.Paint == callback.Paint)
            {
                if(callback.Unblock) paintCell.ChangeUnblockingCount(1);
                else paintCell.ChangeUnblockingCount(-1);
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
<<<<<<< HEAD
    [SerializeField] private bool _available;
    private int _unblockingCount;
=======
>>>>>>> 3a6c6a8182710b21f652b593f659c0379ece5bf9
    private PaintCellChangedCommand _paintCellChangedCommand = new PaintCellChangedCommand();
    public Paint Paint => _paint;
    public bool Available => _available;
    public string Name => _paint.Name;
    public Color Color => _paint.Color; 
    public bool NormalPrice()
    {   
        if(_unblockingCount > 0) return true;
        else return false;
    }
    public void MakeAvailable()
    {
        _available = true;
    }
    public void ChangeUnblockingCount(int count)
    {
        _unblockingCount += count;
        if(_unblockingCount < 0)
        {
            Debug.LogError("Unblock count lower than zero!");
            _unblockingCount = 0;
        }
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