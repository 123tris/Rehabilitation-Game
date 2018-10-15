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

    [Header("Audio")]
    [FMODUnity.EventRef]
    public string CannonSound = "event:/Ball/CannonShot";

    [FMODUnity.EventRef]
    public string RollingSound = "event:/Ball/Rolling";

    FMOD.Studio.EventInstance RollingEv;

    GameObject tagSearcher;

    int randomspawn;
    bool chosen;
    public bool right;
    public bool wrong;
    private Vector3 newBallPosition;
    private Vector3 newBallRotation;

    void Start () {

        

       

        chosen = false;
        if(playerCamera == null)
        {
            playerCamera = Camera.main.gameObject;
        }
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
        for (int i = 0; i < b_p.board.GetLength(0) - 5; i++)
        {
            newBallPosition += Vector3.back * 0.5f;
            newBallPosition += Vector3.left * 0.5f;
        }
        newBallRotation = rotation;
    }

    public void SpawnBall()
    {
        Instantiate(ball, newBallPosition, Quaternion.Euler(newBallRotation));
        FMODUnity.RuntimeManager.PlayOneShot(CannonSound, instantiatedArrow.transform.position);
        RollingEv = FMODUnity.RuntimeManager.CreateInstance(RollingSound);
        RollingEv.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(instantiatedArrow.transform));
        RollingEv.start();
    }

}
