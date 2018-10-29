using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFlippingTest : MonoBehaviour {

    public Animator animator;
    int stance;
    bool Gamestarted;

	void Start () {
        animator.SetBool("BoardFlip_1", true);
        animator.SetBool("GameStarted", false);
        Gamestarted = false;
    }

    private void Update()
    {

        //Testing purpose
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            GameStart();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            BoardFlipStance();
        }
        */
    }

    void BoardFlipping()
    {
        if (stance == 0 )
        {
            animator.SetBool("BoardFlip_1", true);
            stance += 1;
        } else if(stance == 1)
        {
            animator.SetBool("BoardFlip_1", false);
            stance = 0;
        }
    }

    public void GameStart()
    {
        animator.SetBool("GameStarted", true);
        Gamestarted = true;
    }

    public void EndAnimation()
    {
        animator.SetBool("GameStarted", false);
        Gamestarted = false;
    }

    public void BoardFlipStance()
    {
        if (Gamestarted == true)
        {
            BoardFlipping();
        }        
    }
}
