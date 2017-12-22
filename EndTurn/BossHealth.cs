using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public Animation HealthAnim;
    int Health = 30;

    void Start()
    {
        HealthAnim = GetComponent<Animation>();
    }

    void Awake()
    {
        TextMesh textObject = this.GetComponent<TextMesh>();
        textObject.text = ((int)Health).ToString();
    }

    void Update()
    {
        bool AttackedBoss = fischBehavior.AttackedBoss;
        if (fischBehavior.AttackedBoss)
        {
            Health--;
            TextMesh textObject = this.GetComponent<TextMesh>();
            textObject.text = ((int)Health).ToString();
            textObject.color = Color.red;

            StartCoroutine(ColorChange());
            fischBehavior.AttackedBoss = false;
            HealthAnim.Play("BossHealth");

        }
    }

    IEnumerator ColorChange()
    {
        yield return new WaitForSeconds(0.5f);
        TextMesh textObject = this.GetComponent<TextMesh>();
        textObject.color = Color.white;
    }
}