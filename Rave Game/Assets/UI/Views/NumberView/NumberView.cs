using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class NumberView : MonoBehaviour
{
    private TextMeshProUGUI _numberView;
    private void Awake()
    {
        _numberView = GetComponent<TextMeshProUGUI>();
    }
    public void SetNumber(int number)
    {
        _numberView.text = number.ToString();
    }
}
