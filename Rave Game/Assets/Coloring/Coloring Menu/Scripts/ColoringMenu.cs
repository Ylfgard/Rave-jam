using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoringMenu : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    [SerializeField] private GameObject _menuUI;
    private List<PaintCell> _paintCells;
    private int _currentPaintIndex;
    private SelectedPaintChangedCommand _selectedPaintChangedCommand = new SelectedPaintChangedCommand();

    private void Awake()
    {
        _mediator.Subscribe<Leaf>(OpenMenu);   
        _mediator.Subscribe<PaintCellChangedCommand>(UpdateAvailablePaints);
        CloseMenu();
    }

    private void UpdateAvailablePaints(PaintCellChangedCommand callback)
    {
        _paintCells = new List<PaintCell>();
        foreach(PaintCell paintCell in callback.PaintCells)
            _paintCells.Add(paintCell);
    }

    private void OpenMenu(Leaf leaf)
    {
        _currentPaintIndex = 0;
        ChangeSelectedPaint();
        ChangeMenuState(true);
    }
    
    public void CloseMenu()
    {
        ChangeMenuState(false);
    }

    private void ChangeMenuState(bool state)
    {
        _menuUI.SetActive(state);
    }

    private void ChangeSelectedPaint()
    {
        _selectedPaintChangedCommand.PaintCell = _paintCells[_currentPaintIndex];
        _mediator.Publish(_selectedPaintChangedCommand);
    }

    public void NextPaint()
    {
        _currentPaintIndex++;
        if(_currentPaintIndex >= _paintCells.Count)
            _currentPaintIndex = 0;
        ChangeSelectedPaint();
    }

    public void PreviousPaint()
    {
        _currentPaintIndex--;
        if(_currentPaintIndex < 0)
            _currentPaintIndex = _paintCells.Count - 1;
        ChangeSelectedPaint();
    }
}
