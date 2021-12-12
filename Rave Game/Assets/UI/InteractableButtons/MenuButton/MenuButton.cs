using UnityEngine;
[System.Serializable]
public abstract class MenuButton : InteractableButton
{
    [SerializeField]
    protected Menu _menu;
    [SerializeField]
    protected ButtonMenu _buttonMenu;
}