using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseStage : MonoBehaviour
{
    public static int stageNum = 1;           //解放するステージ数の変数
    public GameObject[] StageBox;             //ステージ選択ボタン格納用

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
        for (int i = 0; i < StageBox.Length; i++)       // ボタンの数だけ確認
        {
            if(stageNum >= i + 2)                       //解放されているステージ数表示
            {
                StageBox[i].SetActive(true);            //解放ステージ表示
            }
        }

        //仮リセット
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

    //現在の状態を渡す
    public int GetReleseStageNum()
    {
        return stageNum;
    }
}
