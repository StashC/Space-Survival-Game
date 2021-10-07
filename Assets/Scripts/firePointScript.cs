using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (difference.x < 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        }
        else
        {
            transform.localEulerAngles= new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        }



    }
}

