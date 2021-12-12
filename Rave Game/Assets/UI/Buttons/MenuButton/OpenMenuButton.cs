public class ShowMenuButton : MenuButton
{
    protected sealed override void Interact()
    {
        _menu.Show();
    }
}
