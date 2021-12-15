using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleInputHandler : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;

    private Vector2 _lastInputPosition;

    public void InputDown(Vector2 touchPos)
    {
        _lastInputPosition = touchPos;
        RaycastHit2D ray = Physics2D.Raycast(touchPos, Vector2.zero);
        Collider2D c2d = ray.collider;
        if (c2d != null && c2d.gameObject.tag == "Leaf")
            _mediator.Publish(c2d.GetComponent<Leaf>());
    }

    public void InputPress(Vector2 touchPos)
    {

    }

    public void InputMove(Vector2 touchPos)
    {
        //
        // ...Do some stuff
        //
        _lastInputPosition = touchPos;
    }

    public void InputUp(Vector2 touchPos)
    {

    }
}
