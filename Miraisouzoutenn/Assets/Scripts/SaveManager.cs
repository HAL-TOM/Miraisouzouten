using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
public class SaveManager
{

    
    static public bool SaveStage(in string SaveFilePath , ref SaveStageData data)
    {
        SaveStageData stageData = new SaveStageData();
        stageData.m_score = data.m_score;
        using (FileStream fs = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, stageData);
        }

        Debug.Log("[Save]m_score:" + stageData.m_score);

        return true;
    }
    static public bool CreateFile(in string SaveFilePath)
    {

        FileStream file = File.Create(SaveFilePath);

        return File.Exists(SaveFilePath);
    }
    static public bool LordStage(in string SaveFilePath,ref SaveStageData data)
    {


        if (File.Exists(SaveFilePath))
        {
            // バイナリ形式でデシリアライズ
            BinaryFormatter bf = new BinaryFormatter();
            // 指定したパスのファイルストリームを開く
            FileStream file = File.Open(SaveFilePath, FileMode.Open);
            try
            {
                // 指定したファイルストリームをオブジェクトにデシリアライズ。
                data = (SaveStageData)bf.Deserialize(file);
            }
            finally
            {
                // ファイル操作には明示的な破棄が必要です。Closeを忘れないように。
                if (file != null)
                    file.Close();
            }
            return true;
        }
        else
        {
            Debug.Log("no load file:"+ SaveFilePath);
            return false;

        }
    }

}
