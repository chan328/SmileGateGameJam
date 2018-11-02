using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCookieEnd : MonoBehaviour {
    public MainGame mainGame;
    public PopUp PopUp;
    public GameObject ending1;
    public GameObject ending2;

	// Use this for initialization
	void Start () {
        PopUp = mainGame.CreateBox("당장 멈추자", "알아서 하게 놔둔다");
	}

    IEnumerator Ending1()
    {
        while(ending1.transform.position.y < 600)
        {
            ending1.transform.Translate(0, 10f, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Ending2()
    {
        while (ending2.transform.position.y < 600)
        {
            ending2.transform.Translate(0, 10f, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(PopUp.FlagA == true)
        {
            Destroy(PopUp.gameObject);
            StartCoroutine("Ending1");
        }
        else if(PopUp.FlagB == true)
        {
            Destroy(PopUp.gameObject);
            StartCoroutine("Ending2");
        }
	}
}
