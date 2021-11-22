using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TitleButton : MonoBehaviour
{
    public TitleManager m_TitleManager;
    public TitleManager.BUTTON_TYPE m_Tyep;

    const float BASE_COLOR_R = 1.0f;
    const float BASE_COLOR_G = 1.0f;
    const float BASE_COLOR_B = 1.0f;


    const float CHANGED_COLOR_R = 1.0f;
    const float CHANGED_COLOR_G = 1.0f;
    const float CHANGED_COLOR_B = 0.0f;


    public TutorialManager m_TutorialManager;
    public TutorialManager.BUTTON_TYPE m_Type;

    Text m_Text;

    EventTrigger m_Trigger;
    

    private void Start()
    {
        m_Text = GetComponentInChildren<Text>();
        m_Text.color = new Color(BASE_COLOR_R, BASE_COLOR_G, BASE_COLOR_B, 1.0f);

        m_Trigger = this.GetComponent<EventTrigger>();

        // マウスが重なったら色変更のイベントを登録
        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => 
        {
            if(m_TitleManager.GetChageScene())
                return;

            m_Text.color = new Color(CHANGED_COLOR_R, CHANGED_COLOR_G, CHANGED_COLOR_B, 1.0f);
            Debug.Log("PointerEnter");
        });
        m_Trigger.triggers.Add(entry);

        // マウスが外れたら色変更のイベントを登録
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((data) => 
        {
            if (m_TitleManager.GetChageScene())
                return;

            m_Text.color = new Color(BASE_COLOR_R, BASE_COLOR_G, BASE_COLOR_B, 1.0f);
            Debug.Log("PointerExit");
        });
        m_Trigger.triggers.Add(entry);
    }

    /// <summary>
    /// クリックされたら呼ばれる関数
    /// </summary>
    public void OnClick()
    {
        m_TitleManager.SetChangeScene((int)m_Tyep);
    }
}
