using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CleareButton : MonoBehaviour
{
    //���̃X�e�[�W�̖��O���i�[
    public string NextStage;

    //�^�C�g���J��
    public void Title() {
        
		SceneManager.LoadScene ("Title");

    }
    //Next Stage
    public void NextGame()
    {
        //���̃X�e�[�W�̖��O�����
        SceneManager.LoadScene(NextStage);
        
    }
    //Stage Select
    public void StageSelect()
    {
        SceneManager.LoadScene("StageSelect");
        //SceneManager.LoadScene("StageSelect");/////�X�e�[�W�I����ʃv���W�F�N�g��
    }


}
