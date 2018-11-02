using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

    public GameObject Pointer;
    int i = 0;
    public ParticleSystem lighting;

    public void Awake()
    {
        lighting.Simulate(100, true, true);
        lighting.Play();
    }
    public void Exit()
    {
        Application.Quit();
    } // -340 ~ 350

    public void NewGame()
    {
        SceneMove.Instance.Move("Prologue");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(Pointer.transform.localPosition.x >= -305)
            {
                Pointer.transform.localPosition -= new Vector3(660, 0, 0);
                i--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Pointer.transform.localPosition.x <= 350)
            {
                Pointer.transform.localPosition += new Vector3(660, 0, 0);
                i++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (i)
            {
                case 0: //new Game
                    Debug.Log("New Game");
                    NewGame();
                    break;
                case 1: //Load Game
                    Debug.Log("Exit");
                    Exit();
                    break;
            }
        }
    }
}
