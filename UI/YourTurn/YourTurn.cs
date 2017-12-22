using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourTurn : MonoBehaviour {

    public Transform CardPoint;
    private bool StartCount = false;
    public static bool ActivateCard = false;
    public GameObject YourTurnObject;

    void Start()
    {
        StartCount = true;
    }

    void Update()
    {
        transform.localScale = new Vector4(Mathf.PingPong(Time.time, 6) - 1, transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Destroy(YourTurnObject, 1);

        if (StartCount)
        {
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Debug.Log(StartCount);
        Debug.Log("Activate");
        ActivateCard = true;
        StartCount = false;
    }

}
