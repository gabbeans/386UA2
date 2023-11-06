using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(spawnInterval, enemyPrefab));
    }

    private IEnumerator SpawnEnemy(float zInterval, GameObject enemyPrefab)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
