using UnityEngine;

public interface IInputManager
{
    public float GetAxis(string axisName);
    public void SetAxis(string axisName, float axisValue);
    public bool GetMouseButtonDown(int mouseButton);
    public void SetMouseButtonDown(int mouseButton, bool mouseValue);
    public Vector3 GetMousePosition();
    public void SetMousePosition(Vector3 mousePosition);
}
