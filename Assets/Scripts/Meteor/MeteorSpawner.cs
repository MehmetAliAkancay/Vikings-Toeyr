using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float meteorSpawnInterval = 0.5f; 
    public float meteorSpeed = 5f; 
    public float meteorSpread = 180f; 

    void Start()
    {
        InvokeRepeating("SpawnMeteor", 0, meteorSpawnInterval);
    }

    void SpawnMeteor()
    {
        float randomDegree = Random.Range(-meteorSpread / 2, meteorSpread / 2);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, randomDegree);

        GameObject meteor = Instantiate(meteorPrefab, transform.position, spawnRotation);
        meteor.SetActive(true);

        Rigidbody2D rb = meteor.GetComponent<Rigidbody2D>();
        rb.velocity = meteor.transform.up * meteorSpeed;
        Destroy(meteor,2);
    }
}
