using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleareBG : MonoBehaviour
{
    float fadeSpeed = 0.0006f;        //�����x���ς��X�s�[�h���Ǘ�
    float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�
    //�N���A���̃����N�i�[
    public float rank;

    //�e�N�X�`����p�ӁB
    public Texture image;
    public Texture image2;
    public Texture image3;

    bool isFadeOut = false;  //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
    bool isFadeIn = true;   //�t�F�[�h�C�������̊J�n�A�������Ǘ�����t���O

    Image fadeImage;                //�����x��ύX����p�l���̃C���[�W

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        alfa = 0;
    }

    void Update()
    {
        //�N���A���̃����N���i�[
        //rank = rank;

        if (isFadeIn)
        {
            StartFadeIn();
        }


        if (rank == 1)
        {
            //texture�ύX1
            GetComponent<Image>().material.mainTexture = image;

        }
        if (rank == 2)
        {
            //texture�ύX2
            GetComponent<Image>().material.mainTexture = image2;

        }
        if (rank == 3)
        {
            //texture�ύX3
            GetComponent<Image>().material.mainTexture = image3;

        }


    }

    //alfa�l��0����1�܂ŏ��X�ɉ��Z���Ă���
    void StartFadeIn()
    {
        alfa += fadeSpeed;                //a)�s�����x�����X�ɉ�����
        SetAlpha();                      //b)�ύX�����s�����x�p�l���ɔ��f����
        if (alfa >= 1)
        {                    //c)���S�ɓ����ɂȂ����珈���𔲂���
            isFadeIn = false;
            //isFadeOut = true;
        }
    }

    

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}