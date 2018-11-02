using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S5 : MonoBehaviour {
    public GameObject Me;
    public GameObject MessageBox;
    public Transform Canvas;
    public Image Letter;
    public AudioSource audio;
    public MainGame mainGame;
    public SceneMove sceneMove;

    // Use this for initialization
    void Start () {
        audio = this.GetComponent<AudioSource>();
        StartCoroutine("Story");
	}

    IEnumerator Story()
    {
        ShowTalkBox showTalkBox1 = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5") as TextAsset);
        while (true)
        {
            if(showTalkBox1 != null)
            {
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                break;
            }
        }
        while (Me.transform.position.x > 6.0f)
        {
            Me.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
            yield return new WaitForSeconds(0.2f);
        }
        Me.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        ShowTalkBox showTalkBox2 = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5-2") as TextAsset);
        while (true)
        {
            if(showTalkBox2 != null)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }
        StartCoroutine(sceneMove.FadeOut());

        //schoolRing.Play();
        yield return new WaitForSeconds(2.0f);
        Me.transform.position = new Vector2(-20f, -5.5f);

        StartCoroutine(sceneMove.FadeIn());

        ShowTalkBox showTalkBox3 = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5-3") as TextAsset);
        audio.enabled = true;
        while(true)
        {
            if(showTalkBox3 != null)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }
        while(Letter.color.a <= 1)
        {
            Letter.color = new Color(1, 1, 1, Letter.color.a + 0.02f);
            yield return new WaitForSeconds(0.1f);
        }
        ShowTalkBox tmp = mainGame.CreateTalkBox(Resources.Load("Scenarios/Letter") as TextAsset);

        while(true)
        {
            if(tmp != null)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }
        
        while (Letter.color.a >= 0)
        {
            Letter.color = new Color(1, 1, 1, Letter.color.a - 0.2f );
            yield return new WaitForSeconds(0.1f);
        }

        Me.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2f);
        yield return new WaitForSeconds(2.2f);
        Me.GetComponent<Rigidbody2D>().velocity = new Vector2(8, 0);
        yield return new WaitForSeconds(4f);
        Me.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        SceneMove.Instance.Move("S5-2");

    }

    // Update is called once per frame
    void Update () {
		
	}
}
