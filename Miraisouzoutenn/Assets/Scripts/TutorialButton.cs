using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    public TutorialManager m_TutorialManager;
    public TutorialManager.BUTTON_TYPE m_Type;

    public void OnClick()
    {
        Debug.Log("�`���[�g���A���{�^���@�����ꂽ");
        if (m_TutorialManager.GetMoveFlag())
            return;

        Debug.Log("�`���[�g���A���{�^���@����");
        m_TutorialManager.SetType((int)m_Type);
    }
}
