using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectHygiene : MonoBehaviour
{


    [SerializeField] private List<InLight> m_inLights;

    [SerializeField] private GameObject m_LightRes;

    // Start is called before the first frame update
    void Start()
    {
        m_inLights = new List<InLight>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateLight();
    }
    private void UpdateLight()
    {
        foreach (InLight light in m_inLights)
        {
            if (Vector3.Dot(transform.up, light.inLight.m_Direction) > 0)//表面
            {
                DestoroyLight(light);
                continue;
            }
            light.outLight.SetDirection(RefVec(light.inLight.m_Direction));
        }
    }
    public void HitLight(SunLight inL)//光が当たった時に呼ばれる
    {
        foreach (InLight light in m_inLights)
        {
            if (light.inLight == inL)
            {
                //既にHitしている
                return;
            }
        }

        if (Vector3.Dot(-transform.up, inL.m_Direction) > 0)
        {
            Debug.Log("HitLight");
            m_inLights.Add(new InLight(inL, ReflectLight(inL)));
        }
    }
    public void OutLight(SunLight outL)//光が離れた時に呼ばれる
    {
        foreach (InLight light in m_inLights)
        {
            if (light.inLight == outL)
            {
                DestoroyLight(light);
                return;
            }
        }
    }

    public void DestoroyLight(InLight light)
    {
        //light.outL;//消える処理
        light.outLight.DestoroyLight();
        m_inLights.Remove(light); // 要素の削除

    }
    public void DestoroyLight()
    {

        foreach (InLight inl in m_inLights  )
        {
            inl.outLight.DestoroyLight();

        }

        m_inLights.Clear(); // 要素の削除

    }
    private SunLight ReflectLight(SunLight inL)
    {
        GameObject instance = Instantiate(m_LightRes,
                                                  transform.position,
                                                  Quaternion.identity)as GameObject;
        SunLight retL = instance.GetComponent<SunLight>();
        //生成
        retL.SetAll(gameObject, RefVec(inL.m_Direction), inL.m_OriginLength, inL.m_Value - 1);
        
        return retL;
    }

    private Vector3 RefVec(Vector3 inV)
    {
        Vector3 normal_n=Vector3.zero;
        normal_n = Vector3.Normalize(transform.up);//法線ベクトル（GameObjectの上ベクトル）
        return Vector3.Normalize(inV - 2.0f * Vector3.Dot(inV, normal_n) * normal_n);
       
    }

    public GameObject GetLight()
    {
        return m_LightRes;
    }


}
