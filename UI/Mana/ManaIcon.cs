using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaIcon : MonoBehaviour {

    private SpriteRenderer spriteR;
    public Sprite Disable;

    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if (DragCard.PlacedCard)
        {
            spriteR.sprite = Disable;
        }
	}
}
