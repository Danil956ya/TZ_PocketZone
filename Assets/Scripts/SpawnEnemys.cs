using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject[] EnemyTypes;

    void Start()
    {
        CircleCollider2D spawnAria = GetComponent<CircleCollider2D>();
        for (int i = 0; i < 3; i++)
        {
            var point = spawnAria.transform.InverseTransformPoint(new Vector3(Random.value * 2 - 1, Random.value * 2 - 1, Random.value * 2 - 1));
            Instantiate(EnemyTypes[0], point, Quaternion.identity);
        }
    }
}
