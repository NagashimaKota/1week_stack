using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorMove : MonoBehaviour {

    private Move move;
    private Transform player;
    private float floorPos;

    // Use this for initialization
	void Start () {
        move = GameObject.Find("PL").GetComponent<Move>();
        player = GameObject.Find("PL").GetComponent<Transform>();
        floorPos = move.bodyHigh + 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3( player.position.x, move.bodyHigh - floorPos, player.position.z);
    }
    
}
