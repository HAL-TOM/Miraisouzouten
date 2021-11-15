using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour
{
    public TitleManager m_TitleManager;
    public TitleManager.BUTTON_TYPE m_Tyep;

    public void OnClick()
    {
        m_TitleManager.SetChangeScene((int)m_Tyep);
    }
}
