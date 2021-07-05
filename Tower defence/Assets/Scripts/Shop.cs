using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret() 
    {
        Debug.Log("Standard turret");
        buildManager.SelectTurretToBuild(standardTurret);
    }
   public void SelectMissileTurret()
    {
        Debug.Log("missile launcher turret");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("laser beamer turret");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
