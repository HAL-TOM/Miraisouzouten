using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Amamegumi : MonoBehaviour
{
    [SerializeField]List<SunLight> m_lights;//���̃��X�g(�����G�l���M�[�ɕԊ҂���悤)
    [SerializeField]List<Energy> m_energies;//��̃A�}���O�~�ɃG�l���M�[���W�܂����Ƃ��p
    [SerializeField] Energy m_energy;//�A�}���O�~�̃G�l���M�[

    [SerializeField]private float m_totalenergy;//�G�l���M�[�̑���
    [SerializeField] GameObject m_energyline;//�G�l���M�[���C���p�I�u�W�F�N�g(�����p)

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

        PointSum();//�|�C���g�v�Z
        LineCheck();

    }

    private void PointSum()
    {

        m_totalenergy = 0;
        if (m_lights.Count > 0)
        {
            foreach (SunLight light in m_lights)
            {
                m_totalenergy += light.GetValue();
            }
        }

        if (m_energies.Count > 0)
        {
            foreach (Energy energy in m_energies)
            {
                m_totalenergy += energy.GetValue() - 1;
            }
        }

        m_energy.SetValue(m_totalenergy);
    }
    private void LineCheck()
    {
        if(m_totalenergy>0)
        {

            //�G�l���M�[���C����\��
            m_energyline.SetActive(true);
        }else
        {

            //�G�l���M�[���C�����\��
            m_energyline.SetActive(false);
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

        //���̃��X�g�ɒǉ�
        m_lights.Add(inL);
    }

    //����������Ȃ��Ȃ�����
    public void OutLight(SunLight inL)
    {
        foreach (SunLight light in m_lights)
        {
            if (light == inL)
            {
                //����Hit���Ă���
                m_lights.Remove(inL);
                return;
            }
        }

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

        
        m_energies.Add(ene);
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
                return;
            }
        }

    }
}
