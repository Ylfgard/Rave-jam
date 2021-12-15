using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputDetector : MonoBehaviour
{
    [SerializeField] private SingleInputHandler _singleTouchHandler;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            _singleTouchHandler.InputDown(Input.mousePosition);
        if(Input.GetMouseButtonUp(0))
            _singleTouchHandler.InputUp(Input.mousePosition);
        if(Input.GetMouseButton(0))
        {
            if(Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0)
                _singleTouchHandler.InputPress(Input.mousePosition);
            else
                _singleTouchHandler.InputMove(Input.mousePosition);
        }
    }
}
