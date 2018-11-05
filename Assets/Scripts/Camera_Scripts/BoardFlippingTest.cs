using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFlippingTest : MonoBehaviour
{

    public Animator animator;
    public int stance;
    [HideInInspector] public GameObject boardToDelete;
    [HideInInspector] public GameObject smallGameBoard, bigGameBoard;
    GameObject instantiatedObject;
    public GameObject smallBoardToSpawn;
    public GameObject bigBoardToSpawn;

    private void Start()
    {
        smallGameBoard = GameObject.FindGameObjectWithTag("SmallGameBoard");
        bigGameBoard = GameObject.FindGameObjectWithTag("BigGameBoard");
    }

    public void BoardFlipping()
    {
        if (stance == 0)
        {
            animator.SetBool("BoardFlip_1", true);
            stance = 1;
        }
        else if (stance == 1)
        {
            animator.Play("BoardFlip_2", -1, 0f);
            animator.SetBool("BoardFlip_1", false);
        }
    }

    public void SpawnSmallBoard()
    {
        boardToDelete = GameObject.FindGameObjectWithTag("SpawnerKlein");
        instantiatedObject = Instantiate(smallBoardToSpawn, smallGameBoard.transform);
        instantiatedObject.transform.localPosition = new Vector3(66.66666f, 20, 70.26167f);
        instantiatedObject.GetComponent<Bumper_placer>().enabled = true;
        Destroy(boardToDelete);
    }

    public void SpawnBigBoard()
    {
        boardToDelete = GameObject.FindGameObjectWithTag("SpawnerBig");
        instantiatedObject = Instantiate(bigBoardToSpawn, bigGameBoard.transform);
        instantiatedObject.transform.localPosition = new Vector3(66.66666f, 28, 70.26167f);
        instantiatedObject.GetComponent<Bumper_placer>().enabled = true;
        Destroy(boardToDelete);
    }

    public void GameStart()
    {
        animator.SetBool("GameStarted", true);
    }

    public void GameEnd()
    {
        animator.SetBool("GameStarted", false);
    }
}
