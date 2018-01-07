using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {


    public static int ui_num;
    public int dast_speed;
    public static float time;
    
    private Text ui;
    private Text ui2;

    // Use this for initialization
    void Start () {
        ui = GameObject.Find("Text").GetComponent<Text>();
        ui2 = GameObject.Find("Text (1)").GetComponent<Text>();
        ui_num = 10000000;
        time = 0;

    }
	
	// Update is called once per frame
	void Update () {
        dast_speed = Random.Range(900, 1000);
        ui_num -= dast_speed;
        time += Time.deltaTime;

        ui.text = "チリ：" + ui_num.ToString();
        ui2.text = "探索時間：" + time.ToString("N0") + " [s]";
        
    }

    public void Recovery(Collider col)
    {
        ui_num += Random.Range(18000, 20000) + dast_speed;
        if (ui_num > 10000000)
        {
            ui_num = 10000000;
        }
        if (ui_num < 0)
        {
            ui_num = 0;
        }
    }
    public static int Tiri_num()
    {
        return ui_num;
    }
    public static float Tiri_time()
    {
        return time;
    }
}
