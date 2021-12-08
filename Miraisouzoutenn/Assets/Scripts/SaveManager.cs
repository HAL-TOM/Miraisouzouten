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
            // �o�C�i���`���Ńf�V���A���C�Y
            BinaryFormatter bf = new BinaryFormatter();
            // �w�肵���p�X�̃t�@�C���X�g���[�����J��
            FileStream file = File.Open(SaveFilePath, FileMode.Open);
            try
            {
                // �w�肵���t�@�C���X�g���[�����I�u�W�F�N�g�Ƀf�V���A���C�Y�B
                data = (SaveStageData)bf.Deserialize(file);
            }
            finally
            {
                // �t�@�C������ɂ͖����I�Ȕj�����K�v�ł��BClose��Y��Ȃ��悤�ɁB
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
