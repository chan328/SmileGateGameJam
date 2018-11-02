using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {

    Rigidbody2D rig;
    private Animator animator;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rig.velocity != Vector2.zero)
        {
            animator.SetBool("IsWalk", true);
            animator.SetFloat("DirX", Mathf.Clamp(rig.velocity.x, -1, 1));
            animator.SetFloat("DirY", Mathf.Clamp(rig.velocity.y, -1, 1));
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }
	}
}
