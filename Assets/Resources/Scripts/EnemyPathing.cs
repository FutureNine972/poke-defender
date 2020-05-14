using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    EnemySpawner enemySpawner;
    WaveConfig waveConfig;
    [SerializeField] int shiny;
    [SerializeField] List<Transform> waypoints;
    int waypointIndex = 0;
    int pokemon = 0;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemySpawner = FindObjectOfType<EnemySpawner>();

        Sprite Charmander = Resources.Load<Sprite>("Sprites/Charmander");
        Sprite CharmanderShiny = Resources.Load<Sprite>("Sprites/CharmanderShiny");

        Sprite Squirtle = Resources.Load<Sprite>("Sprites/Squirtle");
        Sprite SquirtleShiny = Resources.Load<Sprite>("Sprites/SquirtleShiny");

        Sprite Bulbasaur = Resources.Load<Sprite>("Sprites/Bulbasaur");
        Sprite BulbasaurShiny = Resources.Load<Sprite>("Sprites/BulbasaurShiny");
        
        Sprite Caterpie = Resources.Load<Sprite>("Sprites/Caterpie");
        Sprite CaterpieShiny = Resources.Load<Sprite>("Sprites/CaterpieShiny");
        
        Sprite Weedle = Resources.Load<Sprite>("Sprites/Weedle");
        Sprite WeedleShiny = Resources.Load<Sprite>("Sprites/WeedleShiny");
        
        Sprite Pidgey = Resources.Load<Sprite>("Sprites/Pidgey");
        Sprite PidgeyShiny = Resources.Load<Sprite>("Sprites/PidgeyShiny");
        
        Sprite Rattata = Resources.Load<Sprite>("Sprites/Rattata");
        Sprite RattataShiny = Resources.Load<Sprite>("Sprites/RattataShiny");

        Sprite Spearow = Resources.Load<Sprite>("Sprites/Spearow");
        Sprite SpearowShiny = Resources.Load<Sprite>("Sprites/SpearowShiny");
        
        Sprite Ekans = Resources.Load<Sprite>("Sprites/Ekans");
        Sprite EkansShiny = Resources.Load<Sprite>("Sprites/EkansShiny");
        
        Sprite Pikachu = Resources.Load<Sprite>("Sprites/Pikachu");
        Sprite PikachuShiny = Resources.Load<Sprite>("Sprites/PikachuShiny");
        
        Sprite Mewtwo = Resources.Load<Sprite>("Sprites/Mewtwo");
        Sprite MewtwoShiny = Resources.Load<Sprite>("Sprites/MewtwoShiny");
        
        Sprite Mew = Resources.Load<Sprite>("Sprites/Mew");
        Sprite MewShiny = Resources.Load<Sprite>("Sprites/MewShiny");
        
        shiny = Random.Range(0, 256);
        if (shiny == 0)
        {
            if (enemySpawner.GetCurrentWaveNumber() == 1)
            {
                GetComponent<SpriteRenderer>().sprite = CharmanderShiny;
                pokemon = 1;
            }
            else if (enemySpawner.GetCurrentWaveNumber() == 2)
            {
                GetComponent<SpriteRenderer>().sprite = SquirtleShiny;
                pokemon = 2;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 3)
            {
                GetComponent<SpriteRenderer>().sprite = BulbasaurShiny;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 4)
            {
                GetComponent<SpriteRenderer>().sprite = CaterpieShiny;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 5)
            {
                GetComponent<SpriteRenderer>().sprite = WeedleShiny;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 6)
            {
                GetComponent<SpriteRenderer>().sprite = PidgeyShiny;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 7)
            {
                GetComponent<SpriteRenderer>().sprite = RattataShiny;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 8)
            {
                GetComponent<SpriteRenderer>().sprite = SpearowShiny;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 9)
            {
                GetComponent<SpriteRenderer>().sprite = EkansShiny;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 10)
            {
                GetComponent<SpriteRenderer>().sprite = PikachuShiny;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 11)
            {
                GetComponent<SpriteRenderer>().sprite = MewtwoShiny;
                pokemon = 4;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 12)
            {
                GetComponent<SpriteRenderer>().sprite = MewShiny;
                pokemon = 4;
            }
        }
        else
        {
            if (enemySpawner.GetCurrentWaveNumber() == 1)
            {
                GetComponent<SpriteRenderer>().sprite = Charmander;
                pokemon = 1;
            }
            else if (enemySpawner.GetCurrentWaveNumber() == 2)
            {
                GetComponent<SpriteRenderer>().sprite = Squirtle;
                pokemon = 2;
            }
            else if (enemySpawner.GetCurrentWaveNumber() == 3)
            {
                GetComponent<SpriteRenderer>().sprite = Bulbasaur;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 4)
            {
                GetComponent<SpriteRenderer>().sprite = Caterpie;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 5)
            {
                GetComponent<SpriteRenderer>().sprite = Weedle;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 6)
            {
                GetComponent<SpriteRenderer>().sprite = Pidgey;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 7)
            {
                GetComponent<SpriteRenderer>().sprite = Rattata;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 8)
            {
                GetComponent<SpriteRenderer>().sprite = Spearow;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 9)
            {
                GetComponent<SpriteRenderer>().sprite = Ekans;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 10)
            {
                GetComponent<SpriteRenderer>().sprite = Pikachu;
                pokemon = 0;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 11)
            {
                GetComponent<SpriteRenderer>().sprite = Mewtwo;
                pokemon = 4;
            }
             else if (enemySpawner.GetCurrentWaveNumber() == 12)
            {
                GetComponent<SpriteRenderer>().sprite = Mew;
                pokemon = 4;
            }
        }
    }

    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetPokemonValue()
    {
        return pokemon;
    }

}
