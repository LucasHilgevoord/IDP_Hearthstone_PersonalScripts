using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnBehavior : MonoBehaviour {

    public static bool NextTurnActive = false;
    public Animation ButtonClick;
    private bool FischAttacked = true;
    public Texture2D CursorLoad;
    public static bool CursorLoadActive = false;
    public Image img;
    public AudioSource audio;

    // Use this for initialization
    void Start () {
        ButtonClick = GetComponent<Animation>();
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        audio.Play();
        ButtonClick.Play("ButtonClick");
        Cursor.SetCursor(this.CursorLoad, Vector2.zero, CursorMode.Auto);
        CursorLoadActive = true;
        if (FischAttacked)
        {
            NextTurnActive = true;
            if (NextTurnActive)
            {
                Debug.Log("Next Turn");                
            }
        }
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        NextTurnActive = false;
        Application.LoadLevel(Application.loadedLevel);
    }
}
