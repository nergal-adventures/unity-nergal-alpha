using System.Collections;
using UnityEngine;

namespace Game.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyShipPrefab;

        [SerializeField] private GameObject[] _powerUps;

        [SerializeField] private float enemySpawnRate = 5.0f;
        
        [SerializeField] private float powerUpSpawnRate = 5.0f;

        private GameManager _gameManager;
        
        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            StartCoroutine(SpawnEnemySpecificTime(enemySpawnRate));
            StartCoroutine(SpawnPowerUps(powerUpSpawnRate));
        }

        public void StartSpawnRoutines()
        {
            StartCoroutine(SpawnEnemySpecificTime(enemySpawnRate));
            StartCoroutine(SpawnPowerUps(powerUpSpawnRate));
        }
        
        private IEnumerator SpawnPowerUps(float spawnRate)
        {
            while (_gameManager.gameOver == false)
            {
                var randomPowerUpIndex = Random.Range(0, 3);
                var randomX = Random.Range(-9.0f, 9.0f);
                Instantiate(_powerUps[randomPowerUpIndex], new Vector3(randomX, 7.0f, 0), Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);    
            }
        }

        private IEnumerator SpawnEnemySpecificTime(float spawnRate)
        {
            while (_gameManager.gameOver == false)
            {
                var randomX = Random.Range(-9.0f, 9.0f);
                Instantiate(_enemyShipPrefab, new Vector3(randomX, 7.0f, 0), Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }
        }

    }
}