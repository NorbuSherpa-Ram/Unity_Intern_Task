using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float speed = 100f;
    public float jumpForce = 100f;
    public float knockBackForce = 100f;
    public float waterKnockBackForce = 100f;
    public Rigidbody2D playerRb;

    public Animator playerAnim;

    public PlayerHealth playerHealth;
    float hor;

    public int damage = 1;

    public GameObject groundCheck;
    public LayerMask whatIsGround;
    public float radious = 0.5f;
    public bool isGround;


    bool canJump = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.transform.position = GameController.checkPointPosition + new Vector2(0, 1);
    }

    void Update()
    {
        hor = Input.GetAxis("Horizontal");

        Vector2 move = new Vector2(hor * speed * Time.deltaTime, 0);
        playerRb.transform.Translate(move);

        playerAnim.SetFloat("speed", Mathf.Abs(hor));

        Flip();

        // Checking is he on the ground or not 
        isGround = Physics2D.OverlapCircle(groundCheck.transform.position, radious, whatIsGround);


        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
            AudioManager.instance.PlaySound("jump");
        }
        else if (!isGround)
        {
            canJump = false;
            playerAnim.SetBool("isJumped", false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            playerHealth.TakeDamage(damage);
        }

    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamageToPlayer(knockBackForce, collision.gameObject );
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            DamageToPlayer(waterKnockBackForce, collision.gameObject);
        }
    }
    void DamageToPlayer(float  knockForce , GameObject collision )
    {
        playerAnim.SetBool("hurt", true);
        playerHealth.TakeDamage(damage);
        playerRb.AddForce(knockForce * (transform.position - collision.gameObject.transform.position));
        Invoke("ResetAnim", 0.1f);
    }
    private void ResetAnim()
    {
         playerAnim.SetBool("hurt", false );
    }
    //Jump
    void Jump()
    {

        playerRb.velocity = (Vector2.up * jumpForce * Time.fixedDeltaTime);
        playerAnim.SetBool("isJumped", true);

    }

    void Flip()
    {
        Vector3 newScale = transform.localScale;
        if (hor < 0)
        {
            newScale.x = -1;
        }
        if (hor > 0)
        {
            newScale.x = 1;
        }
        transform.localScale = newScale;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.transform.position, radious);
    }
}
