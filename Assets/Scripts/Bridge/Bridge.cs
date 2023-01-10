using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;
    public float speed = 3f;
    private bool isMovingForward = true;
    private bool isStarted = false;
    private void Start()
    {
        StartMovement();
    }
    void Update()
    {
        if (isStarted)
        {
            if (isMovingForward)
            {
                transform.position = Vector3.MoveTowards(transform.position, endTransform.position, speed * Time.deltaTime);
                if (transform.position == endTransform.position)
                {
                    isMovingForward = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startTransform.position, speed * Time.deltaTime);
                if (transform.position == startTransform.position)
                {
                    isMovingForward = true;
                }
            }
        }
    }
    public void StartMovement()
    {
        isStarted = true;
    }
    public void StopMovement()
    {
        isStarted = false;
    }
}
