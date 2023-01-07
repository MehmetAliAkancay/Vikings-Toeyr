using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    private int slowAmount = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().speedAmount -=slowAmount;
            Debug.Log(other.GetComponent<Player>().speedAmount);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().speedAmount += slowAmount;
            Debug.Log(other.GetComponent<Player>().speedAmount);
        }
    }
}
