using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{
    const float DEFAULT_SCALE = 0.25f;

    public GameObject m_StartObj;
    GameObject m_EndObj;
    public Vector3 m_Direction;
    public float m_OriginLength;
    float m_Length;
    public float m_Value;
    bool m_HitFlag;


    void Start()
    {
        transform.localScale = new Vector3(DEFAULT_SCALE, DEFAULT_SCALE, DEFAULT_SCALE);
        m_HitFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Magnitude(m_Direction) > 1.0f)
            m_Direction = Vector3.Normalize(m_Direction);

        HitManagement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ライトの長さ" + m_Length);
            Debug.Log("ライトの開始" + m_StartObj.gameObject.name);
            //Debug.Log("ライトの終了" + m_EndObj.gameObject.name);
        }

            DispManagement();
    }

    //ライトのヒットに関するあれこれ
    void HitManagement()
    {
        Vector3 distance;
        float distLen = m_OriginLength;


        //ライトの方向にオブジェクトがあるかの判定
        Vector3 startPos;
        startPos = m_StartObj.transform.position + (m_StartObj.transform.localScale.x + m_StartObj.transform.localScale.y) / 4 * m_Direction;
        float length;
        length = m_OriginLength - (m_StartObj.transform.localScale.x + m_StartObj.transform.localScale.y) / 4;

        foreach (RaycastHit hit in Physics.RaycastAll(startPos, m_Direction, length))
        {
            m_HitFlag = true;
            //ヒットしたオブジェクトとレイを出したオブジェクトとの距離を算出
            distance = m_StartObj.transform.position - hit.transform.position;

            //距離が最も近いオブジェクトを調べる
            if (distLen > Vector3.Magnitude(distance))
            {
                distLen = Vector3.Magnitude(distance);
                m_EndObj = hit.collider.gameObject;
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log(hit.collider.gameObject.transform.position);
            }
        }

        //ライトの現在の長さを設定　
        if (m_HitFlag)
        {
            m_Length = distLen;
            /*
            //ヒットしているオブジェクトが衛星なら通知
            if(m_EndObj.GetType()== typeof(ReflectHygiene))
            {
                m_EndObj.当たってるよ関数();
            }
            if (m_EndObj.GetType() == typeof(Amamegumi))
            {
                m_EndObj.当たってるよ関数();
            }
            */
        }
        else
        {
            m_Length = m_OriginLength;
        }


    }

    //ライトの見た目の変更
    void DispManagement()
    {
        
        //長さを合わせる
        transform.localScale = new Vector3(DEFAULT_SCALE, m_Length, DEFAULT_SCALE);


        //角度を合わせる
        //z軸回転
        Vector3 downVec = new Vector3(0.0f, -1.0f, 0.0f);
        float angle = Vector3.SignedAngle(downVec, m_Direction, new Vector3(0.0f, 0.0f, 1.0f));
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

        //位置を合わせる
        Vector3 position;
        position = m_StartObj.transform.position + m_Direction * m_Length / 2;
        transform.position = position;

    }

    //セッター関数
    public void SetStartObj(GameObject startObj)
    {
        m_StartObj = startObj;
    }

    public void SetDirection(Vector3 direction)
    {
        m_Direction = direction;
    }

    public void SetOriginLength(float originLength)
    {
        m_OriginLength = originLength;
    }

    public void SetValue(float value)
    {
        m_Value = value;
    }

    public void SetAll(GameObject startObj, Vector3 direction, float originLength, float value)
    {
        SetStartObj(startObj);
        SetDirection(direction);
        SetOriginLength(originLength);
        SetValue(value);
    }


    //ゲッター関数
    public GameObject GetStartObj()
    {
        return m_StartObj;
    }

    public GameObject GetEndObj()
    {
        return m_EndObj;
    }

    public Vector3 GetDirection()
    {
        return m_Direction;
    }

    public float GetOriginLength()
    {
        return m_OriginLength;
    }
    public float GetValue()
    {
        return m_Value;
    }


}
