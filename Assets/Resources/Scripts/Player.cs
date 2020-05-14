using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xUpPadding = 0.1f;
    [SerializeField] float xDownPadding = 0.1f;
    [SerializeField] float yUpPadding = 1f;
    [SerializeField] float yDownPadding = 0.11f;
    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.25f;
    [Header("Sprite Determiner")]
    [SerializeField] int shiny;
    [Header("Health")]
    [SerializeField] int health = 300;
    [SerializeField] int damageValue = 1;
    [Header("Prefabs")]
    [SerializeField] GameObject explosionPrefab;
    [Header("Sound")]
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    Coroutine firingCoroutine;

    void Start()
    {
        var TyphlosionShiny = Resources.Load<Sprite>("Sprites/TyphlosionShiny");
        var Typhlosion = Resources.Load<Sprite>("Sprites/Typhlosion");
        SetUpMoveBoundaries();
        shiny = Random.Range(0, 256);
        if (shiny == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = TyphlosionShiny;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Typhlosion;
        }
    }

    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(RepeatFire());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator RepeatFire()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xUpPadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xDownPadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yUpPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yDownPadding;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        FindObjectOfType<GameSession>().SubtractFromHealth(damageValue);
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
        else
        {
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, 0.4f);
        FindObjectOfType<SceneLoader>().LoadLose();
    }

}