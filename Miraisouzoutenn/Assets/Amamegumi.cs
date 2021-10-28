using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Light { };

public class Amamegumi : MonoBehaviour
{
    List<Light> m_light;//光のリスト(光をエネルギーに返還するよう)
    //List<Energy> m_energy;//一個のアマメグミにエネルギーが集まったとき用
    Energy m_energy;//一個のアマメグミにエネルギーが集まったとき用

    private float m_totalenergy;//エネルギーの総量
    GameObject m_energyline;//エネルギーライン用オブジェクト(実験用)

    // Start is called before the first frame update
    void Start()
    {
        m_totalenergy = 0;
        //m_energy.Add(this.gameObject.GetComponent<Energy>());
        m_energyline = this.gameObject.transform.GetChild(0).gameObject;//子オブジェクトを取得
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
