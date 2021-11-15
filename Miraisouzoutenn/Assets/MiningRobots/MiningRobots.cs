using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningRobots : MonoBehaviour
{
    GameObject[] DebrisObject;
    public Vector3 m_Position;              //初期位置保存用
    public int Resource = 0;                //資源
    public bool GetResourceFlag = false;    //資源獲得フラグ

    // Start is called before the first frame update
    void Start()
    {
        //DebrisObject = GameObject.FindGameObjectsWithTag("Debris");     //Debrisタグの検索

        m_Position = this.transform.position;
        Resource = 0;
        GetResourceFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other) //衝突判定
    {

        //Debrisタグ判定
        if (other.gameObject.tag == "Debris")
        {
            if (Input.GetKey(KeyCode.Space))    //SPACE
            {
                if (!GetResourceFlag)
                {
                    Resource = 5;
                }
                GetResourceFlag = true;
            }
        }
        else
        {
            //Destroy(this.gameObject);
            //this.transform.position = m_Position;
        }
    }

    public int GetResource()
    {
        return Resource;
    }

}
