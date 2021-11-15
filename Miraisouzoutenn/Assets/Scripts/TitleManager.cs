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
        //キーを押したらシーン切り替え開始
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_ChageScene = true;
        }

        //シーン切り替えが真なら
        if (m_ChageScene)
        {
            //フェードが始まっているかどうか
            if (m_FadeStarted)
            {
                //フェードが既に始まり、終わっていたらシーン切り替え
                if (!m_FadeManager.GetIsFade())
                    switch(m_SceneIndex)
                    {
                        case (int)BUTTON_TYPE.GAME_START:
                            Debug.Log("GAME_STARTが押されました");
                            //SceneManager.LoadScene("StageSelect");////////////////////////適切なシーンの名前に変更
                            break;

                        case (int)BUTTON_TYPE.TUTORIAL:
                            Debug.Log("TUTORIALが押されました");
                            SceneManager.LoadScene("Tutorial");////////////////////////適切なシーンの名前に変更
                            break;

                        case (int)BUTTON_TYPE.EXIT:
                            Debug.Log("EXITが押されました");
                            Application.Quit();
                            break;
                    }
                    
            }
            else
            {
                //一度だけフェードアウトを呼ぶ
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
