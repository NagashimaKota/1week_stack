using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {

    public GameObject bodyPrefab;
    public float bodyHigh = 0f;
    public float body_num = 0f;

    private GameObject[] bodys;
    private Transform mainCamera;
    private Rigidbody player;
    private Vector3 cameraPower = Vector3.zero;
    private Vector3 cameraPowerRL = Vector3.zero;
    private float cameraRote;
    private float speed = 5f;
    private float jump = 20f;
    private bool clear = false;
    
    

    // Use this for initialization
    void Start () {
        player = GameObject.Find("PL").GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Camera").GetComponent<Transform>();
        body_num = 0;
	}
	
	// Update is called once per frame
	void Update () {

        CameraRoll();    //プレイヤーを前方向に進ませるため
        PLMove();        //プレイヤーの入力
        player.AddForce(cameraPower);
    }

    private void OnCollisionEnter(Collision col)
    {
        Body_up(col.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Stage")
        {
            bodyHigh++;
        }
        if (other.gameObject.tag == "Clear" && body_num >= 1)
        {
            Invoke("Clear",2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Stage")
        {
            bodyHigh--;
        }
        if (bodyHigh < 0)
        {
            bodyHigh = 0;
        }
    }


    private void Clear()
    {
        SceneManager.LoadScene("End");
    }
    private void PLMove()
    {
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            player.AddForce(-cameraPower);
        }

        if (Input.GetKey(KeyCode.Space) && this.transform.position.y <= 0.7 + bodyHigh)
        {
            player.AddForce(0, jump, 0);
        }
        


    }
    public void Body_up(GameObject body)
    {
        Debug.Log(body.tag);
        if (body.gameObject.tag == "Body")
        {
            bodyHigh++;
            body_num++;
            Instantiate(bodyPrefab);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + body_num, this.transform.position.z);
            Destroy(body.gameObject);
        }
    }

    //スマホ用
    public void FrontMove()
    {
        player.AddForce(cameraPower);
    }
    public void Jump()
    {
        if (this.transform.position.y <= 0.7 + bodyHigh)
        {
            player.AddForce(0, jump, 0);
        }
    }
    //力の計算
    private void CameraRoll()
    {
        cameraRote = mainCamera.rotation.eulerAngles.y;
        if (cameraRote >=0 && cameraRote < 90)
        {
            //上下方向の力
            cameraPower.z = Mathf.Sin((90f - cameraRote) * Mathf.PI / 180);
            cameraPower.x = Mathf.Cos((90f - cameraRote) * Mathf.PI / 180);

        }
        else if(cameraRote >= 90 && cameraRote < 180)
        {
            cameraPower.z = -Mathf.Sin((cameraRote - 90f) * Mathf.PI / 180);
            cameraPower.x = Mathf.Cos((cameraRote - 90f) * Mathf.PI / 180);
        }
        if (cameraRote >= 180 && cameraRote < 270)
        {
            cameraPower.z = -Mathf.Sin((270f - cameraRote) * Mathf.PI / 180);
            cameraPower.x = -Mathf.Cos((270f - cameraRote) * Mathf.PI / 180);
        }
        else
        {
            cameraPower.z = Mathf.Sin((cameraRote - 270f) * Mathf.PI / 180);
            cameraPower.x = -Mathf.Cos((cameraRote - 270f) * Mathf.PI / 180);
        }
        
    }
}
