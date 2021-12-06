using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EarthScript : MonoBehaviour
{
    GameObject[] m_object;

    //�d��
    public float Electricity = 0;
    //�K�v�d�͐�
    public float NeedElectricity;
    //�N���A����
    public bool Clear;

    bool m_hit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_object = GameObject.FindGameObjectsWithTag("Energy");
        Electricity = 0;
        foreach (GameObject gobject in m_object)
        {
            if(gobject.GetComponent<Energy>().GetHit())
            {
                Electricity += gobject.GetComponent<Energy>().GetValue();
            }
        }

        //Electricity = �d��
        AddElectricity();

        if (NeedElectricity <= Electricity)
        {
            Clear = true;
        }
        else
        {
            Clear = false;
        }

        if(Clear == true)
        {
            SceneManager.LoadScene("Cleare");
        }
    }

    public void AddElectricity()
    {

    }

    public float GetNeedElectricity()
    {
        return NeedElectricity;
    }
    public float GetNowElectricity()
    {
        return Electricity;
    }

}
