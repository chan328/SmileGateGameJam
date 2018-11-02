using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4_2 : MonoBehaviour {
    public GameObject Me;
    public GameObject MessageBox;
    public Transform Canvas;
    public MainGame mainGame;


    // Use this for initialization
    void Start () {
        StartCoroutine("Story");
	}
	
    IEnumerator Story()
    {
        ShowTalkBox showTalkBox =  mainGame.CreateTalkBox(Resources.Load("Scenarios/S4-2") as TextAsset);

        while (true)
        {
            if(showTalkBox != null)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }
        while(Me.transform.position.y > -3.5)
        {
            Me.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
            yield return new WaitForSeconds(0.1f);
        }
        while(Me.transform.position.x < 5.6)
        {
            Me.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
            yield return new WaitForSeconds(0.1f);
        }
        Me.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        SceneMove.Instance.Move("Ending03");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
