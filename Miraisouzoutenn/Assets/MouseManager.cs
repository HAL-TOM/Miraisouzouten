using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    static public MouseManager mouseManager;
    public enum MainState
    {
        ClickNon = 0,
        Drag,
        OnSetting,
        StateNum,

    }
    public MainState mainState;


    private ClickObj clickObj;

    // Start is called before the first frame update
    void Start()
    {
        clickObj = null;
        mouseManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch(mainState)
        {
            case MainState.ClickNon:
                
                break;
            case MainState.Drag:
                DragUpdate();

                if (Input.GetMouseButtonUp(0))
                {
                    if (clickObj != null)//menueItemがある
                    {
                        Ray ray = new Ray();
                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                        //ヒットしたすべてのオブジェクト情報を取得
                        foreach (RaycastHit hit in Physics.RaycastAll(ray))
                        {
                            if (hit.collider.transform.GetComponent<Mass>() != null)
                            {
                                Mass mass = hit.collider.transform.GetComponent<Mass>();
                                if(mass.obj==null)//配置してない
                                {


                                    if (clickObj.menuID.id==MenueID.ID.AMA)//アマメグミをクリックしている
                                    {

                                        hit.collider.transform.GetComponent<Mass>().SetObj(clickObj.transform.gameObject);
                                        clickObj.transform.position = hit.collider.transform.position + new Vector3(0.0f, 0.0f, -0.1f); ;

                                        SetState(MainState.OnSetting);
                                        return;
                                    }

                                    if (clickObj.menuID.id == MenueID.ID.REF)//反射衛星をクリックしている
                                    {

                                        hit.collider.transform.GetComponent<Mass>().SetObj(clickObj.transform.gameObject);
                                        clickObj.transform.position = hit.collider.transform.position + new Vector3(0.0f, 0.0f, -0.1f); ;

                                        SetState(MainState.OnSetting);
                                        return;
                                    }
                                    
                                }else//配置してある
                                {
                                    if (clickObj.menuID.id == MenueID.ID.SAI)//採掘ロボットをクリックしている
                                    {
                                        //マスにデプリが配置してある
                                    }
                                    if (clickObj.menuID.id == MenueID.ID.RCK)//ミサイルをクリックしている
                                    {
                                        //マスにデプリが配置してある
                                    }

                                }
                            }
                        }
                        clickObj.DesObj();
                        SetState(MainState.ClickNon);
                        break;

                    }
                    else
                    {
                        clickObj.DesObj();
                        SetState(MainState.ClickNon);
                        break;

                    }
                }
                break;
            case MainState.OnSetting:
                if (clickObj != null)
                {

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        RotateLeft();
                    }
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        RotateRight();
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {

                        SetState(MainState.ClickNon);
                    }

                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        
                        SetState(MainState.ClickNon);
                        
                        clickObj.DesObj();
                    }
                    if (Input.GetKey(KeyCode.R))
                    {
                        RotateReset();
                    }
                }else
                {

                    SetState(MainState.ClickNon);
                }


                break;
        }

        
    }

    private void DragUpdate()
    {
        //位置をワールド座標からスクリーン座標に変換して、objectPointに格納
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(clickObj.transform.position);

        //現在位置(マウス位置)を、pointScreenに格納
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z);

        //現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //位置を、pointWorldにする
        clickObj.transform.position = pointWorld;
    }

    public void SetState(MainState state)
    {
        mainState = state;
    }

    void RotateRight()
    {
        clickObj.transform.Rotate(new Vector3(0, 0, 1), -45.0f);
    }
    void RotateLeft()
    {
        clickObj.transform.Rotate(new Vector3(0, 0, 1), 45.0f);

    }
    void RotateReset()
    {

        clickObj.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    public void SetClickObj(ClickObj set) { clickObj = set; }
}
