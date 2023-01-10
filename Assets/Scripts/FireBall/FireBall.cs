using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private int fireBallDamage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Player>().PlayerTakeDamage(fireBallDamage);
            Destroy(gameObject);
        }
    }
}
