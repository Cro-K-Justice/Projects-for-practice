using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameManager))]
public class Player : Character
{
    #region Test region
    public Text GetHealthText()
    {
        return healthText;
    }
    public Text GetScoreText()
    {
        return scoreText;
    }
    public Text GetCanShootText()
    {
        return canShootText;
    }
    public Text GetSpeedPowerStatusText()
    {
        return speedPowerStatus;
    }
    public Text GetDamagePowerStatusText()
    {
        return damagePowerStatus;
    }
    public Text GetCoinPowerStatusText()
    {
        return coinPowerStatus;
    }
    public Text GetGameOverText()
    {
        return gameOverText;
    }
    public int GetScoreInfo()
    {
        return score;
    }
    public int GetWinScoreInfo()
    {
        return winScore;
    }
    #endregion

    private int score = 0;
    [SerializeField]
    private int winScore = 100;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text speedPowerStatus;
    [SerializeField]
    private Text damagePowerStatus;
    [SerializeField]
    private Text coinPowerStatus;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text canShootText;
    [SerializeField]
    private GameManager gameManager;

    private void Awake()
    {
        gameObject.tag = "Player";
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
        speedPowerStatus.text = " ";
        damagePowerStatus.text = " ";
        coinPowerStatus.text = " ";
        gameManager = GetComponent<GameManager>();
    }
    protected override void Start()
    {
        base.Start();
        shooting.SetRealShootFrequency(0f);
    }
    protected void Update()
    {
        if (gameManager.GameState == EGameState.Paused) return;

        if (shooting.CanShoot())
        {
            canShootText.text = "You can shoot!";
            canShootText.color = Color.green;

            if (InputManagerController.GetMouseButtonDown(0))
            {
                shooting.Shoot(realDamage);
            }
        }
        else
        {
            canShootText.text = "You cant shoot!";
            canShootText.color = Color.red;
        }
    }

    private void FixedUpdate()
    {
        InputHandling();
        PlayerRotation();  
    }
    private void PlayerRotation()
    {
        Quaternion currentRotation = transform.rotation;
        Vector3 mousePos = InputManagerController.GetMousePosition();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(targetPosition);
        }
        else
        {
            transform.rotation = currentRotation;
        }
    }
    public void AddScore(int value)
    {
        score += (value * sumCoinMultiplier);
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
        if (score >= winScore) 
        {
            GameOver(true);
        }
    }
    private void PlayerMovement(float horizontal, float vertical)
    {
        rb.velocity = new Vector3(horizontal, 0, vertical).normalized * realSpeed;
    }
    private void InputHandling()
    {
        float horizontal = InputManagerController.GetAxis("Horizontal");
        float vertical = InputManagerController.GetAxis("Vertical");

        PlayerMovement(horizontal, vertical);
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        healthText.text = "Health: " + health;
        if(health <= 0)
        {
            GameOver(false);
        }
    }
    private void GameOver(bool win)
    {
        Time.timeScale = 0;
        gameManager.GameState = EGameState.Paused;
        gameOverText.gameObject.SetActive(true);
        canShootText.text = " ";
        if (win) 
        {
            gameOverText.text = "GAME WON";
            gameOverText.color = Color.blue;
        }
        else 
        {
            gameOverText.text = "GAME OVER";
        }
    }
    public void SetSpeedPowerStatus(string text)
    {
        speedPowerStatus.text = text;
    }
    public void SetDamagePowerStatus(string text)
    {
        damagePowerStatus.text = text;
    }
    public void SetCoinPowerStatus(string text)
    {
        coinPowerStatus.text = text;
    }
}
