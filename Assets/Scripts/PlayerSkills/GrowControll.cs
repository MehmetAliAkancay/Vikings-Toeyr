using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowControll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            FindObjectOfType<PlayerGetSmall>().headCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            FindObjectOfType<PlayerGetSmall>().headCheck = false;
        }
    }
}
