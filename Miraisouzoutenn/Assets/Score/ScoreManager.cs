using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text m_NeedNum;
    public Text m_NowNum;

    public GameObject m_Earth;

    // Start is called before the first frame update
    void Start()
    {
        m_NeedNum.text = m_Earth.GetComponent<EarthScript>().GetNeedElectricity().ToString();
        m_NowNum.text = "0";

        
    }

    // Update is called once per frame
    void Update()
    {
        m_NowNum.text = m_Earth.GetComponent<EarthScript>().GetNowElectricity().ToString();
    }
}
