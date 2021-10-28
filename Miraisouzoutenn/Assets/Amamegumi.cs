using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Light { };

public class Amamegumi : MonoBehaviour
{
    List<Light> m_light;//���̃��X�g(�����G�l���M�[�ɕԊ҂���悤)
    //List<Energy> m_energy;//��̃A�}���O�~�ɃG�l���M�[���W�܂����Ƃ��p
    Energy m_energy;//��̃A�}���O�~�ɃG�l���M�[���W�܂����Ƃ��p

    private float m_totalenergy;//�G�l���M�[�̑���
    GameObject m_energyline;//�G�l���M�[���C���p�I�u�W�F�N�g(�����p)

    // Start is called before the first frame update
    void Start()
    {
        m_totalenergy = 0;
        //m_energy.Add(this.gameObject.GetComponent<Energy>());
        m_energyline = this.gameObject.transform.GetChild(0).gameObject;//�q�I�u�W�F�N�g���擾
        m_energy = m_energyline.GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_totalenergy > 0)
        {
            m_energyline.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            m_totalenergy += 1.0f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_energy.SetEnergy(1.0f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_totalenergy = m_energy.GetEnergy();
        }
    }

}
