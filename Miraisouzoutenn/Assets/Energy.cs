using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] float m_length_limit = 10.0f;//長さの設定
    Vector3 m_direction;//方向ベクトル
    float m_energy;//現在のエネルギー

    float m_orijinlength;//もとのエネルギー(電力)の長さ
    float m_length;//現在のエネルギー(電力)長さ

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
