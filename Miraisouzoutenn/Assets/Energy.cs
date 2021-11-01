using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    //注意！！
    //現在アマメグミのRotationをいじるとベクトルとの整合性が崩れる

    [SerializeField] float m_length_limit = 5.0f;//長さの設定

    GameObject m_startobject;
    GameObject m_maeendobject;
    GameObject m_endobject;

    Vector3 m_direction;//方向ベクトル
    float m_value;//現在のエネルギー
    float m_orijinlength;//もとのエネルギー(電力)の長さ
    float m_length;//現在のエネルギー(電力)長さ

    // Start is called before the first frame update
    void Start()
    {
        m_orijinlength = m_length = m_length_limit;
        m_direction = new Vector3(0.0f, 1.0f, 0.0f);

        m_startobject = this.gameObject.transform.root.gameObject;//親オブジェクト取得
        //this.gameObject.transform.position = new Vector3(0.0f, m_startobject.transform.position.y + m_length_limit / 2, 0.0f);
        //this.gameObject.transform.localScale = new Vector3(0.2f, m_length_limit, 0.2f);
        Vector3 position;
        position = m_startobject.transform.position + m_direction * m_length / 2;
        transform.position = position;
        this.gameObject.transform.localScale = new Vector3(0.2f, m_length, 0.2f);

        m_endobject = null;
        m_value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //方向ベクトルを回転
        m_direction = Quaternion.Euler(0, 0, m_startobject.transform.localRotation.z) * this.gameObject.transform.up;
        //Debug.Log(m_direction);

        //レイによる当たり判定
        Ray ray = new Ray(m_startobject.transform.position, m_direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, m_length_limit))
        {
            //レイが当たったオブジェクトを取得
            m_endobject = hit.collider.gameObject;

            //if (m_maeendobject == m_endobject)
            //    return;

            //アマメグミのコンポーネントを持っている
            // ＋ 自身の親オブジェクトとは違う
            if (hit.collider.gameObject.GetComponent<Amamegumi>() && m_startobject != m_endobject)
            {
                Debug.Log(hit.collider.gameObject.name);
                //レイが当たったオブジェクトとの距離を計算
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);
                Debug.Log(distance);

                //位置、長さ調整
                m_length = distance;
                Vector3 position;
                position = m_startobject.transform.position + m_direction * m_length / 2;
                transform.position = position;
                this.gameObject.transform.localScale = new Vector3(0.2f, m_length, 0.2f);
                hit.collider.gameObject.GetComponent<Amamegumi>().HitEnergy(this);

                //m_maeendobject = m_endobject;
            }

            if (hit.collider.gameObject.GetComponent<Goal>() && m_startobject != m_endobject)
            {
                Debug.Log(hit.collider.gameObject.name);
                //レイが当たったオブジェクトとの距離を計算
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);
                Debug.Log(distance);

                //位置、長さ調整
                m_length = distance;
                Vector3 position;
                position = m_startobject.transform.position + m_direction * m_length / 2;
                transform.position = position;
                this.gameObject.transform.localScale = new Vector3(0.2f, m_length, 0.2f);
                hit.collider.gameObject.GetComponent<Goal>().HitEnergy(this);

                //m_maeendobject = m_endobject;
            }
        }
        else
        {
            if (m_endobject == null)
                return;

            if (m_endobject.gameObject.GetComponent<Amamegumi>() != null)
            {
                m_endobject.gameObject.GetComponent<Amamegumi>().OutEnergy(this);
            }

            if (m_endobject.gameObject.GetComponent<Goal>() != null)
            {
                m_endobject.gameObject.GetComponent<Goal>().OutEnergy(this);
            }

            //if (m_endobject.GetComponent<Amamegumi>())
            //    m_endobject.gameObject.GetComponent<Amamegumi>().OutEnergy(this);

            //if (m_endobject.GetComponent<Goal>())
            //    m_endobject.gameObject.GetComponent<Goal>().OutEnergy(this);

            m_endobject = null;
        }


    }

    public void DestroyEnergy()
    {
        Destroy(this.gameObject);
    }

    public void SetValue(float value)
    {
        m_value = value;
    }

    public float GetValue()
    {
        return m_value;
    }

    public Vector3 GetDirection()
    {
        return m_direction;
    }
}
