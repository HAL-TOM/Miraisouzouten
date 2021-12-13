using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleareBG : MonoBehaviour
{
    float fadeSpeed = 0.0006f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理
    //クリア時のランク格納
    public float rank;

    //テクスチャを用意。
    public Texture image;
    public Texture image2;
    public Texture image3;

    bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    bool isFadeIn = true;   //フェードイン処理の開始、完了を管理するフラグ

    Image fadeImage;                //透明度を変更するパネルのイメージ

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
        //クリア時のランクを格納
        //rank = rank;

        if (isFadeIn)
        {
            StartFadeIn();
        }


        if (rank == 1)
        {
            //texture変更1
            GetComponent<Image>().material.mainTexture = image;

        }
        if (rank == 2)
        {
            //texture変更2
            GetComponent<Image>().material.mainTexture = image2;

        }
        if (rank == 3)
        {
            //texture変更3
            GetComponent<Image>().material.mainTexture = image3;

        }


    }

    //alfa値を0から1まで徐々に加算していく
    void StartFadeIn()
    {
        alfa += fadeSpeed;                //a)不透明度を徐々に下げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
        if (alfa >= 1)
        {                    //c)完全に透明になったら処理を抜ける
            isFadeIn = false;
            //isFadeOut = true;
        }
    }

    

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}