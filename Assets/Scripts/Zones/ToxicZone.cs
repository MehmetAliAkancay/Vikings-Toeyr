using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZone : MonoBehaviour
{
    public int toxicDamage = 5;
    private float nextDamageTime = 0f;
    private float nextDamageCooling = 1f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Time.time>=nextDamageTime)
            {
                FindObjectOfType<Player>().PlayerTakeDamage(toxicDamage);
                nextDamageTime = Time.time + nextDamageCooling;
            }
        }
    }
}
