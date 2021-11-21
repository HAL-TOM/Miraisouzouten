using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
<<<<<<< HEAD
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

=======
    public ClickObj clickObj;
    public float spinSpeed;

    Quaternion targetRot;
>>>>>>> b7531f0bcdf936c10ddf8be958915ef396d690ef
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

<<<<<<< HEAD
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

                                        hit.collider.transform.GetComponent<Mass>().SetObj(clickObj.transform.gameObject);
                                        clickObj.transform.position = hit.collider.transform.position + new Vector3(0.0f, 0.0f, -0.1f); ;
                                        clickObj.transform.localScale =
                                            new Vector3(
                                                Mass.massManager.scale.x* hit.collider.transform.localScale.x,
                                                Mass.massManager.scale.y * hit.collider.transform.localScale.y,
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
                                                Mass.massManager.scale.x * hit.collider.transform.localScale.x,
                                                Mass.massManager.scale.y * hit.collider.transform.localScale.y,
                                                1.0f);
                                        SetState(MainState.OnSetting);
                                        return;
                                    }
                                    
                                }else//�z�u���Ă���
                                {
                                    if (clickObj.menuID.id == MenueID.ID.SAI)//�̌@���{�b�g���N���b�N���Ă���
                                    {
                                        if(true)//�}�X�Ƀf�v�����z�u���Ă���
                                        {
                                            if (true)//�f�v���ɍ̌@���{�b�g���z�u���ĂȂ�
                                            {

                                            }
                                        }
                                    }
                                    if (clickObj.menuID.id == MenueID.ID.RCK)//�~�T�C�����N���b�N���Ă���
                                    {
                                        
                                        if (true)//�}�X�Ƀf�v�����z�u���Ă���
                                        {

                                        }
                                    }
                                }
                            }
                        }
                        clickObj.DesObj();
                        SetState(MainState.ClickNon);
                        break;
=======
            if (Input.GetKey(KeyCode.A))
            {
                RotateLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                RotateRight();
                //RotateRight45();
            }
            if (Input.GetKey(KeyCode.R))
            {
                RotateReset();
            }
        }
    }
    void ClickCheeck()
    {
        if (Input.GetMouseButtonDown(0))
        {
>>>>>>> b7531f0bcdf936c10ddf8be958915ef396d690ef

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
<<<<<<< HEAD
    public void SetClickObj(ClickObj set) { clickObj = set; }
=======

    void RotateRight45()
    {
        targetRot = Quaternion.AngleAxis(45.0f, Vector3.forward);
        clickObj.transform.localRotation = Quaternion.Lerp(clickObj.transform.rotation, targetRot, spinSpeed * Time.deltaTime);
    }

    void RotateLeft45()
    {

    }
>>>>>>> b7531f0bcdf936c10ddf8be958915ef396d690ef
}
