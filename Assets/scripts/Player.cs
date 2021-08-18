using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // public variables 
    Rigidbody2D playerRB;
    public float speed;
    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpForce;
    public float xMin, xMax, yMin, yMax;
    public Dialog DialogManager;
    public float timeRemaining = 10;
    public Object bulletRef;
    public GameObject menu;
    public UIInventory uIInventory;
    public Inventory inventoryManager;
    public AudioSource collect;
    public AudioSource walking;
    public AudioSource inventory;
    public GameObject fire;
    public AudioSource breaking;

    // private variables 
    private float moveInput;
    private bool isGrounded;
    private bool isIronNear = false;
    private bool firstIron = true;
    private GameObject nearsIron;
    private Animator anim;
    private SpriteRenderer sr;
    private Health myScript;


    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("Bullet");
        myScript = GetComponent<Health>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        Transform childTransform = transform.Find("Fire Point");



    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CheckIfGrounded();
        GetIron();
        openMnue();
        Flip();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining < 0 && moveInput == 0)
        {

            anim.SetBool("isIdle", true);
        }
        else { 
           
        }

        // Shooting Animation
        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("Shooting");
            
        }

        if (myScript.health <= 0)
        {

            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(moveInput * speed, playerRB.velocity.y);
        playerRB.gravityScale *= 1;
        sr.flipX = moveInput < 0;
        walking.Play();


        clamp();

        if (moveInput == 0)
        {
            anim.SetBool("isWalking", false);
        }  
        else {
            anim.SetBool("isWalking", true);
        }
    }

    void Jump()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);

        }
    }
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);

        if (collider != null)
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isJumping", true);
        }
    }
    void clamp()
    {
        float clampX = Mathf.Clamp(playerRB.position.x, xMin, xMax);
        float clampY = Mathf.Clamp(playerRB.position.y, yMin, yMax);
        playerRB.position = new Vector2(clampX, clampY);


    }
    void GetIron()
    {
        if (Input.GetKeyDown(KeyCode.E) && isIronNear)
        {

            if (firstIron)
            {
            string[] newDialog = { "you have iron now!, collect some iron so you can buy a weapon from the shop" };
            DialogManager.changeTheDialog(newDialog: newDialog);
            firstIron = false;
            }
            inventoryManager.GiveAnItem(1);
            Destroy(nearsIron);
            collect.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Iron")
        {
            if (firstIron)
            {
                string[] newDialog = { "there is iron near you, press ( E ) " };
                DialogManager.changeTheDialog(newDialog: newDialog);

            }
            else
            {
                string[] newDialog = { "press ( E ) " };
                DialogManager.changeTheDialog(newDialog: newDialog);
            }

            isIronNear = true;
            nearsIron = collision.gameObject;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            myScript.health -= 1;
            breaking.Play();
        }

        if (collision.gameObject.tag == "Lazer")
        {
            myScript.health -= 1;
            breaking.Play();
        }

        if (collision.gameObject.tag == "Spikes")
        {
            myScript.health -= 4;
            breaking.Play();
        }
        if (collision.gameObject.tag == "Easy Enemy")
        {
            myScript.health -= 1;
            breaking.Play();
        }
       
    }


    private void openMnue()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            //int time = menu.active ? 0 : 1;
            //Time.timeScale = 0;
            //menu.active ? uIInventory.updateUI(inventoryManager.GetTheArray())
            menu.SetActive(!menu.active);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && menu.active)
        {
            uIInventory.updateUI(inventoryManager.GetTheArray());
        }
    }

    void Flip()
    {
        Transform childTransform = transform.Find("Fire Point");
        if (moveInput == 0 && moveInput < 0)
        {
            transform.Rotate (0f, 180f, 0f);
            
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Iron")
        {
            isIronNear = false;
        }
       
    }


   
}
