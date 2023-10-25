using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class Coin_Test_Cases 
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
    public IEnumerator CC01_Testiranje_silver_coina()
    {      
        #region Provjera silver coina
        //Arrange
        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab, new Vector3(10f, 1f, 0f), Quaternion.identity).GetComponent<Enemy>();
        Collider enemyLv1Collider = enemyLv1.GetComponent<Collider>();

        //Act
        //Waiting for player to rotate to enemy
        yield return SceneSetUpTests.WaitForPlayerToRotateToTarget(enemyLv1Collider, enemyLv1.transform.position);
        //Waiting for player to shoot
        yield return SceneSetUpTests.WaitForPlayerToShoot();

        // Wait until the coin is spawned from the enemy
        yield return new WaitUntil(() => GameObject.FindObjectOfType<Coin>() != null);
        Coin silverCoin = GameObject.FindObjectOfType<Coin>();
        Vector3 silverCoinPosition = silverCoin.transform.position;

        // Navigate the player towards the object     
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(silverCoinPosition);

        // Assert
        // Check if the score is updated
        Text scoreText = SceneSetUpTests.player.GetScoreText();
        Assert.AreEqual("Score: "+ SceneSetUpTests.SilverCoinValue(), scoreText.text);
        #endregion
    }
    [UnityTest]
    public IEnumerator CC02_Testiranje_gold_coina()
    {
        #region Provjera gold coina
        // Arrange
        Enemy enemyLv2 = GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab, new Vector3(10f, 1f, 0f), Quaternion.identity).GetComponent<Enemy>();
        Collider enemyLv2Collider = enemyLv2.GetComponent<Collider>();
        Shooting shooting = SceneSetUpTests.player.GetComponent<Shooting>();

        //Act
        //Waiting for player to rotate to enemy
        yield return SceneSetUpTests.WaitForPlayerToRotateToTarget(enemyLv2Collider, enemyLv2.transform.position);

        yield return SceneSetUpTests.WaitForPlayerToShoot();
        float realShootFreq = shooting.GetRealShootFrequency();
        // Wait for shoot frequency of a player to shoot again
        yield return new WaitForSeconds(realShootFreq);
        // Shoot at the enemy
        yield return SceneSetUpTests.WaitForPlayerToShoot();

        // Wait until the coin is spawned from the enemy
        yield return new WaitUntil(() => GameObject.FindObjectOfType<Coin>() != null);
        Coin goldCoin = GameObject.FindObjectOfType<Coin>();

        // Navigate the player towards the coin
        yield return SceneSetUpTests.WaitForPlayerToMoveTowardsPoint(goldCoin.transform.position);

        // Assert
        // Check if the score is updated
        Text scoreText = SceneSetUpTests.player.GetScoreText();
        Assert.AreEqual("Score: " + SceneSetUpTests.GoldCoinValue(), scoreText.text);
        #endregion
    }
    #endregion
}
