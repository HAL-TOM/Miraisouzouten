using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj : MonoBehaviour
{

    [SerializeField]public bool click;
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
        Debug.Log("�N���b�N�F" + gameObject.name);
        click = true;

    }
    public void OutAction()
    {
        Debug.Log("�N���b�N�A�E�g�F" + gameObject.name);
        click = false;
    }
}
