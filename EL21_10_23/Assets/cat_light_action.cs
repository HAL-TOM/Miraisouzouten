using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_light_action : MonoBehaviour
{
    public Rigidbody2D rigidbody2;
    public Vector2 Speed;
    public float spinPower;
    public bool spin = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 =transform.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2.AddForce(new Vector2(0, Speed.y)*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {

            rigidbody2.AddForce(new Vector2(-Speed.x, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            spin = true;
            rigidbody2.angularVelocity = spinPower * Time.deltaTime;
        }else
        {
            ResetSpin();
        }

        if (Input.GetKey(KeyCode.D))
        {

            rigidbody2.AddForce(new Vector2(Speed.x, 0) * Time.deltaTime);
        }
    }
    private void ResetSpin()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        rigidbody2.angularVelocity = 0;
        spin = false;
    }

}
