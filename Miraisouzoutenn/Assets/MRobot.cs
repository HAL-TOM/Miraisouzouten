using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRobot : MonoBehaviour
{
    public Debri debri = null;
    bool m_lighthit;
    // Start is called before the first frame update
    void Start()
    {
        m_lighthit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLightHit(bool hit)
    {
        m_lighthit = hit;
    }
}
