using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] float m_length_limit = 10.0f;//�����̐ݒ�
    Vector3 m_direction;//�����x�N�g��
    float m_energy;//���݂̃G�l���M�[

    float m_orijinlength;//���Ƃ̃G�l���M�[(�d��)�̒���
    float m_length;//���݂̃G�l���M�[(�d��)����

    // Start is called before the first frame update
    void Start()
    {
        m_orijinlength = m_length = 0.0f;
        m_direction = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnergy(float enegy)
    {
        m_energy = enegy;
    }

    public float GetEnergy()
    {
        return m_energy;
    }
}
