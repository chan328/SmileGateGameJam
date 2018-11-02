using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S : MonoBehaviour {

    public GameObject Me;
    public GameObject Park;
    public GameObject Gang;
    public GameObject MessageBox;
    public Transform Canvas;
    public GameObject SchoolEnter;

    public MainGame mainGame;

	// Use this for initialization
	void Start () {
        SchoolEnter.SetActive(false);
        StartCoroutine("asdasd");
	}
	
    IEnumerator asdasd()
    {
        for (; Me.transform.position.y <= Park.transform.position.y - 2;)
        {
            Me.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1.5f);
            yield return new WaitForSeconds(0.1f);
        }
        Me.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        var tmp = mainGame.CreateTalkBox(Resources.Load("Scenarios/S") as TextAsset);

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

        PopUp popUp = mainGame.CreateBox("말을 걸어보자", "무시 하고 지나간다.");

        while (true)
        {
            if (!popUp.FlagA && !popUp.FlagB)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else if (popUp.FlagA)
            {
                Destroy(popUp.gameObject);

                ShowTalkBox g = mainGame.CreateTalkBox(Resources.Load("Scenarios/S-A") as TextAsset);

                while (true)
                {
                    if (g != null)
                    {
                        yield return new WaitForSeconds(0.2f);
                    }
                    else
                    {
                        for (; Vector3.Distance(Park.transform.position, Gang.transform.position) >= 0.8f; )
                        {
                            Park.transform.Translate((Gang.transform.position - Park.transform.position).normalized * 0.2f);
                        }

                        ShowTalkBox g1 = mainGame.CreateTalkBox(Resources.Load("Scenarios/S-A(2)") as TextAsset);

                        Me.AddComponent<CharacterMove>();
                        Camera.main.gameObject.AddComponent<Cam>();
                        Camera.main.gameObject.GetComponent<Cam>().Player = Me;
                        SchoolEnter.SetActive(true);

                        break;
                    }
                }
                break;
            }
            else if (popUp.FlagB)
            {
                Destroy(popUp.gameObject);

                Me.AddComponent<CharacterMove>();
                Camera.main.gameObject.AddComponent<Cam>();
                Camera.main.gameObject.GetComponent<Cam>().Player = Me;
                SchoolEnter.SetActive(true);

                break;
            }

            
        }

        while (true)
        {
            if (Me.GetComponent<CharacterMove>().SchoolEnter == true)
            {
                SceneMove.Instance.Move("S2");
                break;
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return null;
    }

}
