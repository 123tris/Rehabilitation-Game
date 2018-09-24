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
    public GameObject instantiatedArrow;

    [Header("Materials")]
    public Material clicked_mat;
    public Material right_mat;
    public Material wrong_mat;

    [Header("List")]
    public List<GameObject> tagSearcherList;

    GameObject tagSearcher;

    int randomspawn;
    bool chosen;
    public bool right;
    public bool wrong;
    private Vector3 newBallPosition;
    private Vector3 newBallRotation;

    void Start () {
        chosen = false;     
    }

    private void Update()
    {
        RaycastHit hit;

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
                    rend.sharedMaterial = clicked_mat;
                    chosen = true;
                    SpawnBall();
                }             
            }
        }

        if(right == true)
        {
            rend = target.GetComponent<Renderer>();
            rend.sharedMaterial = right_mat;
        }

        if(wrong == true)
        {
            rend = target.GetComponent<Renderer>();
            rend.sharedMaterial = wrong_mat;
        }
    }

    public void SetUpcomingBallPosition(Vector3 position,Vector3 rotation, Transform parent)
    {
        instantiatedArrow = Instantiate(arrow,parent);
        instantiatedArrow.gameObject.SetActive(false);
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
