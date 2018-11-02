using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
    public GameObject Player;

	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 Target = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, Target, Time.deltaTime * 2f);
    }
}
