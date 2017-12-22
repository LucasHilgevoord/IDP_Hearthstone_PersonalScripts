using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitmarkBehavior : MonoBehaviour {

    public Animation HitmarkAnim;

    void Start()
    {
        HitmarkAnim = GetComponent<Animation>();
    }

    void Awake()
    {
        HitmarkAnim.Play("Hitmark");
        StartCoroutine(KillCard());
    }

    IEnumerator KillCard()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
