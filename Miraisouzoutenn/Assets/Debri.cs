using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debri : MonoBehaviour
{
    enum DEBRI_TYPE
    {
        SMALL = 1,
        BIG = 2,
    };

    [SerializeField] DEBRI_TYPE m_debri_type;

    //デブリで電力を生成
    List<Energy> m_energies;
    float m_decrease_value;//減算用の変数
    float m_energy_value;//当たってるエネルギーの値


    // Start is called before the first frame update
    void Start()
    {
        m_decrease_value = (int)m_debri_type;
        m_energy_value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //画像更新とか？
        if(m_debri_type == DEBRI_TYPE.BIG)
        {

        }
        else if(m_debri_type == DEBRI_TYPE.SMALL)
        {

        }
    }

    //破壊処理
    public void Break()
    {
        if(m_debri_type == DEBRI_TYPE.BIG)
        {
            m_debri_type = DEBRI_TYPE.SMALL;
            m_decrease_value = (int)m_debri_type;
        }
        if(m_debri_type == DEBRI_TYPE.SMALL)
        {
            Destroy(this.gameObject);
        }
    }

    //問答無用で壊す
    public void PerfectBreak()
    {
        Destroy(this.gameObject);
    }

    public float GetDecreaseValue()
    {
        return m_decrease_value;
    }

    public float GetEnergyValue()
    {
        return m_energy_value;
    }

    public void SetEnergyValue(float energy)
    {
        m_energy_value = energy;
    }
}
