using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayBackHome : MonoBehaviour {
    public GameObject Me;
    public GameObject NPC1;
    public GameObject MessageBox;
    public Transform Canvas;
    public MainGame mainGame;
    private bool CoroutineCalled;

    // Use this for initialization
    void Start () {
        CoroutineCalled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(CoroutineCalled == false)
            {
                StartCoroutine("Story");
            }
        }
    }
    IEnumerator Story()
    {
        CoroutineCalled = true;
        ShowTalkBox showTalkBox = mainGame.CreateTalkBox(Resources.Load("Scenarios/Home") as TextAsset);

        while(true)
        {
            if (showTalkBox != null)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
            
        }
        SceneMove.Instance.Move("S4");
    }
}
