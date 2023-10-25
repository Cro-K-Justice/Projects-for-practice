using UnityEngine;

public enum EInputManager
{
    Unity,
    Test
}

public class InputManagerController : MonoBehaviour
{
    #region Singleton
    public static InputManagerController Instance;
    private void Init()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    #endregion
    
    #region Fields
    private readonly IInputManager[] managers = { new IM_Unity(), new IM_Test() };
    #endregion
    
    #region Serialize Fields
    [SerializeField] private EInputManager managerType;
    #endregion
    
    #region Properties
    public EInputManager ManagerType
    {
        get => managerType;
        set => managerType = value;
    }
    public IInputManager InputManager => managers[(int)managerType];
    #endregion

    #region Unity Functions
    private void Awake()
    {
        Init();
    }
    #endregion

    #region Functions
    public static float GetAxis(string axisName) => Instance.InputManager.GetAxis(axisName);
    public static void SetAxis(string axisName, float axisValue) => Instance.InputManager.SetAxis(axisName, axisValue);
    public static bool GetMouseButtonDown(int mouseButton) => Instance.InputManager.GetMouseButtonDown(mouseButton);
    public static void SetMouseButtonDown(int mouseButton, bool mouseValue) => Instance.InputManager.SetMouseButtonDown(mouseButton, mouseValue);
    public static Vector3 GetMousePosition() => Instance.InputManager.GetMousePosition();
    public static void SetMousePosition(Vector3 mousePosition) => Instance.InputManager.SetMousePosition(mousePosition);
    #endregion
}
