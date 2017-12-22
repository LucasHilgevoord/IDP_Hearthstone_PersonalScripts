using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourTurn2 : MonoBehaviour {

    public Animation YourTurnAnim;

    void Start()
    {
        YourTurnAnim = GetComponent<Animation>();
    }

    void Awake()
    {
        YourTurnAnim.Play("YourTurnAnim");
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
