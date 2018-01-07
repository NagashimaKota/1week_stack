using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Title_UI : MonoBehaviour {

    private int num = 0;
    private float time = 0;

    // Use this for initialization
	void Start () {
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }
    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
    public void Twitter()
    {
        //WebGL形式のTwitter連携
        naichilab.UnityRoomTweet.Tweet("tiritumo", "ちりも積もれば...\nちり：" + num.ToString() + "　　 探索時間：" + time.ToString() + "[s]", "unity1week");
        
        //本来のTwitter連携
        /*
        num = UI.Tiri_num();
        time = UI.Tiri_time();

        string format = "https://twitter.com/intent/tweet?&text={0}";
        string url = string.Format(format, WWW.EscapeURL("ちりも積もれば...\nちり："+num.ToString()+"　　 探索時間："+time.ToString()+"[s]"));
        Application.OpenURL(url);
        */
    }

    //UI関係
    public void TabUp()
    {
        GameObject.Find("Canvas2").GetComponent<Canvas>().enabled = true;
    }
    public void TabEnd()
    {
        GameObject.Find("Canvas2").GetComponent<Canvas>().enabled = false;
    }
    public void Image2()
    {
        GameObject.Find("Image (1)").GetComponent<Image>().enabled = false;
        GameObject.Find("Image (2)").GetComponent<Image>().enabled = true;

        GameObject.Find("Text3").GetComponent<Text>().enabled = false;
        GameObject.Find("Text (1)").GetComponent<Text>().enabled = false;
        GameObject.Find("Text (2)").GetComponent<Text>().enabled = true;
    }
    public void Image1()
    {
        GameObject.Find("Image (1)").GetComponent<Image>().enabled = true;
        GameObject.Find("Image (2)").GetComponent<Image>().enabled = false;

        GameObject.Find("Text3").GetComponent<Text>().enabled = true;
        GameObject.Find("Text (1)").GetComponent<Text>().enabled = true;
        GameObject.Find("Text (2)").GetComponent<Text>().enabled = false;
    }

}
