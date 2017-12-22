using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fischBehavior : MonoBehaviour {

    public Animation FischFallAnim;
    public GameObject Arrow;
    public Transform ArrowRotation;
    public GameObject Fisch;
    public GameObject HitMark;
    public GameObject Icon;
    private bool NextTurnActive;
    public static bool AttackedBoss = false;
    public AudioSource audio;
    public GameObject FallDust;

    //Arrow
    private int SpawnArrow = 1;

    void Start()
    {
        FischFallAnim = GetComponent<Animation>();
    }

    void Awake()
    {
        StartCoroutine(KillCard());
        Instantiate(Icon, GameObject.Find("CardIconPos").transform.position, GameObject.Find("CardIconPos").transform.rotation);



    }

    IEnumerator KillCard()
    {
        yield return new WaitForSeconds(0.5f);
        FischFallAnim.Play("FischFall");
        Destroy(GameObject.Find("Card3"));
        DragCard.PlacedCard = false;

        yield return new WaitForSeconds(0.3f);
        Instantiate(FallDust, this.transform.position, this.transform.rotation);

        yield return new WaitForSeconds(2.9f);
        Destroy(GameObject.Find("boar_placement_fiche_FX(Clone)"));


    }

    void Update()
    {
        audio = GetComponent<AudioSource>();
        NextTurnActive = EndTurnBehavior.NextTurnActive;
        if (!NextTurnActive)
        {
            //Debug.Log(SpawnArrow);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction * 1000, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.tag == "Fisch")
                    {
                        Debug.Log("FischSelect");
                        if (SpawnArrow == 1)
                        {
                            
                            SpawnArrow--;
                            Instantiate(Arrow, new Vector3(hit.point.x, hit.point.y + 5, hit.point.z), ArrowRotation.rotation);

                            //Play Audio
                            audio.Play();
                        }
                    }
                }

                if (Input.GetMouseButtonUp(0) && SpawnArrow == 0)
                {
                    SpawnArrow++;
                    Debug.Log("FischDown");
                    Destroy(GameObject.Find("Arrow4(Clone)"));
                }
            }
        }

        if (NextTurnActive)
        {
            FischFallAnim.Play("FischAttack");
            EndTurnBehavior.NextTurnActive = false;
            StartCoroutine(SpawnHitmark());
        }

    }
    IEnumerator SpawnHitmark()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(HitMark, GameObject.Find("HitmarkPos").transform.position, GameObject.Find("HitmarkPos").transform.rotation);
        AttackedBoss = true;
    }
}

