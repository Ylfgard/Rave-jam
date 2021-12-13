using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PaintPanel : MonoBehaviour
{
    [SerializeField]
    private Color _paintColor;
    private TextMeshProUGUI _paintName;
    private TextMeshProUGUI _paintCount;
    public void UpdatePaintPanel(PaintCell paintCell)
    {
        _paintName.text = paintCell.Paint.Name;
        _paintCount.text = paintCell.Count.ToString();
        _paintColor = paintCell.Paint.Color;
    }
}
