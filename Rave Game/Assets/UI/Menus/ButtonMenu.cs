using UnityEngine;
public class ButtonMenu : MonoBehaviour, IMenu
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
