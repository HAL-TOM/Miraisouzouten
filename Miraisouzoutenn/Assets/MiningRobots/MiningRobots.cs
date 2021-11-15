using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningRobots : MonoBehaviour
{
    GameObject[] DebrisObject;
    public Vector3 m_Position;              //ϊΚuΫΆp
    public int Resource = 0;                //Ή
    public bool GetResourceFlag = false;    //ΉlΎtO

    // Start is called before the first frame update
    void Start()
    {
        //DebrisObject = GameObject.FindGameObjectsWithTag("Debris");     //Debris^OΜυ

        m_Position = this.transform.position;
        Resource = 0;
        GetResourceFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other) //ΥΛ»θ
    {

        //Debris^O»θ
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
