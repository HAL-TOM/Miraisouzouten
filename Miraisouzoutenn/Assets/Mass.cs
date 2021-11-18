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

    
    }
    public void SetObj(GameObject gameObject)
    {
        obj = gameObject;
    }
    private void OnMouseEnter()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b, 1.0f);
    }
    private void OnMouseExit()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);
    }

}
