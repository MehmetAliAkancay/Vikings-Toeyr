using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player p = collider.gameObject.GetComponent<Player>();
        if (p != null)
        {
            p.transform.SetPositionAndRotation(new Vector3(0f, -3.86f, 0f), Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
