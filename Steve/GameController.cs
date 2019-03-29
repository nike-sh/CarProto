using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public float maxEnemies;
    public float stopSpawningAt;
	public float totalEnemies;
    private float totalEnemiesKilled;
    public GameObject carDown;
    public GameObject Car;
    PlayerHealth PlayerHealth;

    private bool gameStateOver;

    private bool gameOver;
    Enemy Enemy;

    public float spawnTime;
    private float spawnTimer;

    public int score;

    public Transform spawnPointOne;
    public Transform spawnPointTwo;
    public Transform spawnPointThree;
    public Transform spawnPointFour;
    public Transform spawnPointFive;
    public Transform spawnPointSix;
    public GameObject enemy;
    private int spawnChance = 36;
    private int randomSpawn;

    	
	void Start () {
        Enemy = carDown.GetComponent<Enemy>();
        PlayerHealth = Car.GetComponent<PlayerHealth>();
        gameOver = PlayerHealth.isPlayerOutOfLives;
        totalEnemiesKilled = Enemy.enemiesKilled;
        score = Enemy.currentScore;
        spawnTimer = spawnTime;
	}
	
	void Update () {
        PlayerHasLives();
        if (gameStateOver != false)
            GameOver();
        if (spawnTimer == 0)
        {
            CheckMaxEnemies();
            spawnTimer = spawnTime;
        }
        else
            spawnTimer -= Time.deltaTime;

        CheckKills();
        if (gameStateOver != false)
            GameOver();

    }

    void CheckKills()
    {
        if (totalEnemiesKilled < maxEnemies)
        {
            gameStateOver = false;
            return;
        }
        else
            gameStateOver = true;
    }
	
    void GameOver()
    {

    }

    void PlayerHasLives()
    {
        if (gameOver != false)
            gameStateOver = true;
        else
            gameStateOver = false;
    }

    void CheckMaxEnemies()
    {
        if (totalEnemies == maxEnemies && totalEnemiesKilled == stopSpawningAt)
            return;
        else
        {
            Spawn();
            totalEnemies++;
        }
    }

    void Spawn()
    {
        randomSpawn = Random.Range(0, spawnChance);

        if (randomSpawn > 0 && randomSpawn < 7)
            Instantiate(enemy, spawnPointOne.position, Quaternion.identity);
        else if (randomSpawn > 6 && randomSpawn < 13)
            Instantiate(enemy, spawnPointTwo.position, Quaternion.identity);
        else if (randomSpawn > 12 && randomSpawn < 19)
            Instantiate(enemy, spawnPointThree.position, Quaternion.identity);
        else if (randomSpawn > 18 && randomSpawn < 25)
            Instantiate(enemy, spawnPointFour.position, Quaternion.identity);
        else if (randomSpawn > 24 && randomSpawn < 31)
            Instantiate(enemy, spawnPointTwo.position, Quaternion.identity);
        else if (randomSpawn > 30 && randomSpawn <= 36)
            Instantiate(enemy, spawnPointTwo.position, Quaternion.identity);
    }
}