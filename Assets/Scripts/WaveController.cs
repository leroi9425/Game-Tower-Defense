using System.Globalization;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemiesPrefab;
    [SerializeField] private GameObject Gate;
    [SerializeField] private int indexEnemy;
    [SerializeField] private GameObject currentEnemy;

    [SerializeField] private float timeSpawn = 2.0f;
    [SerializeField] private float timer = 0f;

    private void Start()
    {
        indexEnemy = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeSpawn)
        {
            spawnEnemies();
            timer = 0f;
        }

    }
    public void spawnEnemies()
    {
        if(indexEnemy >= EnemiesPrefab.Length)
        {
            return;
        }
        currentEnemy = EnemiesPrefab[indexEnemy];
        Instantiate(currentEnemy, Gate.transform.position, Gate.transform.rotation);
        indexEnemy++;
    }
}
