using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	//Enemy stat variables
	public float speed;
	public float enemyHealth;
	private float currentHealth;
	public float enemyDamage;
	//Enemy movement variables
	public float followDistance;
	public float stoppingDistance;
	public Transform[] patrolPoints;
	private int patrolSpots;
	private NavMeshAgent agent;
	//Enemy attack variables
	public float attackDistance;
	public float startAttackRate;
	private float attackRate;
	//Enemy Target, Projectile & FirePoint
	private Transform player;
	public Transform projectile;
	public Transform firePoint;
	//Dropped Items
	public Transform spawnPowerUp;
    public GameObject powerUpOne;
    public GameObject powerUpTwo;
    public GameObject powerUpThree;
    public GameObject powerUpFour;
    private int powerUpChance = 20;
    private int dropChance;

    public int enemiesKilled;

    private int willEnemyRam = 1;
    private int enemyRams;

    public GameObject Car;
    PlayerHealth PlayerHealth;
    public GameObject gameController;
    GameController GameController;
    public int currentScore;
    private float health;
    private float totalEnemies;

    	
	// Use this for initialization
	void Start () {
        enemyRams = Random.Range(0, willEnemyRam);

		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = false;
		currentHealth = enemyHealth;
		attackRate = startAttackRate;
		player = GameObject.FindGameObjectWithTag("Car").GetComponent<Transform>();
		GoToNextPoint();
        GameController = gameController.GetComponent<GameController>();
        currentScore = GameController.score;
        health = PlayerHealth.currentHealth;

        totalEnemies = GameController.totalEnemies; 
    }
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position, player.position) > followDistance)
			GoToNextPoint();

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) <= followDistance)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && enemyRams == 0)
            transform.position = this.transform.position;
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && enemyRams == 1)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.position) <= attackDistance && attackRate == 0){
			EnemyAttack();
			attackRate = startAttackRate;
		}
		else
			attackRate -= Time.deltaTime;
		
		if(currentHealth <= 0){
			SpawnPowerUps();
            enemiesKilled += 1;
            totalEnemies--;
			Death();
		}
			
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
            health -= enemyDamage;
        }
    }

    void GoToNextPoint(){
		if(patrolPoints.Length == 0)
			return;
		
		agent.destination = patrolPoints[patrolSpots].position;
		
		patrolSpots = (patrolSpots + 1) % patrolPoints.Length;
	}
	
	void EnemyAttack(){
        Instantiate(projectile, firePoint.position, Quaternion.identity);
	}

	void SpawnPowerUps(){
		dropChance = Random.Range(0, powerUpChance);
		if(dropChance >= 1 && dropChance < 6)
			Instantiate(powerUpOne, spawnPowerUp.position, Quaternion.identity);
		else if(dropChance >= 6 && dropChance < 11)
			Instantiate(powerUpTwo, spawnPowerUp.position, Quaternion.identity);
		else if(dropChance >= 11 && dropChance < 16)
			Instantiate(powerUpThree, spawnPowerUp.position, Quaternion.identity);
		else if(dropChance >= 16 && dropChance < 20)
			Instantiate(powerUpFour, spawnPowerUp.position, Quaternion.identity);
		else if(dropChance == 0)
			return;
		}
	
	void Death(){
        currentScore += 100;
        
		GameObject.Destroy(gameObject);
	}
}
