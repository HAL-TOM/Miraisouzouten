using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    const float SCALE_ZIZE =3f;

    //���ӁI�I
    //���݃A�}���O�~��Rotation��������ƃx�N�g���Ƃ̐������������

    [SerializeField] float m_length_limit = 5.0f;//�����̐ݒ�

    GameObject m_startobject;
    GameObject m_endobject;
    GameObject hitobject;

    Vector3 m_direction;//�����x�N�g��
    [SerializeField] float m_value;//���݂̃G�l���M�[
    float m_orijinlength;//���Ƃ̃G�l���M�[(�d��)�̒���
    float m_length;//���݂̃G�l���M�[(�d��)����

    bool m_hit;

    // Start is called before the first frame update
    void Start()
    {
        m_orijinlength = m_length = m_length_limit;
        m_direction = new Vector3(0.0f, 1.0f, 0.0f);

        m_startobject = this.gameObject.transform.root.gameObject;//�e�I�u�W�F�N�g�擾

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
        //�����x�N�g������]
        m_direction = Quaternion.Euler(0, 0, m_startobject.transform.localRotation.z) * this.gameObject.transform.up;

        //���C�ɂ�铖���蔻��
        Ray ray = new Ray(m_startobject.transform.position, m_direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, m_length_limit))
        {
            //���C�����������I�u�W�F�N�g���擾
            m_endobject = hit.collider.gameObject;

            Debug.Log(m_endobject.name);

            //�A�}���O�~�̃R���|�[�l���g�������Ă���
            // �{ ���g�̐e�I�u�W�F�N�g�Ƃ͈Ⴄ
            if (hit.collider.gameObject.GetComponent<Amamegumi>() && m_startobject != m_endobject)
            {
                //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                //�ʒu�A��������
                DispManagement(distance);

                hit.collider.gameObject.GetComponent<Amamegumi>().HitEnergy(this);
            }

            if (hit.collider.gameObject.GetComponent<EarthScript>() && m_startobject != m_endobject)
            {
                m_hit = true;
                //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                //�ʒu�A��������
                DispManagement(distance);
            }

            if (hit.collider.gameObject.GetComponent<Goal>() && m_startobject != m_endobject)
            {
                //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                //�ʒu�A��������
                DispManagement(distance);

                hit.collider.gameObject.GetComponent<Goal>().HitEnergy(this);
            }

            //�f�u���ɓ���������
            if (hit.collider.gameObject.GetComponent<Debri>() && m_startobject != m_endobject)
            {
                /*
                �f�u���ɓ��������烌�C���ďo��
                �{��΂����C�̒����̍X�V
                */

                //�f�u���ɓ����������炻�̕����Z
                m_value -= hit.collider.gameObject.GetComponent<Debri>().GetDecreaseValue();
                hit.collider.gameObject.GetComponent<Debri>().SetEnergyValue(m_value);

                //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                float distance;
                distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                ray = new Ray(m_endobject.transform.position, m_direction);


                if (Physics.Raycast(ray, out hit, m_length_limit - distance))
                {
                    //���C�����������I�u�W�F�N�g���擾
                    hitobject = hit.collider.gameObject;
                    Debug.Log(m_endobject.name);

                    //�A�}���O�~�̃R���|�[�l���g�������Ă���
                    // �{ ���g�̐e�I�u�W�F�N�g�Ƃ͈Ⴄ
                    if (hit.collider.gameObject.GetComponent<Amamegumi>() && m_startobject != hitobject)
                    {
                        //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                        distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                        //�ʒu�A��������
                        DispManagement(distance);
                        hit.collider.gameObject.GetComponent<Amamegumi>().HitEnergy(this);
                    }

                    if (hit.collider.gameObject.GetComponent<EarthScript>() && m_startobject != hitobject)
                    {
                        m_hit = true;
                        //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                        distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                        //�ʒu�A��������
                        DispManagement(distance);
                    }

                    if (hit.collider.gameObject.GetComponent<Goal>() && m_startobject != hitobject)
                    {
                        //���C�����������I�u�W�F�N�g�Ƃ̋������v�Z
                        distance = Vector3.Distance(m_startobject.transform.position, hit.collider.transform.position);

                        //�ʒu�A��������
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

    //��������
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
