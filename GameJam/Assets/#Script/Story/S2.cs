using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2 : MonoBehaviour {

    public GameObject Me;
    public GameObject NPC1;
    public GameObject MessageBox;
    public Transform Canvas;
    public GameObject Door;

    public MainGame mainGame;
    public SceneMove sceneMove;
    public AudioSource schoolRing;
	// Use this for initialization
	void Start () {
        StartCoroutine(Story());
	}
	
    IEnumerator Story()
    {
        while(Me.transform.position.x >= NPC1.transform.position.x + 1)
        {
            //Me.transform.Translate(-0.1f, 0, 0);
            Me.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
            yield return new WaitForSeconds(0.1f);
        }
        Me.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return null;

        //기본 시나리오 작업

        ShowTalkBox showTalkBox = mainGame.CreateTalkBox(Resources.Load("Scenarios/S3") as TextAsset);

        while(true)
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

        PopUp popUp = mainGame.CreateBox("박형석에 대하여 물어본다.", "그냥 자리에 앉는다.");

        bool Flag = false;

        while (true)
        {
            if(!popUp.FlagA && !popUp.FlagB)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else if (popUp.FlagA)
            {
                Destroy(popUp.gameObject);

                ShowTalkBox g = mainGame.CreateTalkBox(Resources.Load("Scenarios/S3-A") as TextAsset);

                while (true)
                {
                    if (g != null)
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            }
            else if (popUp.FlagB)
            {
                Flag = true;
                Destroy(popUp.gameObject);

                break;
            
            }
        }

        showTalkBox = mainGame.CreateTalkBox(Resources.Load("Scenarios/S3-A2") as TextAsset);

        while (true)
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

        Me.AddComponent<CharacterMove>();
        Camera.main.gameObject.AddComponent<Cam>();
        Camera.main.gameObject.GetComponent<Cam>().Player = Me;

        while(true)
        {
            if(Me.GetComponent<CharacterMove>().Chair)
            {
                Door.SetActive(true);
                Me.GetComponent<CharacterMove>().enabled = false;
                break;
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
            }
        }

        StartCoroutine(sceneMove.FadeOut());
        Destroy(NPC1);
        schoolRing.Play();

        ShowTalkBox 시발 = mainGame.CreateTalkBox(Resources.Load("Scenarios/Gohome") as TextAsset);

        while(true)
        {
            if(시발 != null)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }

        yield return new WaitForSeconds(2.0f);

        StartCoroutine(sceneMove.FadeIn());

        Me.GetComponent<CharacterMove>().enabled = true;

        while (true)
        {
            if(Me.GetComponent<CharacterMove>().Door)
            {
                if (Flag)
                {
                    SceneMove.Instance.Move("S4-2");
                    break;
                }
                else
                {
                    SceneMove.Instance.Move("GoHome");
                    break;
                }
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
            }
        }
        

        //시나리오 작업 이후
        //SceneMove.Instance.Move("S3");
        yield return null;

    }

}
