using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj : MonoBehaviour
{
    public MenueID menuID;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnAction()
    {
    
    }
    public void OutAction()
    {

        Destroy(menuID);
        Destroy(this);
    }
    public void DesObj()
    {
        Destroy(gameObject);
    }
}
