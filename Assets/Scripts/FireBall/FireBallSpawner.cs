using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{

    public GameObject fireballPrefab;
    public float spawnTime = 3f; 
    public float fireBallSpeed = 10f;

    void Start()
    {
        InvokeRepeating("SpawnFireball", 0f, spawnTime);
    }

    void SpawnFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(fireBallSpeed, 0);
        Destroy(fireball,2);
    }
}
