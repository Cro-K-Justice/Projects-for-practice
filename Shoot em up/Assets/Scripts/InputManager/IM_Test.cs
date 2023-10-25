using System;
using UnityEngine;

public class IM_Test : IInputManager
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    
    private float horizontalAxis;
    private float verticalAxis;

    private bool mouseButtonDown0;
    private bool mouseButtonDown1;
    private bool mouseButtonDown2;

    private Vector3 mousePosition;

    public float GetAxis(string axisName)
    {
        return axisName switch
        {
            HorizontalAxisName => horizontalAxis,
            VerticalAxisName => verticalAxis,
            _ => throw new ArgumentException()
        };
    }

    public void SetAxis(string axisName, float axisValue)
    {
        if (string.IsNullOrEmpty(axisName)) return;
        switch (axisName)
        {
            case HorizontalAxisName:
                horizontalAxis = axisValue;
                break;
            case VerticalAxisName:
                verticalAxis = axisValue;
                break;
        }
    }

    public bool GetMouseButtonDown(int mouseButton)
    {
        return mouseButton switch
        {
            0 => mouseButtonDown0,
            1 => mouseButtonDown1,
            2 => mouseButtonDown2,
            _ => false
        };
    }

    public void SetMouseButtonDown(int mouseButton, bool mouseValue)
    {
        switch (mouseButton)
        {
            case 0:
                mouseButtonDown0 = mouseValue;
                break;
            case 1:
                mouseButtonDown1 = mouseValue;
                break;
            case 2:
                mouseButtonDown2 = mouseValue;
                break;
        }
    }

    public Vector3 GetMousePosition()
    {
        return mousePosition;
    }

    public void SetMousePosition(Vector3 mousePosition)
    {
        this.mousePosition = mousePosition;
    }
}
