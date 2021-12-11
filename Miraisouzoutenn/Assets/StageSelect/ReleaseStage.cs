using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseStage : MonoBehaviour
{
    public static int stageNum = 1;           //�������X�e�[�W���̕ϐ�
    public GameObject[] StageBox;             //�X�e�[�W�I���{�^���\���p
    public GameObject[] StageBoxN;            //�X�e�[�W���b�N�{�^����\���p
    public GameObject[] UnlockBoxN;           //���b�N�A�j���[�V������\��

    // Start is called before the first frame update
    void Start()
    {
        SaveStageData data = new SaveStageData();
        SaveManager.LordStage("SaveReleaseStage.text", ref data);
        stageNum = data.m_score;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < StageBox.Length; i++)       // �{�^���̐������m�F
        {
            if(stageNum >= i + 2)                       //�������Ă���X�e�[�W���\��
            {
                StageBox[i].SetActive(true);            //����X�e�[�W�\��
                StageBoxN[i].SetActive(false);          //��\��
            }

            if (stageNum >= i + 3)                       //�������Ă���X�e�[�W���\��
            {
                UnlockBoxN[i].SetActive(false);
            }

        }

        //�����Z�b�g
        if (Input.GetKey(KeyCode.Escape))
        {
            SaveStageData data = new SaveStageData();
            data.m_score = 1;
            SaveManager.SaveStage("SaveReleaseStage.text", ref data);
        }
    }

    public void AddReleseStageNum()
    {
        stageNum += 1;
    }

    //���݂̏�Ԃ�n��
    public int GetReleseStageNum()
    {
        return stageNum;
    }
}
