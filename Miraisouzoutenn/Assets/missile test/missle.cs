using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    public GameObject prefab;
    public GameObject debri_small;
    //�~�T�C���̐�
    public int total_missle;
    int missle_ins;
    
    // Start is called before the first frame update
    void Start()
    {
        //missle_ins = total_missle;
        //�~�T�C���̐����~�T�C������
        for (int count = 1; count < total_missle; count++)
        {
            Instantiate(prefab);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        //�~�T�C���c��0
        if (total_missle <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //�傫���f�u���ɔz�u
        if(collision.gameObject.tag == "debri_big")
        {
            Debug.Log("�������Ă���");
            //�j��
            if (Input.GetKey(KeyCode.Space))
            {
                //�~�T�C���j��
                Destroy(gameObject);
                //�傫���f�u���j��
                Destroy(collision.gameObject);
                //�~�T�C��-1
                total_missle -= 1;
                //�������f�u������
                Instantiate(debri_small, transform.position, Quaternion.identity);
                

            }
            //�z�u�߂�
            if (Input.GetKey(KeyCode.G))
            {
                transform.position = new Vector3(10f, -3f, 0f);
            }
        }

        //�������f�u���ɔz�u
        if (collision.gameObject.tag == "debri_small")
        {
            //�j��
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(collision.gameObject);
                //�~�T�C��-1
                total_missle -= 1;
                //�~�T�C���j��
                Destroy(gameObject);
            }
            //�z�u�߂�
            if (Input.GetKey(KeyCode.G))
            {
                transform.position = new Vector3(10f, -3f, 0f);
            }


        }
        //���̑��̃I�u�W�F�N�g�ɔz�u���͍̌@���{�b�g�z�u�ς݃I�u�W�F�N�g
        if (collision.gameObject.tag != "debri_big" && collision.gameObject.tag != "debri_small" && collision.gameObject.tag == "MiningRobots")
        {
            //Debug.Log("�z�u�s��");
            transform.position = new Vector3(10f, -3f, 0f);


        }

    }



}
