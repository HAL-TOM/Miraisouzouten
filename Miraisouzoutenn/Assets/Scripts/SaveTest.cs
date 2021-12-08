using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveTest : MonoBehaviour
{
    public Text textIn;
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
        data.m_score = int.Parse( textIn.text);
        SaveManager.SaveStage("SaveTest.text",ref data);
    }
}
