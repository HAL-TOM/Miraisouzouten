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
            Debug.Log("���C�g�̒���" + m_Length);
            Debug.Log("���C�g�̊J�n" + m_StartObj.gameObject.name);
            //Debug.Log("���C�g�̏I��" + m_EndObj.gameObject.name);
        }

            DispManagement();
    }

    //���C�g�̃q�b�g�Ɋւ��邠�ꂱ��
    void HitManagement()
    {
        Vector3 distance;
        float distLen = m_OriginLength;


        //���C�g�̕����ɃI�u�W�F�N�g�����邩�̔���
        Vector3 startPos;
        startPos = m_StartObj.transform.position + (m_StartObj.transform.localScale.x + m_StartObj.transform.localScale.y) / 4 * m_Direction;
        float length;
        length = m_OriginLength - (m_StartObj.transform.localScale.x + m_StartObj.transform.localScale.y) / 4;

        foreach (RaycastHit hit in Physics.RaycastAll(startPos, m_Direction, length))
        {
            m_HitFlag = true;
            //�q�b�g�����I�u�W�F�N�g�ƃ��C���o�����I�u�W�F�N�g�Ƃ̋������Z�o
            distance = m_StartObj.transform.position - hit.transform.position;

            //�������ł��߂��I�u�W�F�N�g�𒲂ׂ�
            if (distLen > Vector3.Magnitude(distance))
            {
                distLen = Vector3.Magnitude(distance);
                m_EndObj = hit.collider.gameObject;
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log(hit.collider.gameObject.transform.position);
            }
        }

        //���C�g�̌��݂̒�����ݒ�@
        if (m_HitFlag)
        {
            m_Length = distLen;
            /*
            //�q�b�g���Ă���I�u�W�F�N�g���q���Ȃ�ʒm
            if(m_EndObj.GetType()== typeof(ReflectHygiene))
            {
                m_EndObj.�������Ă��֐�();
            }
            if (m_EndObj.GetType() == typeof(Amamegumi))
            {
                m_EndObj.�������Ă��֐�();
            }
            */
        }
        else
        {
            m_Length = m_OriginLength;
        }


    }

    //���C�g�̌����ڂ̕ύX
    void DispManagement()
    {
        
        //���������킹��
        transform.localScale = new Vector3(DEFAULT_SCALE, m_Length, DEFAULT_SCALE);


        //�p�x�����킹��
        //z����]
        Vector3 downVec = new Vector3(0.0f, -1.0f, 0.0f);
        float angle = Vector3.SignedAngle(downVec, m_Direction, new Vector3(0.0f, 0.0f, 1.0f));
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

        //�ʒu�����킹��
        Vector3 position;
        position = m_StartObj.transform.position + m_Direction * m_Length / 2;
        transform.position = position;

    }

    //�Z�b�^�[�֐�
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


    //�Q�b�^�[�֐�
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
