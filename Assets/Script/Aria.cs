using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aria : MonoBehaviour {

    private UI ui;
    // Use this for initialization
	void Start () {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ui.Recovery(other);
        }
    }
}
