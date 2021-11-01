using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject m_object;
    float m_score;
    Text m_text;
    List<Energy> m_energies;

    // Start is called before the first frame update
    void Start()
    {
        m_score = 0.0f;
        m_energies = new List<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        m_score = 0.0f;

        if (m_energies.Count > 0)
        {
            foreach (Energy energy in m_energies)
            {
                m_score = energy.GetValue();
            }
        }

        if(m_score > 0.0f)
        {
            m_object.SetActive(true);
            m_object.GetComponent<Text>().text = m_score.ToString();
        }
    }
    public void HitEnergy(Energy ene)
    {
        foreach (Energy energy in m_energies)
        {
            if (energy == ene)
            {
                //Šù‚ÉHit‚µ‚Ä‚¢‚é
                return;
            }
        }
        Debug.Log("HitEnergy");
        m_energies.Add(ene);
    }


    //
    public void OutEnergy(Energy ene)
    {
        foreach (Energy energy in m_energies)
        {
            if (energy == ene)
            {
                //Šù‚ÉHit‚µ‚Ä‚¢‚é
                DestroyEnergy(ene);
                return;
            }
        }
    }

    public void DestroyEnergy(Energy ene)
    {
        m_energies.Remove(ene);
        m_object.SetActive(false);
        m_score = 0;
    }
}
