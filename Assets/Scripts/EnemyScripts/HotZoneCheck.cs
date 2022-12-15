using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private Enemy enemy;
    private bool inRange;
    private Animator animator;
    private void Awake()
    {
        enemy=GetComponentInParent<Enemy>();
        animator=GetComponentInParent<Animator>();
    }

    private void Update()
    {    
        if(inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            enemy.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemy.triggerArea.SetActive(true);
            enemy.inRange = false;
            enemy.SelectTarget();
        }
    }
}
