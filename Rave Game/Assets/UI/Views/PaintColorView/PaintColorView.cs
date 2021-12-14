using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ColorView : MonoBehaviour
{
    private Image _colorView;
    private void Awake()
    {
        _colorView = GetComponent<Image>();
    }
    public void SetColor(Color color)
    {
        _colorView.color = color;
    }
}
