using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    bool Hit=false;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Hit == true) return;
        if (collision.transform.GetComponent<cat_light_action>() != null)
        {
            cat_light_action cat = collision.transform.GetComponent<cat_light_action>();

            if (cat.spin)
            {
                Debug.Log("CatHit:"+gameObject.name);
                audio.Play();
                Hit = true;
            }

        }
    }
    
}
