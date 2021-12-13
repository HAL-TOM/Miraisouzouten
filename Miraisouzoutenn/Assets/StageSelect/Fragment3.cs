using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fragment3 : MonoBehaviour
{
    private Animator anim;
    private bool isUnlocked;            //�A�j���[�V��������񂾂����s���邽�߂̕ϐ�
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
