using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerArea : MonoBehaviour
{
    private Enemy enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemy.target = collider.transform;
            enemy.inRange = true;
            enemy.hotZone.SetActive(true);
        }
    }
}
