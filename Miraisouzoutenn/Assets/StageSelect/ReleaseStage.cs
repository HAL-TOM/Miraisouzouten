using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseStage : MonoBehaviour
{
    public int stage_num = 1;           //解放するステージ数の変数
    public GameObject[] StageBox;   //ステージ選択ボタン格納用

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < StageBox.Length; i++)       // ボタンの数だけ確認
        {
            if(stage_num >= i + 2)                      //解放されているステージ数表示
            {
                StageBox[i].SetActive(true);            //解放ステージ表示
            }
        }
    }

    //クリア時などに解放ステージを増やす
    public void AddReleseStageNum()
    {
        stage_num += 1;
    }

    //現在の状態を渡す
    public int GetReleseStageNum()
    {
        return stage_num;
    }
}
