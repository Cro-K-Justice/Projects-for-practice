using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Power_Up_Test_Cases
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
    public IEnumerator CC01_Testiranje_Power_upova_da_li_se_uniste_kad_se_pokupe()
    {
        //Arrange
        PowerUp speedPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        Vector3 speedPowerUpX2Position = speedPowerUpX2.transform.position;

        //Act
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpX2Position);

        //Assert
        Assert.IsTrue(speedPowerUpX2 == null);
    }
    [UnityTest]
    public IEnumerator CC02_Testiranje_CoinPowerUp_multipliera_UI()
    {
        //Arrenge
        Text coinPowerUpStatus;
        PowerUp coinPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp coinPowerUpX3 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX3, new Vector3(5, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp coinPowerUpX5 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(7, 1, 0), Quaternion.identity).GetComponent<PowerUp>();

        Vector3 coinPowerUpX2Position = coinPowerUpX2.transform.position;
        Vector3 coinPowerUpX3Position = coinPowerUpX3.transform.position;
        Vector3 coinPowerUpX5Position = coinPowerUpX5.transform.position;

        //Act1
        //Waiting for player to collect coinPowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(coinPowerUpX2Position);
        coinPowerUpStatus = SceneSetUpTests.player.GetCoinPowerStatusText();

        //Assert1
        Assert.AreEqual("CoinMultiplier is activated with multiplier: x2", coinPowerUpStatus.text);

        //Act2
        //Waiting for player to collect coinPowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(coinPowerUpX3Position);
        coinPowerUpStatus = SceneSetUpTests.player.GetCoinPowerStatusText();

        //Assert2
        Assert.AreEqual("CoinMultiplier is activated with multiplier: x5", coinPowerUpStatus.text);

        //Act3
        //Waiting for player to collect coinPowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(coinPowerUpX5Position);
        coinPowerUpStatus = SceneSetUpTests.player.GetCoinPowerStatusText();

        //Assert3
        Assert.AreEqual("CoinMultiplier is activated with multiplier: x10", coinPowerUpStatus.text);
    }
    [UnityTest]
    public IEnumerator CC03_Testiranje_DamagePowerUp_multipliera_UI()
    {
        //Arrenge
        Text damagePowerUpStatus;
        PowerUp damagePowerUpX2 = GameObject.Instantiate(SceneSetUpTests.DamagePowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp damagePowerUpX3 = GameObject.Instantiate(SceneSetUpTests.DamagePowerUpX3, new Vector3(5, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp damagePowerUpX5 = GameObject.Instantiate(SceneSetUpTests.DamagePowerUpX5, new Vector3(7, 1, 0), Quaternion.identity).GetComponent<PowerUp>();

        Vector3 damagePowerUpX2Position = damagePowerUpX2.transform.position;
        Vector3 damagePowerUpX3Position = damagePowerUpX3.transform.position;
        Vector3 damagePowerUpX5Position = damagePowerUpX5.transform.position;

        //Act1
        //Waiting for player to collect damagePowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(damagePowerUpX2Position);
        damagePowerUpStatus = SceneSetUpTests.player.GetDamagePowerStatusText();

        //Assert1
        Assert.AreEqual("DamageMultiplier is activated with multiplier: x2", damagePowerUpStatus.text);

        //Act2
        //Waiting for player to collect damagePowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(damagePowerUpX3Position);
        damagePowerUpStatus = SceneSetUpTests.player.GetDamagePowerStatusText();

        //Assert2
        Assert.AreEqual("DamageMultiplier is activated with multiplier: x5", damagePowerUpStatus.text);

        //Act3
        //Waiting for player to collect damagePowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(damagePowerUpX5Position);
        damagePowerUpStatus = SceneSetUpTests.player.GetDamagePowerStatusText();

        //Assert3
        Assert.AreEqual("DamageMultiplier is activated with multiplier: x10", damagePowerUpStatus.text);
    }
    [UnityTest]
    public IEnumerator CC04_Testiranje_SpeedPowerUp_multipliera_UI()
    {
        //Arrenge
        Text speedPowerUpStatus;
        PowerUp speedPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp speedPowerUpX3 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX3, new Vector3(5, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp speedPowerUpX5 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX5, new Vector3(7, 1, 0), Quaternion.identity).GetComponent<PowerUp>();

        Vector3 speedPowerUpX2Position = speedPowerUpX2.transform.position;
        Vector3 speedPowerUpX3Position = speedPowerUpX3.transform.position;
        Vector3 speedPowerUpX5Position = speedPowerUpX5.transform.position;

        //Act1
        //Waiting for player to collect speedPowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpX2Position);
        speedPowerUpStatus = SceneSetUpTests.player.GetSpeedPowerStatusText();

        //Assert1
        Assert.AreEqual("SpeedMultiplier is activated with multiplier: x2", speedPowerUpStatus.text);

        //Act2
        //Waiting for player to collect speedPowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpX3Position);
        speedPowerUpStatus = SceneSetUpTests.player.GetSpeedPowerStatusText();

        //Assert2
        Assert.AreEqual("SpeedMultiplier is activated with multiplier: x5", speedPowerUpStatus.text);

        //Act3
        //Waiting for player to collect speedPowerUp
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpX5Position);
        speedPowerUpStatus = SceneSetUpTests.player.GetSpeedPowerStatusText();

        //Assert3
        Assert.AreEqual("SpeedMultiplier is activated with MAX multiplier: x10", speedPowerUpStatus.text);
    }
    [UnityTest]
    public IEnumerator CC05_Testiranje_CoinPowerUp_multipliera_duration()
    {
        //Arrange
        PowerUp coinPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        Vector3 coinPowerUpX2Position = coinPowerUpX2.transform.position;
        
        //Act
        //Wait for player to collect coin power up
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(coinPowerUpX2Position);
        //wait 10 seconds because duration of power up lasts 10sec
        yield return new WaitForSeconds(10);
        Text coinPowerUpStatus = SceneSetUpTests.player.GetCoinPowerStatusText();

        //Assert
        Assert.AreEqual(" ", coinPowerUpStatus.text);
    }
    [UnityTest]
    public IEnumerator CC06_Testiranje_DamagePowerUp_multipliera_duration()
    {
        //Arrange
        PowerUp damagePowerUpX2 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        Vector3 damagePowerUpX2Position = damagePowerUpX2.transform.position;

        //Act
        //Wait for player to collect damage power up
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(damagePowerUpX2Position);
        //wait 5 seconds because duration of power up lasts 5sec
        yield return new WaitForSeconds(5);
        Text damagePowerUpStatus = SceneSetUpTests.player.GetDamagePowerStatusText();

        //Assert
        Assert.AreEqual(" ", damagePowerUpStatus.text);
    }
    [UnityTest]
    public IEnumerator CC07_Testiranje_SpeedPowerUp_multipliera_duration()
    {
        //Arrange
        PowerUp speedPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        Vector3 speedPowerUpX2Position = speedPowerUpX2.transform.position;

        //Act
        //Wait for player to collect speed power up
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpX2Position);
        //wait 7 seconds because duration of power up lasts 7sec
        yield return new WaitForSeconds(7);
        Text speedPowerUpStatus = SceneSetUpTests.player.GetSpeedPowerStatusText();

        //Assert
        Assert.AreEqual(" ", speedPowerUpStatus.text);
    }
    [UnityTest]
    public IEnumerator CC08_Testiranje_DamagePowerUp_multipliera_effect()
    {
        //Arrange
        PowerUp damagePowerUpX2 = GameObject.Instantiate(SceneSetUpTests.DamagePowerUpX2, new Vector3(3, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        Collider damagePowerUpX2Collider = damagePowerUpX2.GetComponent<Collider>();
        Vector3 damagePowerUpX2Position = damagePowerUpX2.transform.position;

        Enemy enemyLv2 = GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(10, 1, 0), Quaternion.identity).GetComponent<Enemy>();
        Collider enemyLv2Collider = enemyLv2.GetComponent<Collider>();

        //Act
        //Wait for player to collect speed power up
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(damagePowerUpX2Position);

        // Waiting for player to rotate to enemy
        yield return SceneSetUpTests.WaitForPlayerToRotateToTarget(enemyLv2Collider, enemyLv2.transform.position);

        //Waiting for player to shoot
        yield return SceneSetUpTests.WaitForPlayerToShoot();
        //Waiting for enemy to die
        yield return new WaitUntil(() => enemyLv2 == null);
        //Assert
        Assert.IsTrue(enemyLv2 == null);
    }
    [UnityTest]
    public IEnumerator CC09_Testiranje_SpeedPowerUp_multipliera_effect()
    {
        //Arrange
        PowerUp speedPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX2, new Vector3(2, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        Vector3 speedPowerUpX2Position = speedPowerUpX2.transform.position;
        float powerUpDuration = speedPowerUpX2.GetDurationInfo();
        float powerUpPositionX = speedPowerUpX2.transform.position.x;
        float powerUpMultiplier = speedPowerUpX2.GetMultiplierInfo();

        float playerStartSpeed = SceneSetUpTests.player.GetStartSpeed();

        //Act1
        //Wait for player to collect speed power up
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpX2Position);      
        float powerUpSpeed = SceneSetUpTests.player.GetRealSpeed();

        //Assert1
        Assert.AreEqual(powerUpMultiplier * playerStartSpeed, powerUpSpeed);

        //Act2
        InputManagerController.SetAxis("Horizontal", 1);
        //Power up lasts 7 seconds
        yield return new WaitForSeconds(powerUpDuration);
        InputManagerController.SetAxis("Horizontal", 0);
        float endSpeed = SceneSetUpTests.player.GetRealSpeed();
        float playerPosition = SceneSetUpTests.player.transform.position.x;

        //Assert2
        Assert.Less(playerPosition - powerUpPositionX, powerUpSpeed * powerUpDuration +1);
        Assert.Greater(playerPosition - powerUpPositionX, powerUpSpeed * powerUpDuration - 1);
        Assert.AreEqual(playerStartSpeed, endSpeed);
    }
    [UnityTest]
    public IEnumerator CC10_Testiranje_CoinPowerUp_multipliera_PLAYER_effect()
    {
        //Arrange
        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab, new Vector3(10, 1, 0), Quaternion.identity).GetComponent<Enemy>();
        Collider enemyLv1Collider = enemyLv1.GetComponent<Collider>();
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX2, new Vector3(1, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX3, new Vector3(2, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(3, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5, new Vector3(4, 1, 0), Quaternion.identity);
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX2, new Vector3(5, 1, 0), Quaternion.identity);

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
        Text scoreText = SceneSetUpTests.player.GetScoreText();
        Assert.AreEqual("Score: 17", scoreText.text);
    }
    [UnityTest]
    public IEnumerator CC11_Testiranje_CoinPowerUp_multipliera_ENEMY_effect()
    {
        //Arrange
        PowerUp coinPowerUpx2 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX2, new Vector3(6, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX3, new Vector3(8, 1, 0), Quaternion.identity);
        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab, new Vector3(10, 1, 0), Quaternion.identity).GetComponent<Enemy>();
        Collider enemyLv1Collider = enemyLv1.GetComponent<Collider>();

        //Act
        //Wait until further power up is picked up
        yield return new WaitUntil(() => coinPowerUpx2 == null);

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
        Text scoreText = GameObject.FindObjectOfType<Player>().GetScoreText();

        //Assert
        Assert.AreEqual("Score: 5", scoreText.text);
    }
    [UnityTest]
    public IEnumerator CC12_Testiranje_velikog_broja_speed_Power_upova_PLAYER()
    {
        //Arrange
        GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX5, new Vector3(2, 1, 0), Quaternion.identity);
        PowerUp speedPowerUpx52 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX5, new Vector3(4, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        PowerUp speedPowerUpx2 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX2, new Vector3(10, 1, 0), Quaternion.identity).GetComponent<PowerUp>();

        Vector3 speedPowerUpx52Position = speedPowerUpx52.transform.position;
        Vector3 speedPowerUpx2Position = speedPowerUpx2.transform.position;

        //Act1
        //Wait for player to collect speedPowerUpx52
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpx52Position);
        Text speedPowerUpStatus = SceneSetUpTests.player.GetSpeedPowerStatusText();

        //Assert1
        Assert.AreEqual("SpeedMultiplier is activated with MAX multiplier: x10", speedPowerUpStatus.text);

        //Act2
        //Wait for player to collect speedPowerUpx2
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(speedPowerUpx2Position);
        speedPowerUpStatus = SceneSetUpTests.player.GetSpeedPowerStatusText();

        //Assert2
        Assert.AreEqual("SpeedMultiplier is activated with MAX multiplier: x10", speedPowerUpStatus.text);
    }
    [UnityTest]
    public IEnumerator CC13_Testiranje_kretnji_Enemy_a_pod_speed_power_up_om()
    {
        //Arrange

        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab, new Vector3(50, 1, 0), Quaternion.identity).GetComponent<Enemy>();
        GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX5, new Vector3(50, 1, 0), Quaternion.identity).GetComponent<PowerUp>();
        GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX5, new Vector3(50, 1, 0), Quaternion.identity).GetComponent<PowerUp>();

        //Act
        //Waiting for 3 seconds because enemyLv1 power uped speed is 20, player position is (0,1,0) and enemy position is (50,1,0)
        yield return new WaitForSeconds(3);
        float distance = Vector3.Distance(enemyLv1.transform.position, SceneSetUpTests.player.transform.position);

        //Assert
        Assert.Greater(distance, 2);
        Assert.Less(distance, 3f);
    }
    #endregion
}
