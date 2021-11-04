using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Amamegumi : MonoBehaviour
{
    [SerializeField]List<SunLight> m_lights;//光のリスト(光をエネルギーに返還するよう)
    [SerializeField]List<Energy> m_energies;//一個のアマメグミにエネルギーが集まったとき用
    [SerializeField] Energy m_energy;//アマメグミのエネルギー

    [SerializeField]private float m_totalenergy;//エネルギーの総量
    [SerializeField] GameObject m_energyline;//エネルギーライン用オブジェクト(実験用)

    // Start is called before the first frame update
    void Start()
    {
        m_totalenergy = 0;
        m_lights = new List<SunLight>();
        m_energies = new List<Energy>();
        m_energyline = this.gameObject.transform.GetChild(0).gameObject;//子オブジェクトを取得
        m_energy = m_energyline.GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {

        PointSum();//ポイント計算
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

            //エネルギーラインを表示
            m_energyline.SetActive(true);
        }else
        {

            //エネルギーラインを非表示
            m_energyline.SetActive(false);
        }
    }


    //光が当たっていたら
    public void HitLight(SunLight inL)//光が当たった時に呼ばれる
    {
        foreach (SunLight light in m_lights)
        {
            if (light == inL)
            {
                //既にHitしている
                return;
            }
        }

        //光のリストに追加
        m_lights.Add(inL);
    }

    //光が当たらなくなったら
    public void OutLight(SunLight inL)
    {
        foreach (SunLight light in m_lights)
        {
            if (light == inL)
            {
                //既にHitしている
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
                //既にHitしている
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
                //既にHitしている
                m_energies.Remove(ene);
                return;
            }
        }

    }
}
