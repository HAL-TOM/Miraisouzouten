using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialButton : MonoBehaviour
{
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
        //子オブジェクトのテキストを取得し、色を初期化
        m_Text = GetComponentInChildren<Text>();
        m_Text.color = new Color(BASE_COLOR_R, BASE_COLOR_G, BASE_COLOR_B, 1.0f);
        

        //イベント登録
        m_Trigger = this.GetComponent<EventTrigger>();

        // マウスが重なったら色変更のイベントを登録
        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => 
        {
            if (m_TutorialManager.GetChangeScene())
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
            if (m_TutorialManager.GetChangeScene())
                return;

            m_Text.color = new Color(BASE_COLOR_R, BASE_COLOR_G, BASE_COLOR_B, 1.0f);
            Debug.Log("PointerExit");
        });
        m_Trigger.triggers.Add(entry);

    }

    
    /// <summary>
    /// クリックされたら呼ばれる関数 自身のボタンタイプを知らせる
    /// </summary>
    public void OnClick()
    {
        
        Debug.Log("チュートリアルボタン　押された");
        //チュートリアルの説明切り替え中は処理されない
        if (m_TutorialManager.GetMoveFlag())
            return;

        Debug.Log("チュートリアルボタン　処理");
        //設定されたタイプをマネージャーに知らせる
        m_TutorialManager.SetType((int)m_Type);
    }

    /// <summary>
    /// 非アクティブになったら呼ばれる関数 色を初期化
    /// </summary>
    void OnDisable()
    {
        if (m_Text == null)
            return;

        m_Text.color = new Color(BASE_COLOR_R, BASE_COLOR_G, BASE_COLOR_B, 1.0f);
    }


}
