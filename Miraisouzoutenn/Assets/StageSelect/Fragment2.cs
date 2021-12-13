using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fragment2 : MonoBehaviour
{
    private Animator anim;
    private bool isUnlocked;            //アニメーションを一回だけ実行するための変数
    float waitTime;
    float passedTime;

    int[] parameterIds;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        waitTime = 80;
        isUnlocked = false;
        parameterIds = anim.parameters.Select(parameter => parameter.nameHash).ToArray();
    }

    void Update()
    {
        if (!isUnlocked)
        {
            anim.SetBool("booAni", true);
            isUnlocked = true;
            passedTime += Time.deltaTime;
        }
        if (isUnlocked && passedTime >= waitTime)
        {
            anim.SetBool("booAni", false);
            isUnlocked = false;
        }

    }
}
