using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S5_3 : MonoBehaviour {
    public GameObject Me;
    public GameObject Park;
    public GameObject Gang;
    public GameObject Friend;
    public GameObject TheEnd;

    public MainGame mainGame;
    public SceneMove sceneMove;

	// Use this for initialization
	void Start () {
        StartCoroutine("Yeah");
	}
	
	IEnumerator Yeah()
    {
        ShowTalkBox showTalkBox = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5-5") as TextAsset);

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

        PopUp popUp = mainGame.CreateBox("알아서들 해결해겠지", "가서 (오징어를)말린다");

        while(true)
        {
            if(!popUp.FlagA && !popUp.FlagB)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else if(popUp.FlagA) // 2번엔딩
            {
                Destroy(popUp.gameObject);

                StartCoroutine(sceneMove.FadeOut());
                Gang.transform.Translate(-2, 0, 0);
                Park.transform.rotation = new Quaternion();
                Friend.transform.position = new Vector3((Gang.transform.position.x + Park.transform.position.x) / 2, (Gang.transform.position.y + Park.transform.position.y) / 2, -0.1f);
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(sceneMove.FadeIn());

                ShowTalkBox showTalkBox1 = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5-6") as TextAsset);

                while (true)
                {
                    if (showTalkBox1 != null)
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                    else
                    {
                        break;
                    }
                }

                StartCoroutine(sceneMove.FadeOut());

                yield return new WaitForSeconds(0.5f);
                Destroy(Park);
                Destroy(Gang);
                Destroy(Friend);

                ShowTalkBox showTalkBox2 = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5-7") as TextAsset);

                while (true)
                {
                    if (showTalkBox2 != null)
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                    else
                    {
                        break;
                    }
                }

                TheEnd.SetActive(true);

                while(true)
                {
                    if(Input.GetKeyUp(KeyCode.Space))
                    {
                        sceneMove.Move("Intro");
                        break;
                    }
                    else
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                }

                break;
            }
            else if (popUp.FlagB)
            {
                Destroy(popUp.gameObject);

                ShowTalkBox show = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5-8") as TextAsset);

                while(true)
                {
                    if(show != null)
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                    else
                    {
                        break;
                    }
                }

                Me.transform.Translate((Me.transform.position - Gang.transform.position).normalized);

                StartCoroutine(sceneMove.FadeOut());

                Gang.transform.Rotate(0, 0, -45);

                Park.transform.position = Gang.transform.position + new Vector3(0,1,0);

                yield return new WaitForSeconds(5f);
                StartCoroutine(sceneMove.FadeIn());

                ShowTalkBox show1 = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5-9") as TextAsset);

                while (true)
                {
                    if (show1 != null)
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                    else
                    {
                        break;
                    }
                }

                StartCoroutine(sceneMove.FadeOut());
                yield return new WaitForSeconds(0.2f);
                ShowTalkBox show2 = mainGame.CreateTalkBox(Resources.Load("Scenarios/S5-10") as TextAsset);

                while (true)
                {
                    if (show2 != null)
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                    else
                    {
                        break;
                    }
                }

                while(true)
                {
                    if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
                    {
                        sceneMove.Move("Intro");
                    }
                    else
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                }

                //sceneMove.Move("CookieEnding1");
                break;
            }
        }

        yield return null;
    }
}
