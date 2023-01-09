using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    Player player;
    Enemy enemy;
    private float nextDamageTime = 0f;
    public float nextDamageCooling = 1f;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy =GameObject.FindWithTag("Enemy").GetComponent<Enemy>();   
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(Time.time>=nextDamageTime)
            {
                player.PlayerTakeDamage(enemy.atackPower);
                nextDamageTime = Time.time+nextDamageCooling;
            }
           
        }
    }
}
