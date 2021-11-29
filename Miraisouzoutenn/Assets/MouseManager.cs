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
                    if (clickObj != null)//menueItem������
                    {
                        Ray ray = new Ray();
                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                        foreach (RaycastHit hit in Physics.RaycastAll(ray))//�q�b�g�������ׂẴI�u�W�F�N�g�����擾
                        {
                            if (hit.collider.transform.GetComponent<Mass>() != null)
                            {
                                Mass mass = hit.collider.transform.GetComponent<Mass>();
                                if(mass.obj==null)//�z�u���ĂȂ�
                                {


                                    if (clickObj.menuID.id==MenueID.ID.AMA)//�A�}���O�~���N���b�N���Ă���
                                    {
                                        Debug.Log("ama");
                                        hit.collider.transform.GetComponent<Mass>().SetObj(clickObj.transform.gameObject);
                                        clickObj.transform.position = hit.collider.transform.position + new Vector3(0.0f, 0.0f, -0.1f); ;
                                        clickObj.transform.localScale =
                                            new Vector3(
                                                Mass.massManager.scale.x,
                                                Mass.massManager.scale.y,
                                                1.0f);
                                        SetState(MainState.OnSetting);
                                        return;
                                    }

                                    if (clickObj.menuID.id == MenueID.ID.REF)//���ˉq�����N���b�N���Ă���
                                    {

                                        hit.collider.transform.GetComponent<Mass>().SetObj(clickObj.transform.gameObject);
                                        clickObj.transform.position = hit.collider.transform.position + new Vector3(0.0f, 0.0f, -0.1f); ;
                                        clickObj.transform.localScale =
                                            new Vector3(
                                                Mass.massManager.scale.x,
                                                Mass.massManager.scale.y,
                                                1.0f);
                                        SetState(MainState.OnSetting);
                                        return;
                                    }
                                    
                                }else//�z�u���Ă���
                                {
                                    if (clickObj.menuID.id == MenueID.ID.SAI)//�̌@���{�b�g���N���b�N���Ă���
                                    {
                                        if(mass.obj.GetComponent<Debri>())//�}�X�Ƀf�v�����z�u���Ă���
                                        {
                                            Debri debri = mass.obj.GetComponent<Debri>();
                                            if (!debri.GetExist()) //�f�v���ɍ̌@���{�b�g���z�u���ĂȂ�
                                            {
                                                //�����Ńf�u��
                                                clickObj.transform.localScale =
                                                    new Vector3(
                                                        Mass.massManager.scale.x,
                                                        Mass.massManager.scale.y,
                                                        1.0f);
                                                clickObj.transform.position = hit.collider.transform.position + new Vector3(0.0f, Mass.massManager.scale.y/2.0f, -0.1f); ;
                                                clickObj.GetComponent<MRobot>().debri=debri;
                                                SetState(MainState.OnSetting);

                                                debri.SetExist(true);
                                                return;
                                            }
                                        }
                                    }
                                    else if (clickObj.menuID.id == MenueID.ID.RCK)//�~�T�C�����N���b�N���Ă���
                                    {

                                        if (mass.obj.GetComponent<Debri>())//�}�X�Ƀf�v�����z�u���Ă���
                                        {  
                                            clickObj.transform.localScale =
                                                new Vector3(
                                                    Mass.massManager.scale.x,
                                                    Mass.massManager.scale.y,
                                                    1.0f);
                                            clickObj.transform.position = hit.collider.transform.position + new Vector3(0.0f, Mass.massManager.scale.y / 2.0f, -0.1f); ;

                                            //�����Ńf�u��
                                            clickObj.GetComponent<Rocket>().debri = mass.obj.GetComponent<Debri>();
                                            SetState(MainState.OnSetting);
                                            return;
                                        }
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

                    if(clickObj.GetComponent<ReflectHygiene>() || clickObj.GetComponent<Amamegumi>()  )
                    {

                        if (Input.GetKey(KeyCode.A))
                        {
                            RotateLeft();
                        }
                        if (Input.GetKey(KeyCode.D))
                        {
                            RotateRight();
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (clickObj.transform.GetComponent<MRobot>())
                        {
                            clickObj.transform.GetComponent<MRobot>().debri.Break();
                            clickObj.DesObj();

                        }
                        if (clickObj.transform.GetComponent<Rocket>())
                        {
                            clickObj.transform.GetComponent<Rocket>().debri.Break();
                            clickObj.DesObj();
                        }
                        SetState(MainState.ClickNon);
                    }

                    if (Input.GetKeyDown(KeyCode.G))
                    {

                        SetState(MainState.ClickNon);

                        clickObj.DesObj();
                        Debug.Log("G");
                        
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
        //�ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(clickObj.transform.position);

        //���݈ʒu(�}�E�X�ʒu)���ApointScreen�Ɋi�[
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z);

        //���݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //�ʒu���ApointWorld�ɂ���
        clickObj.transform.position = pointWorld;
    }

    public void SetState(MainState state)
    {
        mainState = state;
    }

    void RotateRight()
    {
        clickObj.transform.Rotate(new Vector3(0, 0, 1), -1.0f);
    }
    void RotateLeft()
    {
        clickObj.transform.Rotate(new Vector3(0, 0, 1), 1.0f);

    }
    void RotateReset()
    {

        clickObj.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    public void SetClickObj(ClickObj set) { clickObj = set; }
}
