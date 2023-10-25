using UnityEngine;

public class IM_Unity : IInputManager
{
    public float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }
    public void SetAxis(string axisName, float axisValue)
    {
        throw new System.NotImplementedException();
    }

    public bool GetMouseButtonDown(int mouseButton)
    {
        return Input.GetMouseButtonDown(mouseButton);
    }

    public void SetMouseButtonDown(int mouseButton, bool mouseValue)
    {
        throw new System.NotImplementedException();
    }

    public Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }

    public void SetMousePosition(Vector3 mousePosition)
    {
        throw new System.NotImplementedException();
    }
}
