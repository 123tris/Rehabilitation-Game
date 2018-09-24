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

    [Header("Find_Scripts")]
    public GameObject bSP;
    public GameObject gameController;
    public GameObject blackScreen;

    [Header("Rigidbody")]
    public Rigidbody rb;

    public Animator anim;

    float speed = 0.1f;
    public bool vertical;
    bool spawned;

    private void Start()
    {
        bSP = GameObject.FindGameObjectWithTag("Spawner");
        gameController = GameObject.FindGameObjectWithTag("Observer");
        blackScreen = GameObject.FindGameObjectWithTag("BlackScreen");
        b_s = gameController.GetComponent<Ball_Spawn>();
        b_p = bSP.GetComponent<Bumper_placer>();
        p_s = gameController.GetComponent<PointSystem>();
        anim = blackScreen.GetComponent<Animator>();

        spawned = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

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
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
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
        if (collision.gameObject.name == "target")
        {
            anim.SetBool("Out", true);
            p_s.AddPoints();
            b_s.right = true;
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(CooldownManager.Cooldown(3f, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex)));
        }
        else if (collision.gameObject.tag == "Outer" && spawned == true)
        {
            anim.SetBool("Out", true);
            GetComponent<MeshRenderer>().enabled = false;
            b_s.wrong = true;
            StartCoroutine(CooldownManager.Cooldown(3f, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex)));           
        }          
    }
} 
