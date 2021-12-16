using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(NumberView))]
public class PaintCellCounter : MonoBehaviour
{
    [SerializeField]
    private Button _addCountButton;
    [SerializeField]
    private Button _removeCountButton;
    private NumberView _paintCellCountView;
    private int _paintCellCount;
    public int PaintCellCount => _paintCellCount;
    private void Awake()
    {
        _paintCellCountView = GetComponent<NumberView>();
    }
    private void OnEnable()
    {
        _addCountButton.onClick.AddListener(AddPaintCellCount);
        _removeCountButton.onClick.AddListener(RemovePaintCellCount);
    }
    private void OnDisable()
    {
        _addCountButton.onClick.RemoveListener(AddPaintCellCount);
        _removeCountButton.onClick.RemoveListener(RemovePaintCellCount);
    }
    private void AddPaintCellCount()
    {
        _paintCellCount++;
        _paintCellCountView.SetNumber(_paintCellCount);
    }
    private void RemovePaintCellCount()
    {
        if(_paintCellCount - 1 >= 0)
           _paintCellCount--;
        _paintCellCountView.SetNumber(_paintCellCount);
    }
    public void ReseCount()
    {
        _paintCellCount = 0;
        _paintCellCountView.SetNumber(_paintCellCount);
    }
}