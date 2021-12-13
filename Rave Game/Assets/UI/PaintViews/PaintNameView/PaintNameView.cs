using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class PaintNameView : MonoBehaviour
{
    private TextMeshProUGUI _paintName;
    private void Awake()
    {
        _paintName = GetComponent<TextMeshProUGUI>();
    }
    public void SetName(string name)
    {
        _paintName.text = name;
    }
}
