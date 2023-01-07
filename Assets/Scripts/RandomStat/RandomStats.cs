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
    private int returnStatsDelay = 5;
    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int rand = Random.Range(1, 4);

            if (rand == 1)
            {
                Debug.Log("hýz arttýrýldý");
                other.GetComponent<Player>().speedAmount += getSpeedAmount;
                StartCoroutine(ResetSpeed(other.gameObject, returnStatsDelay));
            }
            else if (rand == 2)
            {
                Debug.Log("can kazanýldý");
                other.GetComponent<Player>().hp = Mathf.Min(other.GetComponent<Player>().hp + getHp, playerMaxHp);
            }
            else if (rand == 3)
            {
                Debug.Log("attackpower arttýrýldý");
                other.GetComponent<Player>().atackPower += getAttackPower;
                StartCoroutine(ResetAttackPower(other.gameObject, returnStatsDelay));
            }
            Destroy(gameObject);
        }
    }
    IEnumerator ResetSpeed(GameObject player, float time)
    {
        yield return new WaitForSeconds(time);
        player.GetComponent<Player>().speedAmount -= getSpeedAmount;
    }
    IEnumerator ResetAttackPower(GameObject player, float time)
    {
        yield return new WaitForSeconds(time);
        player.GetComponent<Player>().atackPower -= getAttackPower;
    }
}

