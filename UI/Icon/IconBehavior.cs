using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBehavior : MonoBehaviour {

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("CardIconPos2").transform.position, 40f * Time.deltaTime);
    }

}
