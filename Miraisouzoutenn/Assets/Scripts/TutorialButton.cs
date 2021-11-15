using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    public TutorialManager m_TutorialManager;
    public TutorialManager.BUTTON_TYPE m_Type;

    public void OnClick()
    {
        Debug.Log("チュートリアルボタン　押された");
        if (m_TutorialManager.GetMoveFlag())
            return;

        Debug.Log("チュートリアルボタン　処理");
        m_TutorialManager.SetType((int)m_Type);
    }
}
