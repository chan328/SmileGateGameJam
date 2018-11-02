using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEnd : MonoBehaviour {

    public GameObject Me;
    public GameObject MessageBox;
    public Transform Canvas;

    public MainGame mainGame;
    // Use this for initialization
    void Start () {

        StartCoroutine(Story());
        

    }
	
	IEnumerator Story()
    {
        Rigidbody2D CharacterRig = Me.GetComponent<Rigidbody2D>();

        CharacterRig.velocity = new Vector2(0, -60 * Time.deltaTime);
        yield return new WaitForSeconds(1);
        CharacterRig.velocity = new Vector2(-500 * Time.deltaTime, 0);
        yield return new WaitForSeconds(1.0f);
        CharacterRig.velocity = new Vector2(0, 0);


        //그림 보여주는 코드


        SceneMove.Instance.Move("Ending");
    }
}
