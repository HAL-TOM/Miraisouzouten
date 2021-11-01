using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Amamegumi : MonoBehaviour
{
    List<SunLight> m_lights;//光のリスト(光をエネルギーに返還するよう)
    List<Energy> m_energies;//一個のアマメグミにエネルギーが集まったとき用
    Energy m_energy;//アマメグミのエネルギー

    private float m_totalenergy;//エネルギーの総量
    GameObject m_energyline;//エネルギーライン用オブジェクト(実験用)

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

            //// プレハブを元にオブジェクトを生成する
            //GameObject instance = (GameObject)Instantiate(obj,
            //                                              new Vector3(
            //                                              this.gameObject.transform.position.x,
            //                                              this.gameObject.transform.position.y,
            //                                              this.gameObject.transform.position.z),
            //                                              Quaternion.identity);
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

        //if (Vector3.Dot(-transform.up, inL.m_Direction) > 0)
        //{
        //    Debug.Log("HitLight");
        //    //光のリストに追加
        //    m_lights.Add(inL);
        //    //エネルギーラインを表示
        //    m_energyline.SetActive(true);
        //    //光の値をエネルギーに取得
        //    m_energyline.GetComponent<Energy>().SetValue(inL.GetComponent<SunLight>().GetValue());

        //    //GameObject obj = (GameObject)Resources.Load("Energy");

        //    //// プレハブを元にオブジェクトを生成する
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
        //光のリストに追加
        m_lights.Add(inL);
        //エネルギーラインを表示
        m_energyline.SetActive(true);
        //光の値をエネルギーに取得
        m_energyline.GetComponent<Energy>().SetValue(inL.GetComponent<SunLight>().GetValue());
    }

    //光が当たらなくなったら
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
                //既にHitしている
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
                //既にHitしている
                m_energies.Remove(ene);
                //m_energyline.GetComponent<Energy>().DestroyEnergy();
                m_energyline.SetActive(false);
            }
        }
    }
}
