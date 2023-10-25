using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class Projectile_Test_Cases 
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
    public IEnumerator CC01_Testiranje_unistavanja_projektila_nakon_10_sekundi_od_stvaranja()
    {
        //Arrange
        Shooting shooting = SceneSetUpTests.player.GetComponent<Shooting>();
        float projectileLifeSpan = shooting.GetprojectileLifeSpanInfo();

        //Act
        //Waiting for player to shoot
        yield return SceneSetUpTests.WaitForPlayerToShoot();
        //Waiting for projectile to destroy it self
        yield return new WaitForSeconds(projectileLifeSpan);
        Projectile projectile = GameObject.FindObjectOfType<Projectile>();

        //Assert
        Assert.IsTrue(projectile == null);
    }
    #endregion
}
