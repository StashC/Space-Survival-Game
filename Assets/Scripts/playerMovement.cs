using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    //public float moveSpeed = 50;
    public float jumpSpeed = 50;
    public float downSpeed = 25;
    public float maxVertSpeed = 50;
    private bool canJump;
    private Vector3 mousePos;

    public float fallMultiplier = 2.5f;
    private float goDownTime;

    private Animator m_Anim;

    private Collider2D m_groundCollider;
    private Rigidbody2D m_rigidbody2D;
    private Collider2D m_collider;
    private Transform m_transform;

       private void Awake()
    {
        m_groundCollider = GetComponent<CircleCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<CircleCollider2D>();
        m_transform = GetComponent<Transform>();
        m_Anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "ground")
        {
            canJump = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        goDownTime -= Time.deltaTime;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_rigidbody2D.velocity = new Vector2(PlayerStats.instance.movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), m_rigidbody2D.velocity.y);
        
        if(Input.GetButton("Jump") && canJump == true)
        {
            m_rigidbody2D.velocity += new Vector2(0, jumpSpeed * Time.deltaTime);
        } 
        if(m_rigidbody2D.velocity.y < 0)
        {
            m_rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        
        //Vector3 frameMovement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0);
        if(mousePos.x < m_transform.position.x)
        {
            m_transform.localScale = new Vector3(-1, 1, 1);
        }   
        else if(mousePos.x > m_transform.position.x)
        {
            m_transform.localScale = new Vector3(1, 1, 1);
        }

      
        //Debug.Log(canJump);

        
    }
    void FixedUpdate()
    {
        m_Anim.SetBool("canJump", canJump);
        m_Anim.SetFloat("Speed", Mathf.Abs(m_rigidbody2D.velocity.x));
        //m_Anim.SetFloat("Speed", m_rigidbody2D.velocity.x);
    }
}
    












