using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    /// <summary>
    /// 定数
    /// </summary>
    public enum BUTTON_TYPE
    {
        TITLE,
        GAME_START,
        BACK,
        NEXT,
    };

    public enum READ_STATUS
    {
        BEFORE_INIT = -1,
        INIT,
        COMPLETE,
    };


    const float BASE_POS_X = 0.0f;
    const float BASE_POS_Y = 75.0f;

    const float CHANGE_AMOUNT = 1840.0f;
    
    //const float MOVE_SPEED = 800.0f;

    /// <summary>
    /// メンバ変数
    /// </summary>
    public GameObject m_Fade;
    public float MOVE_SPEED;


//    FadeManager m_FadeManager;

    bool m_ChageScene;
    bool m_FadeStarted;
    bool m_MoveFlag;

    int m_ButtonType;

    public GameObject m_Sprite1;
    public GameObject m_Sprite2;

    public GameObject m_StartButton;
    public GameObject m_BackButton;
    public GameObject m_NextButton;


    Image m_Sp1Image;
    Image m_Sp2Image;


    Vector3 m_Sp1Start;
    Vector3 m_Sp1End;
    Vector3 m_Sp2Start;
    Vector3 m_Sp2End;

    int m_TextureIndex;

    float m_Time;

    bool m_Sp1Disp;

    Sprite[] m_Textures;

    public static int m_ReadAll = (int)READ_STATUS.BEFORE_INIT;

    // Start is called before the first frame update
    void Start()
    {
        //各変数初期化
        m_ChageScene = false;
        m_FadeStarted = false;
        m_MoveFlag = false;
        m_ButtonType = -1;
  //      m_FadeManager = m_Fade.GetComponent<FadeManager>();

        m_Sp1Start = new Vector3(0.0f, 0.0f, 0.0f);
        m_Sp1End = new Vector3(0.0f, 0.0f, 0.0f);
        m_Sp2Start = new Vector3(0.0f, 0.0f, 0.0f);
        m_Sp2End = new Vector3(0.0f, 0.0f, 0.0f);

        m_Time = 0.0f;
        m_TextureIndex = 0;

        m_Sp1Disp = true;

        m_Sp1Image = m_Sprite1.GetComponent<Image>();
        m_Sp2Image = m_Sprite2.GetComponent<Image>();

        m_Textures = Resources.LoadAll<Sprite>("Tutorial");
        m_Sp1Image.sprite = m_Textures[0];

        //初回起動時のみm_ReadAllを初期化
        if (m_ReadAll == (int)READ_STATUS.BEFORE_INIT)
            m_ReadAll = (int)READ_STATUS.INIT;


        //チュートリアルを全て読んでいたら、最初からスタートボタンをアクティブに
        if (m_ReadAll == (int)READ_STATUS.COMPLETE)
            m_StartButton.SetActive(true);
        else
            m_StartButton.SetActive(false);

        //戻るボタンは最初は非アクティブ
        m_BackButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SceneManagement();
        LerpingSprite();
        ButtonManagement();
    }

    /// <summary>
    /// フェードとシーン遷移管理
    /// </summary>
    void SceneManagement()
    {
        //シーン切り替えが真なら
        if (m_ChageScene)
        {
            //フェードが始まっているかどうか
            if (m_FadeStarted)
            {
                //フェードが既に始まり、終わっていたらシーン切り替え
         //       if (!m_FadeManager.GetIsFade())
                    switch (m_ButtonType)
                    {
                        case (int)BUTTON_TYPE.TITLE:
                            SceneManager.LoadScene("Title");
                            break;

                        case (int)BUTTON_TYPE.GAME_START:
                            //if (!(m_ReadAll == 1))
                            //    return;

                            //SceneManager.LoadScene("StageSelect");////////////////////////適切なシーンの名前に変更
                            break;
                    }


            }
            else
            {
                //一度だけフェードアウトを呼ぶ
   //             m_FadeManager.StartFadeOut();
                m_FadeStarted = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("リードオール" + m_ReadAll);
    }
   
    /// <summary>
    /// スプライトの移動アニメーション
    /// </summary>
    void LerpingSprite()
    {
        //次へボタンが押されたら
        if (m_ButtonType == (int)BUTTON_TYPE.NEXT)
        {
            if ((m_TextureIndex + 1) >= m_Textures.Length)
                return;

            m_TextureIndex++;

            if (m_Sp1Disp)
            {
                //スプライト1が表示されていたら
                m_Sp1Start = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);
                m_Sp1End = new Vector3(-CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp2Start = new Vector3(CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp2End = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);

                m_Sp2Image.sprite = m_Textures[m_TextureIndex];
            }
            else
            {
                //スプライト2が表示されていたら
                m_Sp1Start = new Vector3(CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp1End = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);
                m_Sp2Start = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);
                m_Sp2End = new Vector3(-CHANGE_AMOUNT, BASE_POS_Y, 0.0f);

                m_Sp1Image.sprite = m_Textures[m_TextureIndex];
            }


            m_Sprite1.transform.localPosition = m_Sp1Start;
            m_Sprite2.transform.localPosition = m_Sp2Start;

            m_ButtonType = -1;
            m_MoveFlag = true;

        }

        //戻るボタンが押されたら
        if (m_ButtonType == (int)BUTTON_TYPE.BACK)
        {
            if ((m_TextureIndex - 1) < 0)
                return;

            m_TextureIndex--;

            if (m_Sp1Disp)
            {
                //スプライト1が表示されていたら
                m_Sp1Start = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);
                m_Sp1End = new Vector3(CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp2Start = new Vector3(-CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp2End = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);

                m_Sp2Image.sprite = m_Textures[m_TextureIndex];
            }
            else
            {
                //スプライト2が表示されていたら
                m_Sp1Start = new Vector3(-CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp1End = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);
                m_Sp2Start = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);
                m_Sp2End = new Vector3(CHANGE_AMOUNT, BASE_POS_Y, 0.0f);

                m_Sp1Image.sprite = m_Textures[m_TextureIndex];
            }


            m_Sprite1.transform.localPosition = m_Sp1Start;
            m_Sprite2.transform.localPosition = m_Sp2Start;

            m_ButtonType = -1;
            m_MoveFlag = true;

        }

        //ラープで動かす処理
        if (m_MoveFlag)
        {
            m_Time += Time.deltaTime;

            float distance = Vector3.Distance(m_Sp1Start, m_Sp1End);
            float location = (m_Time * MOVE_SPEED) / distance;



            m_Sprite1.transform.localPosition = Vector3.Lerp(m_Sp1Start, m_Sp1End, location);


            distance = Vector3.Distance(m_Sp2Start, m_Sp2End);
            location = (m_Time * MOVE_SPEED) / distance;

            m_Sprite2.transform.localPosition = Vector3.Lerp(m_Sp2Start, m_Sp2End, location);

            if (location >= 1.0f)
            {
                Debug.Log("reset");
                m_Time = 0.0f;
                m_MoveFlag = false;
                m_Sp1Disp = !(m_Sp1Disp);
            }
        }

    }

    
    /// <summary>
    /// ボタンのアクティブ管理
    /// </summary>
    void ButtonManagement()
    {

        if ((m_TextureIndex + 1) == m_Textures.Length)
        {
            m_ReadAll = (int)READ_STATUS.COMPLETE;
            m_NextButton.SetActive(false);
        }
        else
            m_NextButton.SetActive(true);

        if (m_TextureIndex == 0)
            m_BackButton.SetActive(false);
        else
            m_BackButton.SetActive(true);

        if (m_ReadAll == (int)READ_STATUS.COMPLETE)
            m_StartButton.SetActive(true);
    }
    
    /// <summary>
    /// セッター
    /// </summary>
    public void SetType(int type)
    {
        if(type <= (int)BUTTON_TYPE.GAME_START)
            m_ChageScene = true;
        m_ButtonType = type;
    }

    public bool GetMoveFlag()
    {
        return m_MoveFlag;
    }

    /// <summary>
    /// ゲッター
    /// </summary>
    public bool GetChangeScene()
    {
        return m_ChageScene;
    }

    public int GetReadAll()
    {
        return m_ReadAll;
    }

    public bool GetTextureIndexMin()
    {
        if (m_TextureIndex == 0)
            return true;

        return false;
    }

    public bool GetTextureIndexMax()
    {
        if (m_TextureIndex == m_Textures.Length - 1)
            return true;

        return false;
    }
}
