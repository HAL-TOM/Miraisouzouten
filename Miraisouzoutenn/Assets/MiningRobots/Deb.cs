using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deb : MonoBehaviour
{
    public bool m_flag;

    // Start is called before the first frame update
    void Start()
    {
        m_flag = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            m_flag = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            m_flag = true;
        }

    }

    public bool GetFlag()
    {
        return m_flag;
    }
}
