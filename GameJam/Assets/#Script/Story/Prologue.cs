﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour {

    bool IsEnd = false;
    public float EndY;
    public float speed;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(UpCredit());
    }

    IEnumerator UpCredit()
    {
        while (!IsEnd)
        {
            if(EndY >= transform.localPosition.y && Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.localPosition += new Vector3(0, speed * Time.deltaTime * 2, 0);
            }
            else if (EndY >= transform.localPosition.y)
                gameObject.transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            else
                IsEnd = true;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(5);
        SceneMove.Instance.Move("S");
    }
}
