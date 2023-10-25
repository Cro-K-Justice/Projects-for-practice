using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EditTests
{
    [Test]
    public void CheckEnemyLv1Prefab()
    {
        Enemy enemyLv1 = GameObject.Instantiate(SceneSetUpTests.EnemyLV1Prefab).GetComponent<Enemy>();
        Shooting shootingEnemyLv1 = SceneSetUpTests.EnemyLV1Prefab.GetComponent<Shooting>();
        SpeedPowerUp speedPowerUpEnemyLv1 = SceneSetUpTests.EnemyLV1Prefab.GetComponent<SpeedPowerUp>();
        DamagePowerUp damagePowerUpEnemyLv1 = SceneSetUpTests.EnemyLV1Prefab.GetComponent<DamagePowerUp>();
        CoinPowerUp coinPowerUpEnemyLv1 = SceneSetUpTests.EnemyLV1Prefab.GetComponent <CoinPowerUp>();

        Assert.NotNull(enemyLv1);
        Assert.NotNull(shootingEnemyLv1);
        Assert.NotNull(speedPowerUpEnemyLv1);
        Assert.NotNull(coinPowerUpEnemyLv1);
        Assert.NotNull(damagePowerUpEnemyLv1);   
    }
    [Test]
    public void CheckEnemyLv2Prefab()
    {
        Enemy enemyLv2 = GameObject.Instantiate(SceneSetUpTests.EnemyLV2Prefab).GetComponent<Enemy>();
        Shooting shootingEnemyLv2 = SceneSetUpTests.EnemyLV2Prefab.GetComponent<Shooting>();
        SpeedPowerUp speedPowerUpEnemyLv2 = SceneSetUpTests.EnemyLV2Prefab.GetComponent<SpeedPowerUp>();
        DamagePowerUp damagePowerUpEnemyLv2 = SceneSetUpTests.EnemyLV2Prefab.GetComponent<DamagePowerUp>();
        CoinPowerUp coinPowerUpEnemyLv2 = SceneSetUpTests.EnemyLV2Prefab.GetComponent<CoinPowerUp>();

        Assert.NotNull(enemyLv2);
        Assert.NotNull(shootingEnemyLv2);
        Assert.NotNull(speedPowerUpEnemyLv2);
        Assert.NotNull(coinPowerUpEnemyLv2);
        Assert.NotNull(damagePowerUpEnemyLv2);
    }
    [Test]
    public void CheckPlayerPrefab()
    {
        Player player = GameObject.Instantiate(SceneSetUpTests.PlayerPrefab).GetComponent<Player>();
        Shooting shootingPlayer = SceneSetUpTests.PlayerPrefab.GetComponent<Shooting>();
        SpeedPowerUp speedPowerUpPlayer = SceneSetUpTests.PlayerPrefab.GetComponent<SpeedPowerUp>();
        DamagePowerUp damagePowerUpPlayer = SceneSetUpTests.PlayerPrefab.GetComponent<DamagePowerUp>();
        CoinPowerUp coinPowerUpPlayer = SceneSetUpTests.PlayerPrefab.GetComponent<CoinPowerUp>();
        GameManager gameManagerPlayer = SceneSetUpTests.PlayerPrefab.GetComponent<GameManager>();

        Assert.NotNull(player);
        Assert.NotNull(shootingPlayer);
        Assert.NotNull(speedPowerUpPlayer);
        Assert.NotNull(coinPowerUpPlayer);
        Assert.NotNull(damagePowerUpPlayer);
        Assert.NotNull(gameManagerPlayer);
    }
    [Test]
    public void CheckSpeedPowerUpsPrefabs()
    {
        PowerUp speedPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX2).GetComponent<PowerUp>();
        PowerUp speedPowerUpX3 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX3).GetComponent<PowerUp>();
        PowerUp speedPowerUpX5 = GameObject.Instantiate(SceneSetUpTests.SpeedPowerUpX5).GetComponent<PowerUp>();

        Assert.NotNull(speedPowerUpX2);
        Assert.NotNull(speedPowerUpX3);
        Assert.NotNull(speedPowerUpX5);
    }
    [Test]
    public void CheckDamagePowerUpsPrefabs()
    {
        PowerUp damagePowerUpX2 = GameObject.Instantiate(SceneSetUpTests.DamagePowerUpX2).GetComponent<PowerUp>();
        PowerUp damagePowerUpX3 = GameObject.Instantiate(SceneSetUpTests.DamagePowerUpX3).GetComponent<PowerUp>();
        PowerUp damagePowerUpX5 = GameObject.Instantiate(SceneSetUpTests.DamagePowerUpX5).GetComponent<PowerUp>();

        Assert.NotNull(damagePowerUpX2);
        Assert.NotNull(damagePowerUpX3);
        Assert.NotNull(damagePowerUpX5);
    }
    [Test]
    public void CheckCoinPowerUpsPrefabs()
    {
        PowerUp coinPowerUpX2 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX2).GetComponent<PowerUp>();
        PowerUp coinPowerUpX3 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX3).GetComponent<PowerUp>();
        PowerUp coinPowerUpX5 = GameObject.Instantiate(SceneSetUpTests.CoinPowerUpX5).GetComponent<PowerUp>();

        Assert.NotNull(coinPowerUpX2);
        Assert.NotNull(coinPowerUpX3);
        Assert.NotNull(coinPowerUpX5);
    }
    [Test]
    public void CheckCoinPrefabs()
    {
        Coin silverCoin = GameObject.Instantiate(SceneSetUpTests.SilverCoin).GetComponent<Coin>();
        Coin goldCoin = GameObject.Instantiate(SceneSetUpTests.GoldCoin).GetComponent<Coin>();

        Assert.NotNull(goldCoin);
        Assert.NotNull(silverCoin);
    }
    [Test]
    public void CheckSpawnerPrefab()
    {
        Spawner spawner = GameObject.Instantiate(SceneSetUpTests.SpawnerPrefab).GetComponent<Spawner>();

        Assert.NotNull(spawner);
    }

}
