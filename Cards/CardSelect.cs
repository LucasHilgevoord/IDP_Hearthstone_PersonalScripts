using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelect : MonoBehaviour
{

    private bool ShowCard = false;
    public Animation CardHoverAnim;
    bool DroppedCard = false;
    private bool PlacedCard = false;
    private bool NextTurnActive;


    // Use this for initialization
    void Start()
    {
        CardHoverAnim = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        DroppedCard = DragCard.DroppedCard;
        PlacedCard = DragCard.PlacedCard;
        NextTurnActive = EndTurnBehavior.NextTurnActive;
    }


    void OnMouseOver()
    {
        if (!NextTurnActive)
        {
            if (!CardHoverAnim.IsPlaying("Card4GetAnim"))
            {
                if (this.gameObject.CompareTag("Card1") && !ShowCard && !CardHoverAnim.IsPlaying("Card1HoverOut") && !DroppedCard)
                {
                    ShowCard = true;
                    CardHoverAnim.Play("Card1HoverIn");
                }

                if (this.gameObject.CompareTag("Card2") && !ShowCard && !CardHoverAnim.IsPlaying("Card2HoverOut") && !DroppedCard)
                {
                    ShowCard = true;
                    CardHoverAnim.Play("Card2HoverIn");
                }

                if (this.gameObject.CompareTag("Card3") && !ShowCard && !CardHoverAnim.IsPlaying("Card3HoverOut") && !DroppedCard && !PlacedCard)
                {
                    ShowCard = true;
                    CardHoverAnim.Play("Card3HoverIn");
                }

                if (this.gameObject.CompareTag("Card4") && !ShowCard && !CardHoverAnim.IsPlaying("Card4HoverOut") && !DroppedCard)
                {
                    ShowCard = true;
                    CardHoverAnim.Play("Card4HoverIn");
                }
            }
        }
    }


    void OnMouseExit()
    {
        if (!NextTurnActive)
        {
            if (this.gameObject.CompareTag("Card1") && !DragCard.isMouseDragging && !DroppedCard)
            {
                ShowCard = false;
                CardHoverAnim.Play("Card1HoverOut");
            }
            if (this.gameObject.CompareTag("Card2") && !DragCard.isMouseDragging && !DroppedCard)
            {
                ShowCard = false;
                CardHoverAnim.Play("Card2HoverOut");
            }
            if (this.gameObject.CompareTag("Card3") && !DragCard.isMouseDragging && !DroppedCard && !PlacedCard)
            {
                ShowCard = false;
                CardHoverAnim.Play("Card3HoverOut");
            }
            if (this.gameObject.CompareTag("Card4") && !DragCard.isMouseDragging && !DroppedCard)
            {
                ShowCard = false;
                CardHoverAnim.Play("Card4HoverOut");
            }
        }
    }

}