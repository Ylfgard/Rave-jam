using UnityEngine;
[System.Serializable]
public class ShowMenuButton : MenuButton
{
    protected sealed override void Interact()
    {
        _buttonMenu.Hide();
        _menu.Show();
    }
}
