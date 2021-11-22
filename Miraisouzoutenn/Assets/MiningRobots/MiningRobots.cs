using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningRobots : MonoBehaviour
{
    GameObject[] DebrisObject; //代入用のゲームオブジェクト配列を用意

    public Energy energyScript;
    public int m_Resource = 0;              //資源
    public bool m_bGetResource = false;    //資源獲得フラグ
    public bool m_bEnergyHit = false;

    // Start is called before the first frame update
    void Start()
    {
        DebrisObject = GameObject.FindGameObjectsWithTag("Debris");     //Debrisタグの検索

        for (int i = 0; i < DebrisObject.Length; i++)
        {
            Debug.Log(DebrisObject[i]);
        }


        m_Resource = 0;
        m_bGetResource = false;
        m_bEnergyHit = false;
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
            for (int i = 0; i < DebrisObject.Length; i++)
            {
                if(other.gameObject == DebrisObject[i])
                {
                    if (energyScript.GetHit())
                    {
                        m_bEnergyHit = energyScript.GetHit();
                    }
                }
                else
                {
                    //return;
                }
            }

           // m_bEnergyHit = other.GameObject.GetComponent<Deb>().GetFlag();

            if (m_bEnergyHit)   //エネルギーがあたっているなら
            {
                if (!m_bGetResource)
                {
                    m_Resource = 5;
                }
                m_bGetResource = true;
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
        return m_Resource;
    }

}
