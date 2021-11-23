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
        //�q�I�u�W�F�N�g�̃e�L�X�g���擾���A�F��������
        m_Text = GetComponentInChildren<Text>();
        m_Text.color = new Color(BASE_COLOR_R, BASE_COLOR_G, BASE_COLOR_B, 1.0f);
        

        //�C�x���g�o�^
        m_Trigger = this.GetComponent<EventTrigger>();

        // �}�E�X���d�Ȃ�����F�ύX�̃C�x���g��o�^
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

        // �}�E�X���O�ꂽ��F�ύX�̃C�x���g��o�^
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
    /// �N���b�N���ꂽ��Ă΂��֐� ���g�̃{�^���^�C�v��m�点��
    /// </summary>
    public void OnClick()
    {
        
        Debug.Log("�`���[�g���A���{�^���@�����ꂽ");
        //�`���[�g���A���̐����؂�ւ����͏�������Ȃ�
        if (m_TutorialManager.GetMoveFlag())
            return;

        Debug.Log("�`���[�g���A���{�^���@����");
        //�ݒ肳�ꂽ�^�C�v���}�l�[�W���[�ɒm�点��
        m_TutorialManager.SetType((int)m_Type);
    }

    /// <summary>
    /// ��A�N�e�B�u�ɂȂ�����Ă΂��֐� �F��������
    /// </summary>
    void OnDisable()
    {
        if (m_Text == null)
            return;

        m_Text.color = new Color(BASE_COLOR_R, BASE_COLOR_G, BASE_COLOR_B, 1.0f);
    }


}
