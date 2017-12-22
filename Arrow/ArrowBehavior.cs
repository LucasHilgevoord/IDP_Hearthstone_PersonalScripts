using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {

    int speed = 4;
    public Transform Fisch;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 1000, out hit))
        {
            //transform.LookAt(new Vector3(hit.point.x, hit.point.y, hit.point.z));
            transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            //pos = Input.mousePosition * Time.deltaTime;
            

        }
    }
}
