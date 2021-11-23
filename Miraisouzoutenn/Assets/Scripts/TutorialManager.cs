using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    /// <summary>
    /// �萔
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
    /// �����o�ϐ�
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
        //�e�ϐ�������
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

        //����N�����̂�m_ReadAll��������
        if (m_ReadAll == (int)READ_STATUS.BEFORE_INIT)
            m_ReadAll = (int)READ_STATUS.INIT;


        //�`���[�g���A����S�ēǂ�ł�����A�ŏ�����X�^�[�g�{�^�����A�N�e�B�u��
        if (m_ReadAll == (int)READ_STATUS.COMPLETE)
            m_StartButton.SetActive(true);
        else
            m_StartButton.SetActive(false);

        //�߂�{�^���͍ŏ��͔�A�N�e�B�u
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
    /// �t�F�[�h�ƃV�[���J�ڊǗ�
    /// </summary>
    void SceneManagement()
    {
        //�V�[���؂�ւ����^�Ȃ�
        if (m_ChageScene)
        {
            //�t�F�[�h���n�܂��Ă��邩�ǂ���
            if (m_FadeStarted)
            {
                //�t�F�[�h�����Ɏn�܂�A�I����Ă�����V�[���؂�ւ�
         //       if (!m_FadeManager.GetIsFade())
                    switch (m_ButtonType)
                    {
                        case (int)BUTTON_TYPE.TITLE:
                            SceneManager.LoadScene("Title");
                            break;

                        case (int)BUTTON_TYPE.GAME_START:
                            //if (!(m_ReadAll == 1))
                            //    return;

                            //SceneManager.LoadScene("StageSelect");////////////////////////�K�؂ȃV�[���̖��O�ɕύX
                            break;
                    }


            }
            else
            {
                //��x�����t�F�[�h�A�E�g���Ă�
   //             m_FadeManager.StartFadeOut();
                m_FadeStarted = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("���[�h�I�[��" + m_ReadAll);
    }
   
    /// <summary>
    /// �X�v���C�g�̈ړ��A�j���[�V����
    /// </summary>
    void LerpingSprite()
    {
        //���փ{�^���������ꂽ��
        if (m_ButtonType == (int)BUTTON_TYPE.NEXT)
        {
            if ((m_TextureIndex + 1) >= m_Textures.Length)
                return;

            m_TextureIndex++;

            if (m_Sp1Disp)
            {
                //�X�v���C�g1���\������Ă�����
                m_Sp1Start = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);
                m_Sp1End = new Vector3(-CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp2Start = new Vector3(CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp2End = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);

                m_Sp2Image.sprite = m_Textures[m_TextureIndex];
            }
            else
            {
                //�X�v���C�g2���\������Ă�����
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

        //�߂�{�^���������ꂽ��
        if (m_ButtonType == (int)BUTTON_TYPE.BACK)
        {
            if ((m_TextureIndex - 1) < 0)
                return;

            m_TextureIndex--;

            if (m_Sp1Disp)
            {
                //�X�v���C�g1���\������Ă�����
                m_Sp1Start = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);
                m_Sp1End = new Vector3(CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp2Start = new Vector3(-CHANGE_AMOUNT, BASE_POS_Y, 0.0f);
                m_Sp2End = new Vector3(BASE_POS_X, BASE_POS_Y, 0.0f);

                m_Sp2Image.sprite = m_Textures[m_TextureIndex];
            }
            else
            {
                //�X�v���C�g2���\������Ă�����
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

        //���[�v�œ���������
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
    /// �{�^���̃A�N�e�B�u�Ǘ�
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
    /// �Z�b�^�[
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
    /// �Q�b�^�[
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
