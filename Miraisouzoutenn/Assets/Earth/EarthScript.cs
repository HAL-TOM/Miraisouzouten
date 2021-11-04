using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EarthScript : MonoBehaviour
{
    //電力
    public int Electricity = 0;
    //必要電力数
    public int NeedElectricity;
    //クリア判定
    public bool Cleare;

    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //Electricity = 電力
        
        if (NeedElectricity <= Electricity)
        {
            Cleare = true;
        }
        else
        {
            Cleare = false;
        }

        if(Cleare == true)
        {
            SceneManager.LoadScene("Cleare");
        }
    }
}
