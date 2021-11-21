using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    public GameObject prefab;
    public GameObject debri_small;
    //ミサイルの数
    public int total_missle;
    int missle_ins;
    
    // Start is called before the first frame update
    void Start()
    {
        //missle_ins = total_missle;
        //ミサイルの数分ミサイル生成
        for (int count = 1; count < total_missle; count++)
        {
            Instantiate(prefab);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        //ミサイル残数0
        if (total_missle <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //大きいデブリに配置
        if(collision.gameObject.tag == "debri_big")
        {
            Debug.Log("当たっている");
            //破壊
            if (Input.GetKey(KeyCode.Space))
            {
                //ミサイル破壊
                Destroy(gameObject);
                //大きいデブリ破壊
                Destroy(collision.gameObject);
                //ミサイル-1
                total_missle -= 1;
                //小さいデブリ生成
                Instantiate(debri_small, transform.position, Quaternion.identity);
                

            }
            //配置戻す
            if (Input.GetKey(KeyCode.G))
            {
                transform.position = new Vector3(10f, -3f, 0f);
            }
        }

        //小さいデブリに配置
        if (collision.gameObject.tag == "debri_small")
        {
            //破壊
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(collision.gameObject);
                //ミサイル-1
                total_missle -= 1;
                //ミサイル破壊
                Destroy(gameObject);
            }
            //配置戻す
            if (Input.GetKey(KeyCode.G))
            {
                transform.position = new Vector3(10f, -3f, 0f);
            }


        }
        //その他のオブジェクトに配置又は採掘ロボット配置済みオブジェクト
        if (collision.gameObject.tag != "debri_big" && collision.gameObject.tag != "debri_small" && collision.gameObject.tag == "MiningRobots")
        {
            //Debug.Log("配置不可");
            transform.position = new Vector3(10f, -3f, 0f);


        }

    }



}
