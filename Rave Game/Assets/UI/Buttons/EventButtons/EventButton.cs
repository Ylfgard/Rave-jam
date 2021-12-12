using System;
public class EventButton : InteractableButton
{
    public event Action Clicked;
    protected sealed override void Interact() => Clicked?.Invoke();
}
