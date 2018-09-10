using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spawn : MonoBehaviour {

    [Header("External Scripts")]
    public Bumper_placer b_p;

    [Header("MeshRenderer")]
    public  Renderer rend;

    [Header("GameObjects")]
    public GameObject ball;
    public GameObject playerCamera;
    public GameObject pijl;
    public GameObject target;

    [Header("Materials")]
    public Material clicked;
    public Material standard;

    [Header("List")]
    public List<GameObject> TagSearcher;

    GameObject tagSearcher;

    int randomspawn;
    bool Chosen;

    void Start () {
        Chosen = false;     
    }

    private void Update()
    {
        RaycastHit hit;
       // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition, out hit);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f))
        { 
            if (Input.GetKeyDown(KeyCode.Mouse0) && Chosen == false)
            {             
                GameObject test = hit.collider.gameObject;
                Debug.Log(test);
                if (test.gameObject.tag == "Outer" && b_p.timer <= 0)
                {
                    target = hit.transform.gameObject;
                    target.gameObject.name = "target";
                    rend = target.GetComponent<Renderer>();
                    rend.sharedMaterial = clicked;
                    Chosen = true;
                    SpawnBall();
                }             
            }
        }
    }
    public void RandomizerBal()
    {
        randomspawn = Random.Range(0, TagSearcher.Count);

        tagSearcher = TagSearcher[randomspawn];

        if (tagSearcher.tag == "Up")
        {
            Instantiate(pijl, tagSearcher.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
           // Debug.Log("boven");
        }
        else if (tagSearcher.tag == "Down")
        {
            Instantiate(pijl, tagSearcher.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
          //  Debug.Log("beneden");
        }
        else if (tagSearcher.tag == "left")
        {
            Instantiate(pijl, tagSearcher.transform.position, Quaternion.Euler(new Vector3(0, -90, 0)));
           // Debug.Log("links");
        }
        else if (tagSearcher.tag == "Right")
        {
            Instantiate(pijl, tagSearcher.transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
          //  Debug.Log("rechts");
        }
    }

    public void SpawnBall()
    {
        if(tagSearcher.tag == "Up")
        {
            Instantiate(ball,tagSearcher.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
         //   Debug.Log("boven");
        }
        else if(tagSearcher.tag == "Down")
        {
            Instantiate(ball, tagSearcher.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
         //   Debug.Log("beneden");
        }
        else if (tagSearcher.tag == "left")
        {
            Instantiate(ball, tagSearcher.transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
          //  Debug.Log("links");
        }
        else if (tagSearcher.tag == "Right")
        {
            Instantiate(ball, tagSearcher.transform.position, Quaternion.Euler(new Vector3(0, -90, 0)));
          //  Debug.Log("rechts");
        }
    }

}
