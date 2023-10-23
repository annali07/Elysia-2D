using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    public float maxVelocity = 22f;

    private float movementX;

    //[SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "isWalk";
    private string JUMP_ANIMATION = "isJump";

    private bool isGrounded = true;
    private string GROUND = "Ground";
    private string ENEMY = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }


    private void FixedUpdate()
    {
        
        //called every 0.02 seconds
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        //value will be -1 for a and +1 for d key
        //GetAxis() goes from 0 to 0.1 to 0.2 to ... 0.9 1
        //3D getaxis, 2D getraw is enough

        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;
        //time.delta time is time between each frame (very small value)


       //Debug.Log("value is: " + movementX);
    }




    void AnimatePlayer()
    {

        myBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (movementX > 0) //going to right
        {
            anim.SetBool(WALK_ANIMATION, true);
            
            sr.flipX = false;

        }
        else if(movementX<0) //going to left
        {
            anim.SetBool(WALK_ANIMATION, true);
            
            sr.flipX=true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    

    }

    void PlayerJump()
    {   //Jump is predefined by Unity 
        //will utilize keys on platform (platform neutral)
        //space for pc 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            //getbuttonUp only returns true when the button is let go
            //getbutton returns 2 console log, press and hold, called all the time
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIMATION, true);
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded=true;
            anim.SetBool(JUMP_ANIMATION, false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            StartCoroutine(end());
        }

        
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("EndScene", LoadSceneMode.Additive);
     
    }

}









