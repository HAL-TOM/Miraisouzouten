using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fragment3 : MonoBehaviour
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
            anim.SetBool("boolAni", true);
            isUnlocked = true;
            passedTime += Time.deltaTime;
        }
        if (isUnlocked && passedTime >= waitTime)
        {
            anim.SetBool("boolAni", false);
            isUnlocked = false;
        }

    }
}
