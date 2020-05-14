using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int waveForPokemon = 0;
    [SerializeField] bool looping = false;
    int startingWave = 0;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            if (waveForPokemon < 12)
            {
                waveForPokemon++;
            }
            else
            {
                waveForPokemon = 1;
            }
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            if (waveForPokemon == 12)
            {
                yield return new WaitForSeconds(30);
            }
            else
            {
                yield return new WaitForSeconds(3);
            }
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    public int GetCurrentWaveNumber() { return waveForPokemon; }

}
