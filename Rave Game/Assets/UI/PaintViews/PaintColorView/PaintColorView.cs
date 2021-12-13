using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class PaintColorView : MonoBehaviour
{
    private Image _paintColor;
    private void Awake()
    {
        _paintColor = GetComponent<Image>();
    }
    public void SetColor(Color color)
    {
        _paintColor.color = color;
    }
}
