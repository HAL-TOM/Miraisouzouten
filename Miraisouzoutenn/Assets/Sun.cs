using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public GameObject m_object;
    GameObject m_a;

    // Start is called before the first frame update
    void Start()
    {
        m_a = Instantiate(m_object);
        m_a.GetComponent<SunLight>().SetAll(this.gameObject, new Vector3(1.0f, -1.0f, 0.0f), 10.0f, 10.0f);
        m_a = Instantiate(m_object);
        m_a.GetComponent<SunLight>().SetAll(this.gameObject, new Vector3(-1.0f, -1.0f, 0.0f), 10.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
