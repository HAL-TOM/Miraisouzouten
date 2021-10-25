using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float time;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        time = 60;
        text = transform.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        text.text = time.ToString();
        if(time<0)
        {
            time = 0;
            //I—¹ˆ—
            this.enabled = false;
        }
    }
}
