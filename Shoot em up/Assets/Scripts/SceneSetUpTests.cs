using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


public static class SceneSetUpTests 
{
    #region Prefabs
    public static GameObject EnemyLV1Prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Characters/EnemyLv1.prefab");
    public static GameObject EnemyLV2Prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Characters/EnemyLv2.prefab");

    public static GameObject SpeedPowerUpX2 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Speed Power Ups/X2 Speed Power Up.prefab");
    public static GameObject SpeedPowerUpX3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Speed Power Ups/X3 Speed Power Up.prefab");
    public static GameObject SpeedPowerUpX5 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Speed Power Ups/X5 Speed Power Up.prefab");

    public static GameObject DamagePowerUpX2 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Damage Power Ups/X2 Damage Power Up.prefab");
    public static GameObject DamagePowerUpX3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Damage Power Ups/X3 Damage Power Up.prefab");
    public static GameObject DamagePowerUpX5 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Damage Power Ups/X5 Damage Power Up.prefab");

    public static GameObject CoinPowerUpX2 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Coin Power Ups/X2 Coin Power Up.prefab");
    public static GameObject CoinPowerUpX3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Coin Power Ups/X3 Coin Power Up.prefab");
    public static GameObject CoinPowerUpX5 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/PowerUps/Coin Power Ups/X5 Coin Power Up.prefab");

    public static GameObject PlayerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Characters/Player.prefab");

    public static GameObject SpawnerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Spawner/Spawner.prefab");

    public static GameObject SilverCoin = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Coins/Silver Coin.prefab");
    public static GameObject GoldCoin = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Coins/Gold Coin.prefab");
    #endregion

    public static Player player;
    private static int winScore;
    public static IEnumerator SetUp(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        yield return new EnterPlayMode();
        InputManagerController.Instance.ManagerType = EInputManager.Test;
        player = GameObject.FindObjectOfType<Player>();
        winScore = player.GetWinScoreInfo();
    }
    public static IEnumerator TearDown(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        yield return new ExitPlayMode();
    }
    public static IEnumerator WaitForPlayerToMoveTowardsPoint(Vector3 point, float epsilon = 0.1f)
    {
        float realSpeedPrevious = player.GetRealSpeed();
        float realSpeedCurrent = realSpeedPrevious;
        float deviation = epsilon + realSpeedCurrent * Time.fixedDeltaTime;
        var distX = point.x - player.transform.position.x;
        var distZ = point.z - player.transform.position.z;
        var bDiffOnX = Mathf.Abs(distX) > (deviation);
        var bDiffOnZ = Mathf.Abs(distZ) > (deviation);
        while (bDiffOnX || bDiffOnZ)
        {
            Vector3 velocity = new Vector3(bDiffOnX ? distX : 0f, 0f, bDiffOnZ ? distZ : 0f).normalized;

            InputManagerController.SetAxis("Horizontal", velocity.x);
            InputManagerController.SetAxis("Vertical", velocity.z);
            distX = point.x - player.transform.position.x;
            distZ = point.z - player.transform.position.z;
            bDiffOnX = Mathf.Abs(distX) > (deviation);
            bDiffOnZ = Mathf.Abs(distZ) > (deviation);
            //When player score is equel or above Win Score Time.timeScale = 0
            if (player.GetScoreInfo() >= winScore) break;
            // Players position is updated every Fixed update, so wait for it to move
            yield return new WaitForFixedUpdate();

            realSpeedCurrent = player.GetRealSpeed();
            if (realSpeedCurrent != realSpeedPrevious)
            {
                deviation = epsilon + realSpeedCurrent * Time.fixedDeltaTime;
                realSpeedPrevious = realSpeedCurrent;
            }
        }
        //PLayer standing still
        InputManagerController.SetAxis("Horizontal", 0);
        InputManagerController.SetAxis("Vertical", 0);
    }

    public static IEnumerator WaitForPlayerToShoot()
    {
        // Shoot at the enemy
        InputManagerController.SetMouseButtonDown(0, true);
        // Player shoots at Update so wait for null until it shoots
        yield return null;
        // Set the input button state back to false
        InputManagerController.SetMouseButtonDown(0, false);
    }
    public static IEnumerator WaitForPlayerToRotateToTarget(Collider collider, Vector3 position)
    {
        //Getting all planes from camera field view
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        //Wait until target comes in field of view of the camera
        yield return new WaitUntil(() => GeometryUtility.TestPlanesAABB(planes, collider.bounds));

        // Get the mouse position of the target
        var mousePosition = Camera.main.WorldToScreenPoint(collider.transform.position);
        InputManagerController.SetMousePosition(mousePosition);
        // Wait for the player to turn towards a target (rotation happens in FixedUpdate)
        yield return new WaitForFixedUpdate();
    }
    public static int SilverCoinValue()
    {
        return SilverCoin.GetComponent<Coin>().GetCoinValueInfo();
    }
    public static int GoldCoinValue()
    {
        return GoldCoin.GetComponent<Coin>().GetCoinValueInfo();
    }
}
