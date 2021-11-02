using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGameManager : MonoBehaviour
{
    public light[] lights;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ClearCheck())
        {
            Clear();
        }
    }
    private bool ClearCheck()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if(lights[i].Hit==false)
            {
                return false;
            }
            
        }
        return true;
    }
    public void Clear()
    {
        Debug.Log("clear");
        this.enabled = false;
    }

}
