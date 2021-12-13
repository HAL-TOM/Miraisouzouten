using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public GameObject[] Fragment;

    public void Event()
    {
        for (int i = 0; i< Fragment.Length; i++)
        {
            Fragment[i].SetActive(true);

            /*

            if (Fragment[i].activeSelf)
            {
                Fragment[i].SetActive(false);
            }
            if (!Fragment[i].activeSelf)
            {
            }
            */

        }

    }
    public void EventRe()
    {

        for (int i = 0; i < Fragment.Length; i++)
        {
            Fragment[i].SetActive(false);
            /*
                if (Fragment[i].activeSelf)
                {
                }
                if (!Fragment[i].activeSelf)
                {
                    Fragment[i].SetActive(true);
                }
                */


        }
    }

}
