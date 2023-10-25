using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class Enemy_Test_Cases 
{
    #region Setup and Teardown
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return SceneSetUpTests.SetUp("SceneWithEssentials");
    }
    [UnityTearDown]
    public IEnumerator TearDown()
    {
        yield return SceneSetUpTests.TearDown("EmptyScene");
    }
    #endregion

    #region Tests
    [UnityTest]
    public IEnumerator CC01_Testiranja_smrti_Enemya_lv1()
    {
        //Arrange
        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab).GetComponent<Enemy>();
        Collider enemyLv1Collider = enemyLv1.GetComponent<Collider>();

        //Act
        //Waiting for player to rotate to enemy
        yield return SceneSetUpTests.WaitForPlayerToRotateToTarget(enemyLv1Collider, enemyLv1.transform.position);
        //Waiting for player to shoot
        yield return SceneSetUpTests.WaitForPlayerToShoot();

        // Wait until the coin is spawned from the enemy
        yield return new WaitUntil(() => GameObject.FindObjectOfType<Coin>() != null);
        Coin silverCoin = GameObject.FindObjectOfType<Coin>();
        int silverCoinValue = silverCoin.GetCoinValueInfo();

        //Assert
        Assert.IsTrue(enemyLv1 == null);
        Assert.AreEqual(SceneSetUpTests.SilverCoinValue(), silverCoinValue);
    }
    [UnityTest]
    public IEnumerator CC02_Testiranja_smrti_Enemya_lv2()
    {
        //Arrange
        Enemy enemyLv2 = GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab).GetComponent<Enemy>();
        Collider enemyLv2Collider = enemyLv2.GetComponent<Collider>();
        Shooting shooting = SceneSetUpTests.player.GetComponent<Shooting>();

        //Act

        // Waiting for player to rotate to enemy
        yield return SceneSetUpTests.WaitForPlayerToRotateToTarget(enemyLv2Collider, enemyLv2.transform.position);

        //Waiting for player to shoot
        yield return SceneSetUpTests.WaitForPlayerToShoot();
        // Wait for shoot frequency of a player to shoot again
        float realShootFreq = shooting.GetRealShootFrequency();
        yield return new WaitForSeconds(realShootFreq);
        // Shoot at the enemy
        yield return SceneSetUpTests.WaitForPlayerToShoot();

        // Wait until the coin is spawned from the enemy
        yield return new WaitUntil(() => GameObject.FindObjectOfType<Coin>() != null);
        Coin goldCoin = GameObject.FindObjectOfType<Coin>();
        int goldCoinValue = goldCoin.GetCoinValueInfo();

        //Assert
        Assert.IsTrue(enemyLv2 == null);
        Assert.AreEqual(SceneSetUpTests.GoldCoinValue(), goldCoinValue);
    }
    [UnityTest]
    public IEnumerator CC03_Testiranje_kretnji_Enemy_a()
    {
        //Arrange
        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab, new Vector3(10,1,0), Quaternion.identity).GetComponent<Enemy>();
        float enemyLv1Speed = enemyLv1.GetStartSpeed();
        float epsiolon = 1;

        //Act
        //Waiting for 5 seconds because enemyLv1 speed is 2, player position is (0,1,0) and enemy position is (10,1,0)
        float distance = Vector3.Distance(enemyLv1.transform.position, SceneSetUpTests.player.transform.position);
        yield return new WaitForSeconds(distance / enemyLv1Speed);
        distance = Vector3.Distance(enemyLv1.transform.position, SceneSetUpTests.player.transform.position);

        //Assert
        Assert.Greater(distance, enemyLv1.GetDistanceToPlayerInfo());
        Assert.Less(distance, enemyLv1.GetDistanceToPlayerInfo() + epsiolon);
    }
    [UnityTest]
    public IEnumerator CC04_Testiranje_brzine_enemy_a_lv1()
    {
        //Arrange
        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab).GetComponent<Enemy>();

        //Act
        //Waiting for Update to end
        yield return null;
        float realSpeedEnemyLv1 = enemyLv1.GetRealSpeed();

        //Assert
        Assert.AreEqual(2, realSpeedEnemyLv1);        
    }
    [UnityTest]
    public IEnumerator CC05_Testiranje_brzine_enemy_a_lv2()
    {

        //Arrange
        Enemy enemyLv2 = GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab).GetComponent<Enemy>();

        //Act
        //Waiting for Update to end
        yield return null;
        float realSpeedEnemyLv2 = enemyLv2.GetRealSpeed();

        //Assert
        Assert.AreEqual(1, realSpeedEnemyLv2);
    }
    #endregion
}
