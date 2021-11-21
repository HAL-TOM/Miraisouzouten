using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManager : MonoBehaviour
{ 
    public Vector2 scale;
    // Start is called before the first frame update
    void Start()
    {
      
        Mass.massManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
