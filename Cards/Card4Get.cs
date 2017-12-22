using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card4Get : MonoBehaviour
{

    public Animation CardGet;

    // Use this for initialization
    void Start()
    {
        CardGet = GetComponent<Animation>();
    }

    void Awake()
    {
        StartCoroutine("SpawnCard");
    }

    IEnumerator SpawnCard()
    {
        yield return new WaitForSeconds(0.2f);
        CardGet.Play("Card4GetAnim");

    }
}
