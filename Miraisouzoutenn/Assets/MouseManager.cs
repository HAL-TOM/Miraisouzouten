using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public ClickObj clickObj;
    public float spinSpeed;
    // Start is called before the first frame update
    void Start()
    {
        clickObj = null;   
    }

    // Update is called once per frame
    void Update()
    {
        ClickCheeck();
        if(clickObj!=null)
        {

            if (Input.GetKey(KeyCode.A))
            {
                RotateLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                RotateRight();
            }
            if (Input.GetKey(KeyCode.R))
            {
                RotateReset();
            }
        }
    }
    void ClickCheeck()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (clickObj != null)
            {
                clickObj.OutAction();
            }
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                ClickObj onClick;
                if (hit.collider.transform.GetComponent<ClickObj>() != null)
                {
                    onClick = hit.collider.transform.GetComponent<ClickObj>();

                    onClick.OnAction();
                    clickObj = onClick;
                }
            }
        }
    }
    void RotateRight()
    {
        clickObj.transform.Rotate(new Vector3(0, 0, 1), -spinSpeed*Time.deltaTime);
    }
    void RotateLeft()
    {
        clickObj.transform.Rotate(new Vector3(0, 0, 1), spinSpeed * Time.deltaTime);

    }
    void RotateReset()
    {

        clickObj.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
