using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadTest : MonoBehaviour
{
    public Text textOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonDown()
    {
        SaveStageData data = new SaveStageData();
        SaveManager.LordStage("SaveTest.text", ref data);
        textOut.text = data.m_score.ToString();
    }

}
