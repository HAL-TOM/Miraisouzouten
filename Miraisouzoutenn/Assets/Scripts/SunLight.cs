using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{
    const float DEFAULT_SCALE = 0.25f;

    public GameObject m_StartObj;
    public GameObject m_EndObj;
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
        m_HitFlag = false;

        //ライトの方向にオブジェクトがあるかの判定
        Vector3 startPos;
        startPos = m_StartObj.transform.position + (m_StartObj.transform.localScale.x + m_StartObj.transform.localScale.y) / 4 * m_Direction;
        float length;
        length = m_Length - (m_StartObj.transform.localScale.x + m_StartObj.transform.localScale.y) / 4;
       foreach (RaycastHit hit in Physics.RaycastAll(startPos, m_Direction, length))
        {
            m_HitFlag = true;
            //ヒットしたオブジェクトとレイを出したオブジェクトとの距離を算出
            distance = m_StartObj.transform.position - hit.transform.position;

            //距離が最も近いオブジェクトを調べる
            if (distLen > Vector3.Magnitude(distance))
            {
                if(!(m_EndObj==null))//現在当たっているオブジェクトがある
                {
                    if (!(m_EndObj == hit.collider.gameObject))//当たっているオブジェクトと当たったオブジェクトは違う
                    {
                        //m_EndObj.離れたよ関数();

                        if (m_EndObj.GetComponent<ReflectHygiene>() != null)
                        {
                            m_EndObj.GetComponent<ReflectHygiene>().OutLight(this);
                        }

                        if (m_EndObj.GetComponent<Amamegumi>() != null)
                        {
                            m_EndObj.GetComponent<Amamegumi>().OutLight(this);
                        }
                        Debug.Log("foreach通知");
                    }
                }

                distLen = Vector3.Magnitude(distance);
            }

            m_EndObj = hit.collider.gameObject;
            Debug.Log("HitObj:" + hit.collider.gameObject.name);
        }
        
        

        //ライトの現在の長さを設定　
        if (m_HitFlag)
        {
            m_Length = distLen;
            //ヒットしているオブジェクトが衛星なら通知
            if(m_EndObj.GetComponent< ReflectHygiene >()!= null)
            {

                m_EndObj.GetComponent<ReflectHygiene>().HitLight(this);
            }
            if (m_EndObj.GetComponent<Amamegumi>() != null)
            {

                m_EndObj.GetComponent<Amamegumi>().HitLight(this);
            }

            /*
            if (m_EndObj.GetType() == typeof(Amamegumi))
            {
                m_EndObj.当たってるよ関数();
            }
            */
        }
        else
        {
            m_Length = m_OriginLength;
            //EndObjが設定されているが、光が当たっていない時
            if(!(m_EndObj == null))
            {
                //m_EndObj.離れたよ関数();
                if (m_EndObj.GetComponent<ReflectHygiene>() != null)
                {
                    m_EndObj.GetComponent<ReflectHygiene>().OutLight(this);
                }

                if (m_EndObj.GetComponent<Amamegumi>() != null)
                {
                    m_EndObj.GetComponent<Amamegumi>().OutLight(this);
                }

                m_EndObj = null;
                Debug.Log("false通知");
            }
        }


    }
    public void DestoroyLight()
    {
        if (!(m_EndObj == null))
        {
            //m_EndObj.離れたよ関数();
            if (m_EndObj.GetComponent<ReflectHygiene>() != null)
            {
                m_EndObj.GetComponent<ReflectHygiene>().OutLight(this);
            }
        }
        Destroy(gameObject);
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
