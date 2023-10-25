using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class Player_Test_Cases
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
    public IEnumerator CC01_Testiranje_UI_a()
    {
        //Arrange
        PowerUp speedPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp damagePowerUpX2 = GameObject.Instantiate(SceneSetUpTests.DamagePowerUpX2, new Vector3(5, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp coinPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX2, new Vector3(7, 1, 0), Quaternion.identity).GetComponent<PowerUp>();

        Vector3 speedPowerUpX2Position = speedPowerUpX2.transform.position;
        Vector3 damagePowerUpX2Position = damagePowerUpX2.transform.position;
        Vector3 coinPowerUpX2Position = coinPowerUpX2.transform.position;

        //Act1
        Text healthText = SceneSetUpTests.player.GetHealthText();
        Text scoreText = SceneSetUpTests.player.GetScoreText();
        Text canShootText = SceneSetUpTests.player.GetCanShootText();

        //Assert1
        Assert.AreEqual("Health: 10", healthText.text);
        Assert.AreEqual("Score: 0", scoreText.text);
        Assert.AreEqual("You can shoot!", canShootText.text);

        //Act2
        //Wait for player to move to speed power up
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpX2Position);
        Text speedPowerStatus = SceneSetUpTests.player.GetSpeedPowerStatusText();

        //Assert2
        Assert.AreEqual("SpeedMultiplier is activated with multiplier: x2", speedPowerStatus.text);

        //Act3
        //Wait for player to move to damage power up
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(damagePowerUpX2Position);
        Text damagePowerStatus = SceneSetUpTests.player.GetDamagePowerStatusText();

        //Assert3      
        Assert.AreEqual("DamageMultiplier is activated with multiplier: x2", damagePowerStatus.text);

        //Act4
        //Wait for player to move to coin power up
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(coinPowerUpX2Position);      
        Text coinPowerStatus = SceneSetUpTests.player.GetCoinPowerStatusText();       
        
        //Assert4  
        Assert.AreEqual("CoinMultiplier is activated with multiplier: x2", coinPowerStatus.text);
        Debug.Log(speedPowerStatus.text+" "+damagePowerStatus.text+" "+coinPowerStatus.text);
    }
    [UnityTest]
    public IEnumerator CC02_Testiranje_stanja_Can_Shoot()
    {
        //Arrange
        Shooting shooting = SceneSetUpTests.player.GetComponent<Shooting>();

        //Act1
        //Waiting for player to shoot
        yield return SceneSetUpTests.WaitForPlayerToShoot();
        //Waiting for Update to update player text
        yield return null;
        Text canShootText = SceneSetUpTests.player.GetCanShootText();

        //Assert1
        Assert.AreEqual("You cant shoot!", canShootText.text);

        //Act2
        //Waiting for two seconds to check if player can shoot again
        float playerShootFreq = shooting.GetRealShootFrequency();
        yield return new WaitForSeconds(playerShootFreq);
        canShootText = SceneSetUpTests.player.GetCanShootText();

        //Assert2
        Assert.AreEqual("You can shoot!", canShootText.text);
    }

    [UnityTest]
    public IEnumerator CC03_Testiranje_smrti_igraca()
    {
        //Arrange
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(10, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(-10, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(10, 1, 2), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(-10, 1, 2), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(10, 1, 4), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(-10, 1, 4), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(10, 1, -2), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(-10, 1, -2), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(10, 1, -4), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(-10, 1, -4), Quaternion.identity);
        GameManager gameManager = SceneSetUpTests.player.GetComponent<GameManager>();

        //Act
        //Waiting for Time.timeScale==0 because when player dies Time.timeScale is 0
        yield return new WaitUntil(() => EGameState.Paused == gameManager.GameState);

        //Assert
        Text gameOverText = SceneSetUpTests.player.GetGameOverText();
        Assert.AreEqual("GAME OVER", gameOverText.text);
        Assert.AreEqual(0, Time.timeScale);
    }
    [UnityTest]
    public IEnumerator CC04_Testiranje_pobjede_igraca()
    {
        //Arrange
        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab, new Vector3(10, 1, 0), Quaternion.identity).GetComponent<Enemy>();
        Collider enemyLv1Collider = enemyLv1.GetComponent<Collider>();
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(1, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(2, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(3, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(4, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(5, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(9, 1, 0), Quaternion.identity);

        //Act
        // Waiting for player to rotate to enemy
        yield return SceneSetUpTests.WaitForPlayerToRotateToTarget(enemyLv1Collider, enemyLv1.transform.position);

        //Waiting for player to shoot
        yield return SceneSetUpTests.WaitForPlayerToShoot();

        // Wait until the coin is spawned from the enemy
        yield return new WaitUntil(() => GameObject.FindObjectOfType<Coin>() != null);
        Coin silverCoin = GameObject.FindObjectOfType<Coin>();
        Collider silverCoinCollider = silverCoin.GetComponent<Collider>();
        Vector3 silverCoinPosition = silverCoin.transform.position;

        // Navigate the player towards the object     
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(silverCoinPosition);

        //Assert
        Text gameOverText = SceneSetUpTests.player.GetGameOverText();
        Assert.AreEqual("GAME WON", gameOverText.text);
        Assert.AreEqual(0, Time.timeScale);
    }
    [UnityTest]
    public IEnumerator CC05_Testiranje_pucanja_na_pocetku_igre()
    {
        //Arrange
        Text canShootText = SceneSetUpTests.player.GetCanShootText();

        //Act
        //Waiting for player to shoot
        yield return SceneSetUpTests.WaitForPlayerToShoot();
        //Waiting for Projectile to Instantiate
        Projectile projectile = GameObject.FindObjectOfType<Projectile>();
        //Assert
        Assert.AreEqual("You can shoot!", canShootText.text);
        Assert.IsNotNull(projectile);
    }
    #endregion
}
