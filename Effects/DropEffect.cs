using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEffect : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        StartCoroutine(KillEffect());
    }

    IEnumerator KillEffect()
    {
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
    }
}
