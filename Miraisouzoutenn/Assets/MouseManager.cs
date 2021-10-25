using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] ClickObj nowClick=null;
    [SerializeField] float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ClickCheck();//クリック処理

        if(Input.GetKeyDown(KeyCode.A))
            LeftRotate();
        if (Input.GetKeyDown(KeyCode.D))
            RightRotate();
        if (Input.GetKeyDown(KeyCode.R))
            ResetRotate();
    }
    public ClickObj GetClickObj()
    {
        return nowClick;
    }
    private void ClickCheck()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.GetComponent<ClickObj>() != null)
            {
                ClickObj onClick = hit.collider.gameObject.GetComponent<ClickObj>();
                if (nowClick == onClick)
                {
                    //既にクリックしているので何もしない
                }
                else
                {
                    //新しくクリックした
                    if (nowClick != null)//クリックしていたオブジェクトがある
                    {
                        nowClick.OutAction();//離した

                    }
                    nowClick = onClick;
                }

                onClick.OnAction();//クリックした

            }
        }
        else
        {
            if (nowClick != null)//クリックしていたオブジェクトがある
            {
                nowClick.OutAction();//離した
            }
            nowClick = null;
        }
    }

    private void LeftRotate()
    {
        if(nowClick!=null)
        {
            nowClick.transform.Rotate(new Vector3(0, 0, rotSpeed));
        }
    }
    private void RightRotate()
    {
        if (nowClick != null)
        {
            nowClick.transform.Rotate(new Vector3(0, 0, -rotSpeed));
        }
    }
    private void ResetRotate()
    {
        if (nowClick != null)
        {
            nowClick.transform.Rotate(new Vector3(0, 0, -rotSpeed));
        }
    }
}
