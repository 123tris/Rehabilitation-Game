using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spawn : MonoBehaviour {

    public List<GameObject> TagSearcher;

    int randomspawn;
    bool Chosen;
    public  Renderer rend;
    public GameObject ball;
    public GameObject playerCamera;
    public GameObject pijl;
    public Material clicked;
    public Material standard;
    public GameObject target;
    GameObject tagSearcher;

    void Start () {
        Chosen = false;

        RandomizerBal();
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
                if (test.gameObject.tag == "Outer")
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
    void RandomizerBal()
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
