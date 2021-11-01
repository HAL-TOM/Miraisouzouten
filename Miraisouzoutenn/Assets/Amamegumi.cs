using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Amamegumi : MonoBehaviour
{
    List<SunLight> m_lights;//���̃��X�g(�����G�l���M�[�ɕԊ҂���悤)
    List<Energy> m_energies;//��̃A�}���O�~�ɃG�l���M�[���W�܂����Ƃ��p
    Energy m_energy;//�A�}���O�~�̃G�l���M�[

    private float m_totalenergy;//�G�l���M�[�̑���
    GameObject m_energyline;//�G�l���M�[���C���p�I�u�W�F�N�g(�����p)

    // Start is called before the first frame update
    void Start()
    {
        m_totalenergy = 0;
        m_lights = new List<SunLight>();
        m_energies = new List<Energy>();
        m_energyline = this.gameObject.transform.GetChild(0).gameObject;//�q�I�u�W�F�N�g���擾
        m_energy = m_energyline.GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        m_totalenergy = 0;


        if (m_lights.Count > 0)
        {
            foreach (SunLight light in m_lights)
            {
                m_totalenergy += light.GetValue();
            }
            m_energy.SetValue(m_totalenergy);
            Debug.Log(m_lights.Count);
            Debug.Log(m_totalenergy);
            Debug.Log(m_energyline.GetComponent<Energy>().GetValue());
        }

        if (m_energies.Count > 0)
        {
            foreach (Energy energy in m_energies)
            {
                m_totalenergy += energy.GetValue() - 1;
            }
            m_energy.SetValue(m_totalenergy);
            Debug.Log(m_lights.Count);
            Debug.Log(m_totalenergy);
        }


        if (m_energy.GetValue() > 0)
        {

            //GameObject obj = (GameObject)Resources.Load("Energy");

            //// �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
            //GameObject instance = (GameObject)Instantiate(obj,
            //                                              new Vector3(
            //                                              this.gameObject.transform.position.x,
            //                                              this.gameObject.transform.position.y,
            //                                              this.gameObject.transform.position.z),
            //                                              Quaternion.identity);
        }
        
    }

    //�����������Ă�����
    public void HitLight(SunLight inL)//���������������ɌĂ΂��
    {
        foreach (SunLight light in m_lights)
        {
            if (light == inL)
            {
                //����Hit���Ă���
                return;
            }
        }

        //if (Vector3.Dot(-transform.up, inL.m_Direction) > 0)
        //{
        //    Debug.Log("HitLight");
        //    //���̃��X�g�ɒǉ�
        //    m_lights.Add(inL);
        //    //�G�l���M�[���C����\��
        //    m_energyline.SetActive(true);
        //    //���̒l���G�l���M�[�Ɏ擾
        //    m_energyline.GetComponent<Energy>().SetValue(inL.GetComponent<SunLight>().GetValue());

        //    //GameObject obj = (GameObject)Resources.Load("Energy");

        //    //// �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
        //    //m_energyline = (GameObject)Instantiate(obj,
        //    //    new Vector3(
        //    //        this.gameObject.transform.position.x,
        //    //        this.gameObject.transform.position.y +
        //    //             obj.GetComponent<Energy>().GetLengthLimit(),
        //    //        this.gameObject.transform.position.z),
        //    //        Quaternion.identity);

        //    //obj.GetComponent<Energy>().DestroyEnergy();
        //}

        Debug.Log("HitLight");
        //���̃��X�g�ɒǉ�
        m_lights.Add(inL);
        //�G�l���M�[���C����\��
        m_energyline.SetActive(true);
        //���̒l���G�l���M�[�Ɏ擾
        m_energyline.GetComponent<Energy>().SetValue(inL.GetComponent<SunLight>().GetValue());
    }

    //����������Ȃ��Ȃ�����
    public void OutLight(SunLight inL)
    {
        m_lights.Remove(inL);
        //m_energyline.GetComponent<Energy>().DestroyEnergy();
        m_energyline.SetActive(false);
    }

    public void HitEnergy(Energy ene)
    {
        foreach (Energy energy in m_energies)
        {
            if (energy == ene)
            {
                //����Hit���Ă���
                return;
            }
        }
        Debug.Log("HitEnergy");
        m_energies.Add(ene);
        m_energyline.SetActive(true);
        m_energyline.GetComponent<Energy>().SetValue(ene.GetComponent<Energy>().GetValue());

        //if (Vector3.Dot(-transform.up, ene.GetDirection()) > 0)
        //{
        //    Debug.Log("HitEnergy");
        //    m_energies.Add(ene);
        //}
    }


    //
    public void OutEnergy(Energy ene)
    {
        foreach (Energy energy in m_energies)
        {
            if (energy == ene)
            {
                //����Hit���Ă���
                m_energies.Remove(ene);
                //m_energyline.GetComponent<Energy>().DestroyEnergy();
                m_energyline.SetActive(false);
            }
        }
    }
}
