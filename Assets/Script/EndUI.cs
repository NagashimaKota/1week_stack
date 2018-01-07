using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour {

    private int num = 0;
    private float time = 0;
    private Text ui_num;
    private Text ui_time;

    // Use this for initialization
    void Start () {
        num = UI.Tiri_num();
        time = UI.Tiri_time();

        ui_num =  GameObject.Find("Text (2)").GetComponent<Text>();
        ui_time =  GameObject.Find("Text (1)").GetComponent<Text>();

        ui_num.text = "チリ：" + num.ToString();
        ui_time.text = "探索時間：" + time.ToString() + " [s]";

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
