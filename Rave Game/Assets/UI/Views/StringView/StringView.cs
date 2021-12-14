using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class StringView : MonoBehaviour
{
    private TextMeshProUGUI _stringView;
    private void Awake()
    {
        _stringView = GetComponent<TextMeshProUGUI>();
    }
    public void SetString(string name)
    {
        _stringView.text = name;
    }
}
