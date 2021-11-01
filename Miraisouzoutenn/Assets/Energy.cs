using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    //���ӁI�I
    //���݃A�}���O�~��Rotation��������ƃx�N�g���Ƃ̐������������

    [SerializeField] float m_length_limit = 5.0f;//�����̐ݒ�

    GameObject m_startobject;
    GameObject m_maeendobject;
    GameObject m_endobject;

    Vector3 m_direction;//�����x�N�g��
    float m_value;//���݂̃G�l���M�[
    float m_orijinlength;//���Ƃ̃G�l���M�[(�d��)�̒���
    float m_length;//���݂̃G�l���M�[(�d��)����

    // Start is called before the first frame update
    void Start()
    {
        m_orijinlength = m_length = m_length_limit;
        m_direction = new Vector3(0.0f, 1.0f, 0.0f);

        m_startobject = this.gameObject.transform.root.gameObject;//�e�I�u�W�F�N�g�擾
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
        //�����x�N�g������]
        m_direction = Quaternion.Euler(0, 0, m_startobject.transform.localRotation.z) * this.gameObject.transform.up;
        //Debug.Log(m_direction);

        //���C�ɂ�铖���蔻��
        Ray ray = new Ray(m_startobject.transform.position, m_direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, m_length_limit))
        {
            //���C�����������I�u�W�F�N�g���擾
            m_endobject = hit.collider.gameObject;

            //if (m_maeendobject == m_endobject)
            //    return;

            //�A�}���O�~�̃R���|�[�l���g�������Ă���
            // �{ ���g�̐e�I�u�W�F�N�g�Ƃ͈Ⴄ
            if (hit.collider.gameObject.GetComponent<Amamegumi>() && m_startobject != m_endobject)
            {
                Debug.Log(hit.collider.gameObject.name);
                //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);
                Debug.Log(distance);

                //�ʒu�A��������
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
                //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);
                Debug.Log(distance);

                //�ʒu�A��������
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
