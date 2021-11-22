using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButtonController : MonoBehaviour
{
    public BaseButtonController button;

    public void OnClick()
    {
        if (button == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
        // ���g�̃I�u�W�F�N�g����n��
        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectName)
    {
        // �Ă΂�邱�Ƃ͂Ȃ�
        Debug.Log("Base Button");
    }

}
