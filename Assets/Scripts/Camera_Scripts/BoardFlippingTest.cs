using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFlippingTest : MonoBehaviour {

    public Animator animator;
    int stance;

	void Start () {
        animator.SetBool("BoardFlip_1", true);
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

    public void BoardFlipStance()
    {
        BoardFlipping();
    }
}
