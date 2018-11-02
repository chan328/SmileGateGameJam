using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour {
    private Animator animator;
    public float RunSpeed;
    public float Speed = 0.1f;
    public bool CanMove;
    private Vector3 vec;
    public LayerMask layerMask;
    public Collider2D boxColl;
    RaycastHit2D hit;
    public bool Chair = false;
    public bool Door = false;
    public bool SchoolEnter = false;

    Vector2 start;
    Vector2 end;

	// Use this for initialization
	void Start () {
        CanMove = true;
        boxColl = GetComponent<BoxCollider2D>();
        layerMask = 16;
        animator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        vec.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        

        start = transform.position;
        end = start + new Vector2(vec.x * (Speed + RunSpeed) * 5, vec.y * (Speed + RunSpeed) * 5);

        boxColl.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);
        boxColl.enabled = true;
        
        if (hit.transform != null) // 벽에 레이어를 넣어주세영.
            return;

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if(CanMove == true)
            {
                animator.SetBool("IsWalk", true);
                animator.SetFloat("DirX", vec.x);
                animator.SetFloat("DirY", vec.y);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    RunSpeed = 0.1f;
                }
                else RunSpeed = 0;

                if (vec.x != 0)
                {
                    transform.Translate(vec.x * (Speed + RunSpeed), 0, 0);
                }
                else if (vec.y != 0)
                {
                    transform.Translate(0, vec.y * (Speed + RunSpeed), 0);
                }
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetBool("IsWalk", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SchoolEnter")
        {
            // #3 로 넘어감

            SchoolEnter = true;
        }
        if(collision.gameObject.tag == "Chair")
        {
            Chair = true;
            collision.gameObject.SetActive(false);
            transform.position = collision.gameObject.transform.position;
        }
        if(collision.gameObject.tag == "Door")
        {
            Door = true;
        }

        if(collision.gameObject.tag == "Goal")
        {
            SceneMove.Instance.Move("S5-3");
        }

    }
}
