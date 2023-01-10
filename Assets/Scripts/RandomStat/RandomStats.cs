using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStats : MonoBehaviour
{
    #region deðiþkenler
    private float playerMaxHp = 100;
    private int getAttackPower = 5;
    private int getSpeedAmount = 2;
    private int getHp = 10;
    private float returnStatsDelay = 5f;
    public HealthBar health;
    public Collider2D collider;
    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int rand = Random.Range(1, 4);

            if (rand == 1)
            {
                StartCoroutine(ResetSpeed(other.gameObject,returnStatsDelay));
            }
            else if (rand == 2)
            {
                if(other.GetComponent<Player>().hp<playerMaxHp)
                {
                    other.GetComponent<Player>().hp += getHp;
                    health.SetHealth(other.GetComponent<Player>().hp);
                }
            }
            else if (rand == 3)
            {
                StartCoroutine(ResetAttackPower(other.gameObject,returnStatsDelay));
            }
            collider.enabled = false;
        }
    }
    IEnumerator ResetSpeed(GameObject player,float time)
    {
        player.GetComponent<Player>().speedAmount += getSpeedAmount;
        yield return new WaitForSeconds(time);
        player.GetComponent<Player>().speedAmount -= getSpeedAmount;
    }
    IEnumerator ResetAttackPower(GameObject player,float time)
    {
        player.GetComponent<Player>().atackPower += getAttackPower;
        yield return new WaitForSecondsRealtime(time);
        player.GetComponent<Player>().atackPower -= getAttackPower;
    }
}