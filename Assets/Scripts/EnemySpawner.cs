using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Use this for initialization
    void Start()
    {

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;

            //parent of enemy transform is the enemy formation transform, enemy because child of enemyformation
            enemy.transform.parent = child;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
