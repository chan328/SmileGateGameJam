using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public float RunSpeed;
    public float Speed = 0.1f;
    public bool CanMove;
    private Vector3 vec;
    public LayerMask layerMask;
    public Collider2D boxColl;
    RaycastHit2D hit;

    Vector2 start;
    Vector2 end;

	// Use this for initialization
	void Start () {
        CanMove = true;
        boxColl = GetComponent<BoxCollider2D>();
	}
    

    // Update is called once per frame
    void Update()
    {
        vec.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        start = transform.position;
        end = start + new Vector2(vec.x * (Speed + RunSpeed), vec.y * (Speed + RunSpeed));

        boxColl.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);
        boxColl.enabled = true;

        if (hit.transform != null) // 벽에 레이어를 넣어주세영.
            return;



        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if(CanMove == true)
            {
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SchoolEnter")
        {
            // #3 로 넘어감
        }
    
    }
}
