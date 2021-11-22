using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CleareButton : MonoBehaviour
{
    //次のステージの名前を格納
    public string NextStage;

    //タイトル遷移
    public void Title() {
        
		SceneManager.LoadScene ("Title");

    }
    //Next Stage
    public void NextGame()
    {
        //次のステージの名前を入力
        SceneManager.LoadScene(NextStage);
        
    }
    //Stage Select
    public void StageSelect()
    {
        Debug.Log("ステージ選択画面遷移");
        //SceneManager.LoadScene("StageSelect");/////ステージ選択画面プロジェクト名
    }


}
