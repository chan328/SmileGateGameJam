using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTalkBox : MonoBehaviour {
    public GameObject UI;
    public Image Charactor;
    public Image NPC;
    public Text Script;
    public Sprite[] Me = new Sprite[3];
    public Sprite[] Park = new Sprite[3];
    public Sprite[] Gang;
    public Sprite[] Friend;
    public TextAsset textAsset;

    string[] lines;
    int lineCount;
    int count;
    bool IsRunning;

    public void AA()
    {
        lines = textAsset.text.Split('\n');

        count = 2;
        lineCount = int.Parse(lines[0]);

        TalkBox(1);
    }

    void TalkBox(int i)    {
        //Debug.Log(i);

        try // Me : 표정(1 그냥, 2 웃음, 3 화남) : 대사  && NPC : 번호 (1 박형석, 2 친구, 3 짜잘짜잘) : 표정 : 대사
        {

            string[] script = lines[i].Split(':');
            Script.text = null;
            if (script[0] == "Me ")
            {
                Charactor.sprite = Me[int.Parse(script[1]) - 1];
                Charactor.color = new Color(1, 1, 1, 1);
                NPC.sprite = null;
                NPC.color = new Color(1, 1, 1, 0);
                StartCoroutine("SlowText", script[2]);
            }
            else
            {
                int NpcNum = int.Parse(script[1]);
                NPC.sprite = (NpcNum == 1 ? (Park[int.Parse(script[2]) - 1]) : (NpcNum == 2 ? Friend[int.Parse(script[2]) - 1] : (NpcNum == 3 ? Gang[int.Parse(script[2]) - 1] : null)));
                Charactor.color = new Color(1, 1, 1, 0);
                Charactor.sprite = null;
                NPC.color = new Color(1, 1, 1, 1);

                if (NpcNum == 5)
                {
                    Charactor.color = new Color(0, 0, 0, 0);
                    NPC.color = new Color(0, 0, 0, 0);
                }
                StartCoroutine("SlowText", script[3]);
            }
        }
        catch(IndexOutOfRangeException e)
        {
            return;
        }
    }

    IEnumerator SlowText(string script)
    {
        IsRunning = true;
        yield return new WaitForSeconds(0.1f);
        foreach(char a in script.ToCharArray())
        {
            Script.text += a;
            
            yield return new WaitForSeconds(0.075f);
            
        }

        IsRunning = false;
        yield return null;
    }

    private void FixedUpdate()
    {
//Debug.Log(count + " " + lineCount);
        if(count > lineCount+1)
        {
            Destroy(gameObject);
        }
        if((Input.GetKeyUp(KeyCode.Space) || (Input.GetMouseButtonUp(0)) )&& !IsRunning)
        {
            TalkBox(count++);
        }
    }

}
