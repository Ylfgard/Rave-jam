using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantStoreMenu : MonoBehaviour, IMenu
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
