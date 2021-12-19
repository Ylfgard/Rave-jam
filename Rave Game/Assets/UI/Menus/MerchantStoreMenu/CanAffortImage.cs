using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CanAffortImage
{
    [SerializeField]
    private Image _canAffortImage;
    public void ChangeAffortColor(int money, int price)
    {
        if (money >= price)
            _canAffortImage.color = Color.green;
        else
            _canAffortImage.color = Color.red;
    }
}