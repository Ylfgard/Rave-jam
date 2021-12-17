using UnityEngine;
using UnityEngine.UI;
public class MerchantPaintCellPanel : MonoBehaviour, IParentable
{
    [SerializeField]
    private Button _addNumberButton;
    [SerializeField]
    private Button _removeNumberButton;
    [SerializeField]
    private PaintCell _paint;
    [SerializeField]
    private NumberView _paintCellCountView;
    private NumberCounter _paintCellCounter = new NumberCounter();
    private void OnEnable()
    {
        _addNumberButton.onClick.AddListener(_paintCellCounter.AddNumber);
        _removeNumberButton.onClick.AddListener(_paintCellCounter.RemoveNumber);
        _paintCellCounter.NumberChange += _paintCellCountView.SetNumber;
    }
    private void OnDisable()
    {
        _addNumberButton.onClick.RemoveListener(_paintCellCounter.AddNumber);
        _removeNumberButton.onClick.RemoveListener(_paintCellCounter.RemoveNumber);
        _paintCellCounter.NumberChange -= _paintCellCountView.SetNumber;

    }
    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }
    public void UsePaintCell()
    {
        _paint.AddCount(_paintCellCounter.Count);
        _paintCellCounter.ReseCount();
    }
}