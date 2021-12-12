using UnityEngine;
public class Menu : MonoBehaviour, IMenu
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