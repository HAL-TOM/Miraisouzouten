using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{
    public GameObject[] Fragment1Ani;           //アンロックアニメーション非表示
    public GameObject[] Fragment2Ani;
    public GameObject[] Fragment3Ani;
    public GameObject[] Fragment1Spr;           //画像表示
    public GameObject[] Fragment2Spr;
    public GameObject[] Fragment3Spr;

    int[] scoreLev = new int[20];

    bool[,] AniMove = new bool[20,3];
    bool AniMoved;


    // Start is called before the first frame update
    void Start()
    {
        SaveStageData data = new SaveStageData();
        //すべてのステージデータ読み込み
        for (int i = 0; i < 20; i++)
        {
            SaveManager.LordStage($"Score{i}Test.text", ref data);
            scoreLev[i] = data.m_score;
            AniMove[i, 0] = GetBool($"key{i}0", true);
            AniMove[i, 1] = GetBool($"key{i}1", true);
            AniMove[i, 2] = GetBool($"key{i}2", true);
            Debug.Log(AniMove[i, 0]);

            if (ReleaseStage.stageNum >= i + 2)         //開放されているか
            {
                if (scoreLev[i] >= 1)
                {
                    Fragment1Ani[i].SetActive(true);
                    Fragment1Spr[i].SetActive(true);
                    AniMoved = true;
                    SettBool($"key{i}0", AniMoved);
                    SettBool($"key{i}1", false);
                    SettBool($"key{i}2", false);
                }
                if (scoreLev[i] >= 2)
                {
                    Fragment2Ani[i].SetActive(true);
                    Fragment2Spr[i].SetActive(true);
                    AniMoved = true;
                    SettBool($"key{i}1", AniMoved);
                    SettBool($"key{i}2", false);
                }
                if (scoreLev[i] >= 3)
                {
                    Fragment3Ani[i].SetActive(true);
                    Fragment3Spr[i].SetActive(true);
                    AniMoved = true;
                    SettBool($"key{i}2", AniMoved);
                }
            }

            if (ReleaseStage.stageNum >= i + 3)
            {
                if (AniMove[i, 0])
                {
                    Fragment1Ani[i].SetActive(false);
                }
                if (AniMove[i, 1])
                {
                    Fragment2Ani[i].SetActive(false);
                }
                if (AniMove[i, 2])
                {
                    Fragment3Ani[i].SetActive(false);
                }
            }
            else if (ReleaseStage.stageNum == 21)
            {
                if (AniMove[i, 0])
                {
                    Fragment1Ani[i].SetActive(false);
                }
                if (AniMove[i, 1])
                {
                    Fragment2Ani[i].SetActive(false);
                }
                if (AniMove[i, 2])
                {
                    Fragment3Ani[i].SetActive(false);
                }
            }

        }
    }
 
    // Update is called once per frame
    void Update()
    {

    }

    public static bool GetBool(string key, bool defalutValue)
    {
        var value = PlayerPrefs.GetInt(key, defalutValue ? 1 : 0);
        return value == 1;
    }

    public static void SettBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }
}
