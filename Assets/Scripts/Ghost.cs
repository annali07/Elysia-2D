using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
   // [HideInInspector]
    public float speed;
    public new Rigidbody2D gameObject;
    public Transform move;
    Animator anim;
    public AnimationCurve myCurve;
    private Vector3 StartPoint;

    // Start is called before the first frame update
    void Awake()
    {
        gameObject = GetComponent<Rigidbody2D>();
        move = GetComponent<Transform>();
        anim = GetComponent<Animator>();
     }

    private void Start()
    {
        anim.SetBool("isFloat", true);
        //  myBody.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameObject) return;
        
        move.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
        gameObject.velocity = anim.deltaPosition / Time.deltaTime; //solved root problem

   //     myBody.velocity = new Vector2(speed, myBody.velocity.y);

       // transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            anim.SetBool("isCatch", true);
            // gameObject.velocity = Vector3.zero;
            //move.position = Vector3.zero;
            speed = 0f;
        }

        if (collision.gameObject.CompareTag("GameController"))
        {
           Destroy(gameObject); //this.
            
            
        }

    }

    public void f()
    {

    }




}
