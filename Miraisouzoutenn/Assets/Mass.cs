using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour
{
    static public MassManager massManager;
    [SerializeField] Material material;
    [SerializeField] public GameObject obj=null;
    bool Hit = false;
    // Start is called before the first frame update
    void Start()
    {
        material = this.GetComponent<Renderer>().material;
        material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //�ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);

        //���݈ʒu(�}�E�X�ʒu)���ApointScreen�Ɋi�[
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z);

        //���݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
      //  Debug.Log(pointWorld);
        pointWorld.z = transform.position.z;
        Vector2 o = new Vector2(transform.position.x - pointWorld.x, transform.position.y - pointWorld.y);
        if ((o.x <= transform.lossyScale.x / 2) &&
            (o.x >= -transform.lossyScale.x / 2) &&
            (o.y <= transform.lossyScale.y / 2) &&
            (o.y >= -transform.lossyScale.y / 2))
        {
            material.color = new Color(material.color.r, material.color.g, material.color.b, 1.0f);
        }
        else
        {
            material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);
        }


    }
    public void SetObj(GameObject gameObject)
    {
        obj = gameObject;
    }
    /*
    private void OnMouseEnter()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b, 1.0f);
    }
    private void OnMouseExit()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);
    }
    */
}
