
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    //Drag Card
    public LayerMask selectableLayer;
    GameObject target;
    GameObject getTarget = null;
    public static bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;


    //Drop Card
    public static bool PlacedCard = false;
    public static bool DroppedCard = false;
    private bool DropzoneDrop = false;
    private int speedPlace = 100;
    

    private Transform oldPosition;
    public Transform[] oldPositions;
    public Transform LerpPlace;
    public static GameObject getTargetCard;
    public AudioSource audio;

    //Spawn Fisch
    public Transform FischSpawnPos;
    public GameObject BoarFisch;
    public GameObject Effects;


    //Mana
    private int ManaCost = 0;
    int ManaCap = 7;
    int CurrentMana = 1;

    //EndTurn
    private bool NextTurnActive;


    void Update()
    {
        audio = GetComponent<AudioSource>();
        NextTurnActive = EndTurnBehavior.NextTurnActive;
        if (!NextTurnActive)
        {

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                getTarget = ReturnClickedObject(out hitInfo);
                if (getTarget != null)
                {
                    isMouseDragging = true;
                    positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                    offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));

                }
            }


            //Mouse Button Up
            if (Input.GetMouseButtonUp(0))
            {
                if (getTarget == null)
                {

                }
                else
                {
                    if (getTarget.gameObject.CompareTag("Card1"))
                    {
                        ManaCost = 2;
                        oldPosition = oldPositions[0];
                    }
                    else if (getTarget.gameObject.CompareTag("Card2"))
                    {
                        ManaCost = 3;
                        oldPosition = oldPositions[1];
                    }
                    else if (getTarget.gameObject.CompareTag("Card3"))
                    {
                        ManaCost = 1;
                        oldPosition = oldPositions[2];
                    }
                    else if (getTarget.gameObject.CompareTag("Card4"))
                    {
                        ManaCost = 4;
                        oldPosition = oldPositions[3];
                    }

                    isMouseDragging = false;

                    Vector3 origin = new Vector3(getTarget.transform.position.x, getTarget.transform.position.y, getTarget.transform.position.z);
                    RaycastHit hit;
                    Debug.DrawRay(getTarget.transform.position, Vector3.down * 1000, Color.red);
                    if (Physics.Raycast(origin, Vector3.down, out hit, 1000))
                    {
                        DroppedCard = true;
                        if (hit.transform.tag == "DropZone")
                        {
                            DropzoneDrop = true;
                        }
                    }
                }
            }

            if (DroppedCard)
            {
                if (DropzoneDrop)
                {
                    if (CurrentMana >= ManaCost)
                    {
                        getTarget.transform.position = Vector3.MoveTowards(getTarget.transform.position, LerpPlace.transform.position, speedPlace * Time.deltaTime);
                        
                        if (getTarget.transform.position == LerpPlace.transform.position)
                        {
                            Instantiate(Effects, getTarget.transform.position, Effects.transform.rotation);
                            CurrentMana = CurrentMana - ManaCost;
                            DropzoneDrop = false;
                            Debug.Log("Dropped 1");
                            DroppedCard = false;
                            PlacedCard = true;
                            Instantiate(BoarFisch, FischSpawnPos.position, FischSpawnPos.rotation);
                            audio.Play();
                        }
                    }
                    else
                    {
                        getTarget.transform.position = Vector3.MoveTowards(getTarget.transform.position, oldPosition.transform.position, speedPlace * Time.deltaTime);
                        //getTarget.transform.position = Vector3.RotateTowards(getTarget.transform.position, oldPosition.transform.position, speedReturn / 2 * Time.deltaTime, 0.0F);
                        if (getTarget.transform.position == oldPosition.transform.position)
                        {
                            DroppedCard = false;
                            DropzoneDrop = false;
                            Debug.Log("Dropped 2");
                        }
                    }
                }
                else
                {
                    getTarget.transform.position = Vector3.MoveTowards(getTarget.transform.position, oldPosition.transform.position, speedPlace * Time.deltaTime);
                    //getTarget.transform.position = Vector3.RotateTowards(getTarget.transform.position, oldPosition.transform.position, speedReturn / 2 * Time.deltaTime, 0.0F);
                    if (getTarget.transform.position == oldPosition.transform.position)
                    {
                        DroppedCard = false;
                        Debug.Log("Dropped 3");
                    }
                }
            }




            //Is mouse Moving
            if (isMouseDragging)
            {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

                getTarget.transform.position = currentPosition;
            }

        }
    }

    //Method to Return Clicked Object
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit, selectableLayer))
        {
            target = hit.collider.gameObject;
            if (target.GetComponent<CardSelect>())
            {
                return target;
            }
            else
                return null;
        }
        return target;
    }
        
}
