using System.Collections.Generic;
using UnityEngine;
using System;
using Animals;

public class Palette : MonoBehaviour
{
    [SerializeField] private AnimalDataKeeper _animalDataKeeper;
    [SerializeField] private Mediator _mediator;
    [SerializeField] private Desaturation _desaturation;
    [SerializeField] private List<PaintCell> _paintCells;
    private PaintCellChangedCommand _paintCellChangedCommand = new PaintCellChangedCommand();
    private PaintCellSendCommand _paintCellSendCommand = new PaintCellSendCommand();
    public List<PaintCell> PaintCells => _paintCells;
    private void Awake()
    {
        foreach (PaintCell paintCell in _paintCells)
            paintCell.SetAnimalDataKeeper(_animalDataKeeper);
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

    public Desaturation GetDesaturation()
    {
        return _desaturation;
    }

    public bool ChangeDesaturationCount(int count)
    {
        return _desaturation.ChangeCount(count);
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
    private int _unblockingCount;
    private PaintCellChangedCommand _paintCellChangedCommand = new PaintCellChangedCommand();
    private AnimalDataKeeper _animalDataKeeper;
    public Paint Paint => _paint;
    public string Name => _paint.Name;
    public Color Color => _paint.Color;
    private bool _available;
    public bool Available => _available;
    private int _combinationPrice;
    private float _priceMultiplierIfThereIsNoAnimalsOnTheScene;
    public void Initialize(int CombinationPrice, float PriceMultiplierIfThereIsNoAnimalsOnTheScene)
    {
        _combinationPrice = CombinationPrice;
        _priceMultiplierIfThereIsNoAnimalsOnTheScene = PriceMultiplierIfThereIsNoAnimalsOnTheScene;
    }
    public void SetAnimalDataKeeper(AnimalDataKeeper animalDataKeeper)
    {
        _animalDataKeeper = animalDataKeeper;
    }
    public override bool Buy(int money)
    {
        if (!_available)
        {
            int itemPrice = Convert.ToInt32(_price * _combinationPrice);
            if (money >= _combinationPrice)
            {
                _available = true;
                UnblockCombination();
                return true;
            }
            else
            {
                return false;
            }
                
        }
        else
        {
            if (NormalPrice())
            {
                if (money >= _price)
                {
                    _count++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                int itemPrice = Convert.ToInt32(_price * _priceMultiplierIfThereIsNoAnimalsOnTheScene);
                if (money >= itemPrice)
                {
                    _count++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    public int GetPrice()
    {
        if (!_available)
        {
            return Convert.ToInt32(_price * _combinationPrice);
        }
        else
        {
            if (NormalPrice())
            {
                return _price;
            }
            else
            {
                return Convert.ToInt32(_price * _priceMultiplierIfThereIsNoAnimalsOnTheScene);
            }
        }
    }
    public void UnblockCombination()
    {
        _animalDataKeeper.UnblockCombination(this);
    }
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
