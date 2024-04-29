using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private float ballInterval = 4f;

    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    public Transform spawnPosition4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(ballInterval, ballPrefab));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, spawnPosition1.position, Quaternion.identity);
    
        GameObject newEnemy2 = Instantiate(enemy, spawnPosition2.position, Quaternion.identity);

        GameObject newEnemy3 = Instantiate(enemy, spawnPosition3.position, Quaternion.identity);

        GameObject newEnemy4 = Instantiate(enemy, spawnPosition4.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
