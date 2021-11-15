using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public enum BUTTON_TYPE
    {
        GAME_START,
        TUTORIAL,
        EXIT
    };


    public GameObject m_Fade;
    FadeManager m_FadeManager;

    bool m_ChageScene;
    bool m_FadeStarted;
    int m_SceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        m_ChageScene = false;
        m_FadeStarted = false;
        m_SceneIndex = -1;

        m_FadeManager = m_Fade.GetComponent<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[����������V�[���؂�ւ��J�n
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_ChageScene = true;
        }

        //�V�[���؂�ւ����^�Ȃ�
        if (m_ChageScene)
        {
            //�t�F�[�h���n�܂��Ă��邩�ǂ���
            if (m_FadeStarted)
            {
                //�t�F�[�h�����Ɏn�܂�A�I����Ă�����V�[���؂�ւ�
                if (!m_FadeManager.GetIsFade())
                    switch(m_SceneIndex)
                    {
                        case (int)BUTTON_TYPE.GAME_START:
                            Debug.Log("GAME_START��������܂���");
                            //SceneManager.LoadScene("StageSelect");////////////////////////�K�؂ȃV�[���̖��O�ɕύX
                            break;

                        case (int)BUTTON_TYPE.TUTORIAL:
                            Debug.Log("TUTORIAL��������܂���");
                            SceneManager.LoadScene("Tutorial");////////////////////////�K�؂ȃV�[���̖��O�ɕύX
                            break;

                        case (int)BUTTON_TYPE.EXIT:
                            Debug.Log("EXIT��������܂���");
                            Application.Quit();
                            break;
                    }
                    
            }
            else
            {
                //��x�����t�F�[�h�A�E�g���Ă�
                m_FadeManager.StartFadeOut();
                m_FadeStarted = true;
            }
        }
    }

    public void SetChangeScene(int index)
    {
        m_ChageScene = true;
        m_SceneIndex = index;
    }

}
