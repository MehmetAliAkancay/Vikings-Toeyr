using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    #region public variables
    public float attackDistance;
    public float timer;
    public Transform rightLimit;
    public Transform leftLimit;
    [HideInInspector]public Transform target;
    [HideInInspector]public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    public bool amIDead;
    #endregion

    #region private variables
    private Animator animator;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    #endregion
   private Enemy()
    {
        hp = 100;
        atackPower = 10;
        defence = 100;
        jumpAmount = 5;
        speedAmount = 3;
    }

    SpriteRenderer render;
    Rigidbody2D rb;
    Collider2D enemyCollider;
    private void Awake()
    {
        SelectTarget();
        intTimer = timer;
        animator = GetComponent<Animator>();
        render = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(!attackMode)
        {
            Move();
        }

        if(!InsideOfLimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            SelectTarget();
        } 

        if(inRange)
        {
            EnemyLogic();
        }
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
         
        if (cooling)
        {
            Cooldown();
            animator.SetBool("Attack", false);
        }
            
    }
    void Move()
    {
        animator.SetBool("canWalk", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speedAmount * Time.deltaTime);
        }
    }
    void Attack()
    {
        timer = intTimer;   //reset timer when Player enter attack range
        attackMode = true;   //to check if Enemy can still attack or not

        animator.SetBool("canWalk", false);
        animator.SetBool("Attack", true);
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
    }
    void Cooldown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
    
    private bool InsideOfLimits()
    {
        return transform.position.x>leftLimit.position.x && transform.position.x<rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
            target = leftLimit;
        else
            target = rightLimit;
        Flip();
    }
    public void Flip()
    {
        if(!amIDead)
        {
            Vector3 rotation = transform.eulerAngles;
            if (transform.position.x > target.position.x)
                rotation.y = 180f;
            else
                rotation.y = 0f;
            transform.eulerAngles = rotation;
        }
        
    }
    internal void EnemyTakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            EnemyDie();
            amIDead = true;
        }
        else
        {
            StartCoroutine(DamageFade());
        }
    }
    IEnumerator DamageFade()
    {
        render.color = Color.red;
        yield return new WaitForSecondsRealtime(0.4f);
        render.color = Color.white;
    }
    private void EnemyDie()
    {
        render.color = Color.black;
        rb.gravityScale = 0;
        enemyCollider.enabled = false;
        animator.enabled = false;
        this.enabled = false;
    }
}

