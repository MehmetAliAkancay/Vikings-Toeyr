using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombat : MonoBehaviour
{
    #region public variables
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    #endregion

    #region private variables
    private float attackRange = 0.4f;
    private float attackRate = 2f;
    private float nextAttackTime= 0f;
    private Player player;
    #endregion

    private void Update()
    {
        Attacking();
    }
    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Attacking()   //attack animasyonu ve cooldown fonksiyonu
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack"); 
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    private void Attack()  //d��man e�er hitboxdaysa damage att�rmay� sa�layan fonksiyon.Animasyonda �a�r�l�yor
    {
        try
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().EnemyTakeDamage(player.atackPower); 
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    /*private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;                                             //attack yar��ap�n� �izen fonksiyon
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/
}