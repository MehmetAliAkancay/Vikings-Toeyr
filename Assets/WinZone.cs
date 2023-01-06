using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Player p = collider.gameObject.GetComponent<Player>();
        if (p != null)
        {
            FindObjectOfType<GameManager>().WinGame();
        }
    }
}
