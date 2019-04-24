using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {       

    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject[] powerups;

    private GameManager _gameManager;
    
    // Use this for initialization
    void Start () {
        
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());

    }
    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (_gameManager.gameOver == false) //_gameManager.gameOver == false
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-6f, 6f), 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    IEnumerator PowerupSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-6f, 6f), 6, 0), Quaternion.identity);            
            yield return new WaitForSeconds(5.0f);
        }
    }
}
