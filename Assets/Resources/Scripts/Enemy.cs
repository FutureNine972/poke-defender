using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Shooting/Stats")]
    [SerializeField] float health = 100f;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.5f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] float projectileSpeed = -5f;
    [SerializeField] int scoreValue = 150;

    [Header("Prefabs")]
    [SerializeField] GameObject firePrefab;
    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject grassPrefab;
    [SerializeField] GameObject psychicPrefab;
    [SerializeField] GameObject explosionPrefab;
    
    [Header("Sound")]
    [SerializeField] AudioClip deathSound;

    GameObject laser;
    EnemyPathing pokemon;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        pokemon = GetComponent<EnemyPathing>();
        if (pokemon.GetPokemonValue() == 1)
        {
            GameObject laser = Instantiate(firePrefab, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
        if (pokemon.GetPokemonValue() == 2)
        {
            GameObject laser = Instantiate(waterPrefab, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
        if (pokemon.GetPokemonValue() == 3)
        {
            GameObject laser = Instantiate(grassPrefab, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
        if (pokemon.GetPokemonValue() == 4)
        {
            GameObject laser = Instantiate(psychicPrefab, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(explosion, 0.4f);
        }
    }


}
