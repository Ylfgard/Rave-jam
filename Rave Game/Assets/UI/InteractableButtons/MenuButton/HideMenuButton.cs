public class HideMenuButton : MenuButton
{
    protected sealed override void Interact()
    {
        _buttonMenu.Show();
        _menu.Hide();
    }
}
