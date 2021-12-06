using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    const float SCALE_ZIZE =3f;

    //注意！！
    //現在アマメグミのRotationをいじるとベクトルとの整合性が崩れる

    [SerializeField] float m_length_limit = 5.0f;//長さの設定

    GameObject m_startobject;
    GameObject m_endobject;
    GameObject hitobject;

    Vector3 m_direction;//方向ベクトル
    [SerializeField] float m_value;//現在のエネルギー
    float m_orijinlength;//もとのエネルギー(電力)の長さ
    float m_length;//現在のエネルギー(電力)長さ

    bool m_hit;

    // Start is called before the first frame update
    void Start()
    {
        m_orijinlength = m_length = m_length_limit;
        m_direction = new Vector3(0.0f, 1.0f, 0.0f);

        m_startobject = this.gameObject.transform.root.gameObject;//親オブジェクト取得

        Vector3 position;
        position = m_startobject.transform.position + m_direction * m_length / 2;
        transform.position = position;
        this.gameObject.transform.localScale = new Vector3(SCALE_ZIZE, m_length, SCALE_ZIZE);

        m_endobject = null;
        m_value = 0.0f;

        m_hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //方向ベクトルを回転
        m_direction = Quaternion.Euler(0, 0, m_startobject.transform.localRotation.z) * this.gameObject.transform.up;

        //レイによる当たり判定
        Ray ray = new Ray(m_startobject.transform.position, m_direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, m_length_limit))
        {
            //レイが当たったオブジェクトを取得
            m_endobject = hit.collider.gameObject;

            Debug.Log(m_endobject.name);

            //アマメグミのコンポーネントを持っている
            // ＋ 自身の親オブジェクトとは違う
            if (hit.collider.gameObject.GetComponent<Amamegumi>() && m_startobject != m_endobject)
            {
                //レイが当たったオブジェクトとの距離を計算
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                //位置、長さ調整
                DispManagement(distance);

                hit.collider.gameObject.GetComponent<Amamegumi>().HitEnergy(this);
            }

            if (hit.collider.gameObject.GetComponent<EarthScript>() && m_startobject != m_endobject)
            {
                m_hit = true;
                //レイが当たったオブジェクトとの距離を計算
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                //位置、長さ調整
                DispManagement(distance);
            }

            if (hit.collider.gameObject.GetComponent<Goal>() && m_startobject != m_endobject)
            {
                //レイが当たったオブジェクトとの距離を計算
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                //位置、長さ調整
                DispManagement(distance);

                hit.collider.gameObject.GetComponent<Goal>().HitEnergy(this);
            }

            //デブリに当たったら
            if (hit.collider.gameObject.GetComponent<Debri>() && m_startobject != m_endobject)
            {
                /*
                デブリに当たったらレイを再出発
                ＋飛ばすレイの長さの更新
                */

                //デブリに当たったからその分減算
                m_value -= hit.collider.gameObject.GetComponent<Debri>().GetDecreaseValue();
                hit.collider.gameObject.GetComponent<Debri>().SetEnergyValue(m_value);

                //レイが当たったオブジェクトとの距離を計算
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                ray = new Ray(m_endobject.transform.position, m_direction);


                if (Physics.Raycast(ray, out hit, m_length_limit - distance))
                {
                    //レイが当たったオブジェクトを取得
                    hitobject = hit.collider.gameObject;
                    Debug.Log(m_endobject.name);

                    //アマメグミのコンポーネントを持っている
                    // ＋ 自身の親オブジェクトとは違う
                    if (hit.collider.gameObject.GetComponent<Amamegumi>() && m_startobject != hitobject)
                    {
                        //レイが当たったオブジェクトとの距離を計算
                        distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                        //位置、長さ調整
                        DispManagement(distance);
                        hit.collider.gameObject.GetComponent<Amamegumi>().HitEnergy(this);
                    }

                    if (hit.collider.gameObject.GetComponent<EarthScript>() && m_startobject != hitobject)
                    {
                        m_hit = true;
                        //レイが当たったオブジェクトとの距離を計算
                        distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                        //位置、長さ調整
                        DispManagement(distance);
                    }

                    if (hit.collider.gameObject.GetComponent<Goal>() && m_startobject != hitobject)
                    {
                        //レイが当たったオブジェクトとの距離を計算
                        distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                        //位置、長さ調整
                        DispManagement(distance);

                        hit.collider.gameObject.GetComponent<Goal>().HitEnergy(this);
                    }
                }
                else
                {
                    if (hitobject == null)
                        return;

                    if (hitobject.gameObject.GetComponent<Amamegumi>())
                    {
                        hitobject.gameObject.GetComponent<Amamegumi>().OutEnergy(this);
                    }

                    if (hitobject.gameObject.GetComponent<Goal>())
                    {
                        hitobject.gameObject.GetComponent<Goal>().OutEnergy(this);
                    }

                    hitobject = null;

                    DispManagement(m_orijinlength);
                }
            }
        }
        else
        {
            if (m_endobject == null)
                return;

            if (m_endobject.gameObject.GetComponent<Amamegumi>())
            {
                m_endobject.gameObject.GetComponent<Amamegumi>().OutEnergy(this);
            }

            if (m_endobject.gameObject.GetComponent<Goal>())
            {
                m_endobject.gameObject.GetComponent<Goal>().OutEnergy(this);
            }

            m_endobject = null;

            DispManagement(m_orijinlength);
        }

        Debug.Log(m_value);
    }

    //長さ調整
    void DispManagement(float length)
    {
        m_length = length;
        Vector3 position;
        position = m_startobject.transform.position + m_direction * m_length / 2;
        transform.position = position;
        this.gameObject.transform.localScale = new Vector3(SCALE_ZIZE, m_length, SCALE_ZIZE);
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

    public bool GetHit()
    {
        return m_hit;
    }

}
