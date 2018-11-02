using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball_Controler : MonoBehaviour
{
    [Header("External Scripts")]
    public Ball_Spawn b_s;
    public Bumper_placer b_p;
    public PointSystem p_s;
    public IsBoardSmall c_p_b;

    [Header("Find_Scripts")]
    public GameObject bSP;
    public GameObject gameController;
    public GameObject mainGameLogic;
    public GameObject changePlayBoardSize;

    [Header("Rigidbody")]
    public Rigidbody rb;

    [Header("Collider")]
    public SphereCollider sCollider;


    [Header("Audio")]
    [FMODUnity.EventRef]
    public string CorrectSound = "event:/Ball/Correct";

    [FMODUnity.EventRef]
    public string WrongSound = "event:/Ball/Wrong";

    [FMODUnity.EventRef]
    public string BumpSound = "event:/Bumper/Bump";

    [FMODUnity.EventRef]
    public string ChantDissapointedSound = "event:/Ambiance/Wrong";

    [FMODUnity.EventRef]
    public string ChantCheeringSound = "event:/Ambiance/Correct";


    [FMODUnity.EventRef]
    public string RollingSound = "event:/Ball/Rolling";

    FMOD.Studio.EventInstance RollingEv;

    [Header("Misc")]
    public GameObject smallBoardToSpawn;
    public GameObject bigBoardToSpawn;
    [HideInInspector] public GameObject smallGameBoard, bigGameBoard;
    [HideInInspector] public GameObject boardToDelete;

    float speed = 0.1f;
    public bool vertical;
    bool spawned;

    private void Start()
    {
        sCollider = GetComponent<SphereCollider>();
        // bSP = GameObject.FindGameObjectWithTag("Spawner");
        smallGameBoard = GameObject.FindGameObjectWithTag("SmallGameBoard");
        bigGameBoard = GameObject.FindGameObjectWithTag("BigGameBoard");
        gameController = GameObject.FindGameObjectWithTag("Observer");
        mainGameLogic = GameObject.FindGameObjectWithTag("MainGameLogic");
        c_p_b = mainGameLogic.GetComponent<IsBoardSmall>();
        b_s = gameController.GetComponent<Ball_Spawn>();
        //b_p = bSP.GetComponent<Bumper_placer>();
        p_s = mainGameLogic.GetComponent<PointSystem>();

        spawned = false;

        RollingEv = FMODUnity.RuntimeManager.CreateInstance(RollingSound);
        RollingEv.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        RollingEv.start();
    }

    void FixedUpdate()
    {

        if (Mathf.Round(gameObject.transform.eulerAngles.y) == 0 || Mathf.Round(gameObject.transform.eulerAngles.y) == 180
            || Mathf.Round(gameObject.transform.eulerAngles.y) == -180 || Mathf.Round(gameObject.transform.eulerAngles.y) == 360 || Mathf.Round(gameObject.transform.eulerAngles.y) == -360)
        {
            vertical = true;
        }
        else
        {
            vertical = false;
        }

        transform.Translate(0, 0, speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bumper1" || other.gameObject.tag == "Bumper2")
        {
            foreach (Renderer r in other.gameObject.GetComponentsInChildren<Renderer>())
            {
                r.enabled = true;
            }
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;

            FMODUnity.RuntimeManager.PlayOneShot(BumpSound, transform.position);
            spawned = true;
        }

        if (other.gameObject.tag == "Bumper1" && vertical == false)
        {
            gameObject.transform.Rotate(0, -90, 0);
        }
        else if (other.gameObject.tag == "Bumper1" && vertical == true)
        {
            gameObject.transform.Rotate(0, 90, 0);
        }
        else if (other.gameObject.tag == "Bumper2" && vertical == false)
        {
            gameObject.transform.Rotate(0, 90, 0);
        }
        else if (other.gameObject.tag == "Bumper2" && vertical == true)
        {
            gameObject.transform.Rotate(0, -90, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "target" && spawned == true)
        {
            p_s.AddPoints();
            GameObject instantiatedObject;
            GetComponent<MeshRenderer>().enabled = false;
            sCollider.enabled = false;
            b_s.right = true;

            //Fmod-------------------------------------------------------------------------
            FMODUnity.RuntimeManager.PlayOneShot(ChantCheeringSound, transform.position);
            FMODUnity.RuntimeManager.PlayOneShot(CorrectSound, transform.position);
            FMODUnity.RuntimeManager.DetachInstanceFromGameObject(RollingEv);

            if (c_p_b.isTheBoardSmall == true)
            {
                boardToDelete = GameObject.FindGameObjectWithTag("SpawnerKlein");
                instantiatedObject = Instantiate(smallBoardToSpawn, smallGameBoard.transform);
                instantiatedObject.transform.localPosition = new Vector3(66.66666f, 20, 70.26167f);
                instantiatedObject.GetComponent<Bumper_placer>().enabled = true;
                Destroy(boardToDelete);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("shot");
                boardToDelete = GameObject.FindGameObjectWithTag("SpawnerBig");
                instantiatedObject = Instantiate(bigBoardToSpawn, bigGameBoard.transform);
                instantiatedObject.transform.localPosition = new Vector3(66.66666f, 28, 70.26167f);
                instantiatedObject.GetComponent<Bumper_placer>().enabled = true;
                Destroy(boardToDelete);
                Destroy(gameObject);
            }
            //  instantiatedObject.transform.localPosition = boardToDelete.transform.localPosition;

        }
        else if (collision.gameObject.tag == "Outer" && spawned == true)
        {
            p_s.Missed();
            GameObject instantiatedObject;
            GetComponent<MeshRenderer>().enabled = false;
            sCollider.enabled = false;
            b_s.wrong = true;

            //Fmod-------------------------------------------------------------------------
            FMODUnity.RuntimeManager.PlayOneShot(ChantDissapointedSound, transform.position);
            FMODUnity.RuntimeManager.PlayOneShot(WrongSound, transform.position);
            FMODUnity.RuntimeManager.DetachInstanceFromGameObject(RollingEv);

            if (c_p_b.isTheBoardSmall == true)
            {
                boardToDelete = GameObject.FindGameObjectWithTag("SpawnerKlein");
                instantiatedObject = Instantiate(smallBoardToSpawn, smallGameBoard.transform);
                instantiatedObject.transform.localPosition = new Vector3(66.66666f, 20, 70.26167f);
                instantiatedObject.GetComponent<Bumper_placer>().enabled = true;
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("miss");
                boardToDelete = GameObject.FindGameObjectWithTag("SpawnerBig");
                instantiatedObject = Instantiate(bigBoardToSpawn, bigGameBoard.transform);
                instantiatedObject.transform.localPosition = new Vector3(66.66666f, 28, 70.26167f);
                instantiatedObject.GetComponent<Bumper_placer>().enabled = true;
                Destroy(boardToDelete);
                Destroy(gameObject);
            }
            // instantiatedObject.transform.localPosition = boardToDelete.transform.localPosition;


        }
    }
}
