using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {
    public GameObject EndingStory;
    public GameObject EndingNumber;

	// Use this for initialization
	void Start () {
        StartCoroutine("Ending");
	}
    IEnumerator Ending()
    {
        while(EndingStory.transform.position.y < 400)
        {
            EndingStory.transform.Translate(0, 2, 0);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(3f);
        EndingStory.SetActive(false);
        EndingNumber.SetActive(true);
        yield return new WaitForSeconds(2f);
        // 여기에 main 메뉴 씬을 호출함.
        SceneManager.LoadScene("Intro");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
