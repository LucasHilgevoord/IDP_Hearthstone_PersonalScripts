using UnityEngine;
using System.Collections;

public class CustomCursor : MonoBehaviour
{

    
    public Texture2D CursorDrag;
    public Texture2D CursorNormal;
    private bool isMouseDragging;
    private bool CursorLoadActive;

    void Start()
    {
        Invoke("SetCustomCursor", 0.0f);
    }

    private void SetCustomCursor()
    {
        Cursor.SetCursor(this.CursorNormal, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        CursorLoadActive = EndTurnBehavior.CursorLoadActive;
        isMouseDragging = DragCard.isMouseDragging;
        if (isMouseDragging)
        {
            Cursor.SetCursor(this.CursorDrag, Vector2.zero, CursorMode.Auto);
        }
        else if (!isMouseDragging && !CursorLoadActive)
        {
            Cursor.SetCursor(this.CursorNormal, Vector2.zero, CursorMode.Auto);
        }
        
        /*
        else
        {
            Cursor.SetCursor(this.CursorNormal, Vector2.zero, CursorMode.Auto);
        }
        */

    }
}