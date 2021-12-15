using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMenuCloser : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;
    private CloseColoringMenuCommand _closeCommand = new CloseColoringMenuCommand();

    public void CloseAllMenu()
    {
        _mediator.Publish(_closeCommand);
    }
}
