using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueItem : MonoBehaviour
{
    [SerializeField] private GameObject m_Res;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click()//ƒNƒŠƒbƒN‚³‚ê‚½‚ç
    {

        if (MouseManager.mouseManager.mainState == MouseManager.MainState.ClickNon)
        {
            if(OnClick())
            {

                MouseManager.mouseManager.SetState(MouseManager.MainState.Drag);
            }
        }
    }
    public bool OnClick()
    {

        Create();
        return true;
    }
    private void Create()
    {

        GameObject instance = Instantiate(
            m_Res,                                     
            transform.position,
            Quaternion.identity) as GameObject;

        instance.AddComponent<ClickObj>();

        MouseManager.mouseManager.SetClickObj(instance.GetComponent<ClickObj>());
    }

}
