using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScore : MonoBehaviour {

    public string text;

    // Use this for initialization
    void Start () {
		
	}
	
    void Awake()
    {
        TextMesh textObject = this.GetComponent<TextMesh>();
        textObject.text = "1/1";
    }

	// Update is called once per frame
	void Update () {
        if (DragCard.PlacedCard)
        {
            TextMesh textObject = this.GetComponent<TextMesh>();
            textObject.text = "0/1";
        }
    }
}
