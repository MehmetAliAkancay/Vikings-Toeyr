using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            FindObjectOfType<PlayerDash>().canIDash = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            FindObjectOfType<PlayerDash>().canIDash = true;
        }
    }
}
