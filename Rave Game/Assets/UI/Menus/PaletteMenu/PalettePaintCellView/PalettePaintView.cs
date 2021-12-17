using UnityEngine;
[RequireComponent(typeof(Panel))]
public class PalettePaintView : PaintView
{
    [SerializeField]
    private ColorView _paintColorView;
    [SerializeField]
    private StringView _paintNameView;
    [SerializeField]
    private NumberView _paintCountView;
    private Panel _palettePaintViewPanel;
    private void Awake()
    {
        _palettePaintViewPanel = GetComponent<Panel>();
    }
    public override void UpdatePaintView()
    {
        _paintNameView.SetString(_paint.Name);
        _paintCountView.SetNumber(_paint.Count);
        _paintColorView.SetColor(_paint.Color);
        if (_paint.Available)
            _palettePaintViewPanel.Show();
        else
            _palettePaintViewPanel.Hide();
    }
}