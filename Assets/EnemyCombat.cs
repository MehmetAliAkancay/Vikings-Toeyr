using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    Player player;
    Enemy enemy;
    public GameObject hitbox;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        enemy =GameObject.FindWithTag("Enemy").GetComponent<Enemy>();   
    }
    private void Update()
    {
        if(enemy.amIDead)
        {
            hitbox.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player.PlayerTakeDamage(enemy.atackPower);
        }
    }
}
