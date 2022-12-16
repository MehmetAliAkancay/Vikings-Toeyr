using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Character
{
    private Rigidbody2D rb;
    private Vector3 velocity;
    [SerializeField] Animator animator;
    private SpriteRenderer spriteRenderer;
    private Player()
    {
        hp = 20;
        atackPower = 30;
        defence = 100; 
        jumpAmount = 5;
        speedAmount = 5;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Movement();
        Jump();
    }
    public void PlayerTakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Debug.Log("GameOver");
            PlayerDie();
        }
        else
        {
            StartCoroutine(DamageFade());
            Debug.Log("Damage yiyorsun canýn:"+hp);
        }
    }
    private void Movement()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));       //yürüme animasyon koþulu saglandi
        transform.position += velocity * speedAmount * Time.deltaTime;     //karakterin hareket etmesi
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rb.velocity.y, 0) && !animator.GetBool("isJump"))   //karekter ziplamiyor ve space tuþuna basiliyorsa
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);        //karakterin ziplamasi 
            animator.SetBool("isJump", true);                                //animasyon ziplama koþulu saglandi
        }
        if (Input.GetAxisRaw("Horizontal") == -1)              //karekterin saga dogru bakmasi
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)         //karakterin sola dogru bakmasi
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    IEnumerator DamageFade()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSecondsRealtime(0.4f);
        spriteRenderer.color = Color.white;
    }
    private void PlayerDie()
    {
        spriteRenderer.color = Color.black;
        Time.timeScale = 0;
        rb.gravityScale = 0;
        animator.enabled = false;
        this.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Ground")
        {
            animator.SetBool("isJump" , false);        //karakterin zemin ile temas kontrolu
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            animator.SetBool("isJump", true);         //karakterin zemin ile temasini kesme kontrolu
        }
    }
}