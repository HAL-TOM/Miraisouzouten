using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EarthScript : MonoBehaviour
{
    //�d��
    public int Electricity = 0;
    //�K�v�d�͐�
    public int NeedElectricity;
    //�N���A����
    public bool Cleare;

    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //Electricity = �d��
        
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
