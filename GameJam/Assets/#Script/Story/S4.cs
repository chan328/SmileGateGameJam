using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4 : MonoBehaviour {

    public GameObject Me;
    public GameObject MessageBox;
    public Transform Canvas;

    public MainGame mainGame;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Story());
    }

    IEnumerator Story()
    {
        Rigidbody2D CharacterRig = Me.GetComponent<Rigidbody2D>();

        /*CharacterRig.velocity = new Vector2(5, 0);
        yield return new WaitForSeconds(1f);
        CharacterRig.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(2f);
        CharacterRig.velocity = new Vector2(-5, 0);
        yield return new WaitForSeconds(1f);
        CharacterRig.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1f);
        CharacterRig.velocity = new Vector2(0, -5);
        yield return new WaitForSeconds(0.3f);
        CharacterRig.velocity = new Vector2(0, 5);
        yield return new WaitForSeconds(0.3f);
        CharacterRig.velocity = new Vector2(0, 0);*/

        PopUp popUp = mainGame.CreateBox("핸드폰에서 박형석의 번호를 찾아보자.", "학생의 본분을 다한다");
        while (true)
        {
            if (!popUp.FlagA && !popUp.FlagB)
            {
                yield return new WaitForSeconds(0.2f);
            }
            else if (popUp.FlagA)
            {
                Destroy(popUp.gameObject);

                ShowTalkBox g = mainGame.CreateTalkBox(Resources.Load("Scenarios/S4") as TextAsset);

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


                SceneMove.Instance.Move("S5");
                break;
            }
            else if (popUp.FlagB)
            {
                Destroy(popUp.gameObject);

                SceneMove.Instance.Move("S4-2");

                break;

            }
        }


        Camera.main.gameObject.AddComponent<Cam>();
        Camera.main.gameObject.GetComponent<Cam>().Player = Me;

        //기본 시나리오 작업
        //SceneMove.Instance.Move("#Scenes/Story/S5");

    }
}
