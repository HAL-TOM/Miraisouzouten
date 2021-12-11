using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FragmentAnimation : MonoBehaviour
{
    public static int Count;
    private Animator anim;
    public static bool isUnlocked;            //アニメーションを一回だけ実行するための変数
    float waitTime;
    float passedTime;

    int[] parameterIds;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        isUnlocked = false;
        waitTime = 60;

        parameterIds = anim.parameters.Select(parameter => parameter.nameHash).ToArray();
    }

    void Update()
    {
        if (!isUnlocked)
        {
            anim.SetBool(parameterIds[0], true);
            isUnlocked = true;
            passedTime += Time.deltaTime;
        }
        if (isUnlocked && passedTime >= waitTime)
        {
            anim.SetBool(parameterIds[0], false);
        }

    }
}
