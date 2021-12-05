using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseStage : MonoBehaviour
{
    public int stage_num = 1;           //�������X�e�[�W���̕ϐ�
    public GameObject[] StageBox;   //�X�e�[�W�I���{�^���i�[�p

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < StageBox.Length; i++)       // �{�^���̐������m�F
        {
            if(stage_num >= i + 2)                      //�������Ă���X�e�[�W���\��
            {
                StageBox[i].SetActive(true);            //����X�e�[�W�\��
            }
        }
    }

    //�N���A���Ȃǂɉ���X�e�[�W�𑝂₷
    public void AddReleseStageNum()
    {
        stage_num += 1;
    }

    //���݂̏�Ԃ�n��
    public int GetReleseStageNum()
    {
        return stage_num;
    }
}
