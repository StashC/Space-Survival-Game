using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletVelocity;
    public Rigidbody2D m_rigidbody2D;
    public Transform m_transform;


    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_transform = GetComponent<Transform>();
        m_rigidbody2D.velocity = new Vector2(0, 0);

      

    }

    private void Awake()
    {
        
    }
    
    // Update is called once per frame
    void Update () {
        m_transform.Translate(Vector2.right * Time.deltaTime * bulletVelocity);
     }
}
