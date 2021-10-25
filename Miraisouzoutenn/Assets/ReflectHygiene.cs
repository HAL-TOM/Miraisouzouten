using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectHygiene : MonoBehaviour
{
    
  
    [SerializeField]  private List<InLight> inLights;
    

    // Start is called before the first frame update
    void Start()
    {
        inLights = new List<InLight>();
    }

    // Update is called once per frame
    void Update()
    {

         UpdateLight();
    }
    private void UpdateLight()
    {
        foreach (InLight light in inLights)
        {
            if(Vector3.Dot(transform.up,light.inLight.m_Direction) < 0)
            {
                DestoroyLight(light);
                continue;
            }
            light.outLight.SetDirection(RefVec(light.inLight.m_Direction));
        }
    }
    public void HitLight(SunLight inL)//���������������ɌĂ΂��
    {
        if(Vector3.Dot(transform.up, inL.m_Direction)>0)
        {
            Debug.Log("HitLight");
            inLights.Add(new InLight(inL, ReflectLight(inL)));
        }
    }
    public void OutLight(SunLight outL)//�������ꂽ���ɌĂ΂��
    {
        foreach (InLight light in inLights)
        {
            if (light.inLight == outL)
            {
                DestoroyLight(light);
                return;
            }
        }
    }

    private void DestoroyLight(InLight light)
    {
        //light.outL;//�����鏈��
        inLights.Remove(light); // �v�f�̍폜
    }

    private SunLight ReflectLight(SunLight inL)
    {
        SunLight retL = new SunLight();
        //����
        retL.SetAll(gameObject, RefVec(inL.m_Direction), 1.0f, 1.0f);
        
        return retL;
    }

    private Vector3 RefVec(Vector3 inV)
    {
        Vector3 normal_n=Vector3.zero;
        normal_n = Vector3.Normalize(transform.up);//�@���x�N�g���iGameObject�̏�x�N�g���j
        return Vector3.Normalize(inV - 2.0f * Vector3.Dot(inV, normal_n) * normal_n);
       
    }


}
