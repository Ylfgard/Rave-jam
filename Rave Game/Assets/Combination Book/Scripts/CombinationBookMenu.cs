using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationBookMenu : MonoBehaviour, IIDSettable
{
    [SerializeField] private Mediator _mediator;
    private List<PaintCell> _paintCells => new List<PaintCell>();
    private CloseMenusCommand _closeCommand = new CloseMenusCommand();

    private void Awake()
    {
        _mediator.Subscribe<PaintCellChangedCommand>(AddPaint);
    }

    public void SetID(string id)
    {
        _closeCommand.IDs.Add(id);
    }

    public void CloseMenu()
    {
        _mediator.Publish(_closeCommand);
    }

    private void AddPaint(PaintCellChangedCommand callback)
    {
        //_paintCells = callback.PaintCells;
    }
}
