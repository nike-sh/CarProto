using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public float maxEnemies;
    public float stopSpawningAt;
	public float totalEnemies;
    private float totalEnemiesKilled;
    GameObject EnemyCar;
    GameObject Car;
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
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    private int spawnChance = 4;
    private int randomSpawn;

    	
	void Start () {
        Enemy = EnemyCar.GetComponent<Enemy>();
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
        if (spawnTimer <= 0)
        {
            CheckMaxEnemies();
            spawnTimer = spawnTime;
        }
        else
            spawnTimer = spawnTimer - Time.deltaTime;

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
        else if (totalEnemies != maxEnemies)
        {
            Spawn();
            totalEnemies++;
        }
        else
            return;
    }

    void Spawn()
    {
        randomSpawn = Random.Range(0, spawnChance);

        if (randomSpawn == 0)
            Instantiate(enemy1, spawnPointOne.position, Quaternion.identity);
        else if (randomSpawn == 1)
            Instantiate(enemy2, spawnPointTwo.position, Quaternion.identity);
        else if (randomSpawn == 2)
            Instantiate(enemy3, spawnPointThree.position, Quaternion.identity);
        else if (randomSpawn == 3)
            Instantiate(enemy4, spawnPointFour.position, Quaternion.identity);
    }
}