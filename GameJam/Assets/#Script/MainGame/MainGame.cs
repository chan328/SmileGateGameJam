using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour {
    public Transform Canvas;
    public PopUp MessageBox;
    public PopopUp MessageBox3;
    public ShowTalkBox showTalkBox;
    public GameObject PauseUI;

    public PopUp CreateBox(string A, string B)
    {
        PopUp Box = Instantiate(MessageBox);
        Box.transform.SetParent(Canvas, false);
        Box.TextA.text = A;
        Box.TextB.text = B;

        return Box;
    }

    public PopopUp Create3Box(string A, string B, string C)
    {
        PopopUp Box = Instantiate(MessageBox3);
        Box.transform.SetParent(Canvas, false);
        Box.TextA.text = A;
        Box.TextB.text = B;
        Box.TextC.text = C;

        return Box;
    }

    public ShowTalkBox CreateTalkBox(TextAsset a)
    {
        ShowTalkBox Box = Instantiate(showTalkBox);
        Box.transform.SetParent(Canvas, false);
        Box.textAsset = a;
        Box.AA();

        return Box;
    }

    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
}
