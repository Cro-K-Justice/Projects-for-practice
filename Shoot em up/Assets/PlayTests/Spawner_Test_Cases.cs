using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Spawner_Test_Cases 
{
    #region Setup and Teardown
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return SceneSetUpTests.SetUp("MainScene");
    }
    [UnityTearDown]
    public IEnumerator TearDown()
    {
        yield return SceneSetUpTests.TearDown("EmptyScene");
    }
    #endregion

    #region Tests
    [UnityTest]
    public IEnumerator CC01_Testiranje_spawnera_da_li_stvara_enemye()
    {
        //Arrange
        Spawner spawner = GameObject.FindObjectOfType<Spawner>();

        //Act
        float spawnSpeed = spawner.GetSpawnSpeedInfo();
        //Waiting for 4 seconds 
        yield return new WaitForSeconds(spawnSpeed);

        //Assert
        Assert.NotNull(GameObject.FindGameObjectWithTag("Enemy"));       
    }
    #endregion
}
