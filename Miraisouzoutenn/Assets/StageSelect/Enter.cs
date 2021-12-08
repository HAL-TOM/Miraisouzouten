using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//確認用
public class Enter : MonoBehaviour
{
    public static bool flag;    //クリア済み判定
    public int scoreLev;        //クリア評定
    public int scoreAllAdd = 0; //クリアランクを各桁に保存
    public int[] scoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        //SaveStageData data = new SaveStageData();
        //SaveManager.LordStage("AddAllScoreTest.text", ref data);
        //scoreAllAdd = data.m_score;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            scoreLev = 1;
            Debug.Log(scoreLev);

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            scoreLev = 2;
            Debug.Log(scoreLev);

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            scoreLev = 3;
            Debug.Log(scoreLev);

        }

        //仮クリア時
        if (Input.GetKey(KeyCode.Return))
        {
            //ステージ開放
            if (!flag)                      //開放していないなら
            {
                ReleaseStage.stageNum += 1;
                flag = true;
            }

            SaveStageData data = new SaveStageData();
            data.m_score = ReleaseStage.stageNum;
            SaveManager.SaveStage("SaveReleaseStage.text", ref data);

            //data.m_score = scoreAllAdd;
            //SaveManager.SaveStage("AddAllScoreTest.text", ref data);


            SceneManager.LoadScene("StageSelect");
        }
    }
}
