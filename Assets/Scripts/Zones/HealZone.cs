using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    private int healAmount=5;
    private float nextHealTime = 0f;
    private Player player;
    public HealthBar healthBar;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void GetHeal()
    {
        if(Time.time>=nextHealTime)
        {
            player.hp += healAmount;
            player.hp = Mathf.Clamp(player.hp, 0, 100);
            nextHealTime = Time.time + 1f;
            healthBar.SetHealth(player.hp);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && player.hp < 100)
        {
            InvokeRepeating("GetHeal", 0f, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            CancelInvoke("GetHeal");
        }
    }
}