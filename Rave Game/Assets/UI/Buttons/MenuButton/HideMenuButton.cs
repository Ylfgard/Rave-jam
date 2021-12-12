public class HideMenuButton : MenuButton
{
    protected sealed override void Interact()
    {
        _menu.Hide();
    }
}
