using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject thunderPrefab;

    private float minX = -2.6f;
    private float maxX = 2.6f;

    void Start()
    {
        StartCoroutine(SpawnThunder());
    }

   
    IEnumerator SpawnThunder()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        Instantiate(thunderPrefab, new Vector2(Random.Range(minX, maxX), transform.position.y), Quaternion.identity);

        StartCoroutine(SpawnThunder());

    }
}
