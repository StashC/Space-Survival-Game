using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// © 2017 TheFlyingKeyboard
// theflyingkeyboard.net
public class armRotation : MonoBehaviour
{
    private Vector3 difference;
    public float offset = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
        if (difference.x < 0)
        {
            transform.localScale = new Vector3(-1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        
        
        }
}