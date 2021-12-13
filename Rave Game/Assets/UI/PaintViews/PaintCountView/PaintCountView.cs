using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class PaintCountView : MonoBehaviour
{
    private TextMeshProUGUI _paintCount;
    private void Awake()
    {
        _paintCount = GetComponent<TextMeshProUGUI>();
    }
    public void SetCount(int count)
    {
        _paintCount.text = count.ToString();
    }
}
