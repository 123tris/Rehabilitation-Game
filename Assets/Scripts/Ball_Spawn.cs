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
    public GameObject arrow;
    public GameObject target;

    [Header("Materials")]
    public Material clicked;
    public Material standard;

    [Header("List")]
    public List<GameObject> tagSearcherList;

    GameObject tagSearcher;

    int randomspawn;
    bool chosen;
    private Vector3 newBallPosition;
    private Vector3 newBallRotation;

    void Start () {
        chosen = false;     
    }

    private void Update()
    {
        RaycastHit hit;
       // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition, out hit);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f))
        { 
            if (Input.GetKeyDown(KeyCode.Mouse0) && chosen == false)
            {             
                GameObject test = hit.collider.gameObject;
                
                if (test.gameObject.tag == "Outer" && b_p.timer <= 0)
                {
                    target = hit.transform.gameObject;
                    target.gameObject.name = "target";
                    rend = target.GetComponent<Renderer>();
                    rend.sharedMaterial = clicked;
                    chosen = true;
                    SpawnBall();
                }             
            }
        }
    }

    public void SetUpcomingBallPosition(Vector3 position,Vector3 rotation, Transform parent)
    {
        var instantiatedArrow = Instantiate(arrow,parent);
        instantiatedArrow.transform.position = position;
        instantiatedArrow.transform.rotation = Quaternion.Euler(rotation);
        newBallPosition = position;
        newBallRotation = rotation;
    }

    public void SpawnBall()
    {
        Instantiate(ball, newBallPosition, Quaternion.Euler(newBallRotation));
    }

}
