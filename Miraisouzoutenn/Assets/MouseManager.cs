using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    ClickObj nowClick=null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ClickCheck();//�N���b�N����
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

        //�}�E�X�N���b�N�����ꏊ����Ray���΂��A�I�u�W�F�N�g�������true 
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.GetComponent<ClickObj>() != null)
            {
                ClickObj onClick = hit.collider.gameObject.GetComponent<ClickObj>();
                if (nowClick == onClick)
                {
                    //���ɃN���b�N���Ă���̂ŉ������Ȃ�
                }
                else
                {
                    //�V�����N���b�N����
                    if (nowClick != null)//�N���b�N���Ă����I�u�W�F�N�g������
                    {
                        nowClick.OutAction();//������

                    }
                    nowClick = onClick;
                }

                onClick.OnAction();//�N���b�N����

            }
        }
        else
        {
            if (nowClick != null)//�N���b�N���Ă����I�u�W�F�N�g������
            {
                nowClick.OutAction();//������
            }
            nowClick = null;
        }
    }
}
