using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    const float COLOR_R = 0.0f;
    const float COLOR_G = 0.0f;
    const float COLOR_B = 0.0f;

    const float FADE_SECONDS = 1.0f;
    const float SPEED = 1.0f / FADE_SECONDS;

    static float m_Alpha;
    static bool m_IsFade;
    static bool m_FadeIn;
    static bool m_FadeOut;
    

    // Start is called before the first frame update
    void Start()
    {
        m_Alpha = 1.0f;
        m_IsFade = false;
        m_FadeIn = true;
        m_FadeOut = false;

        gameObject.GetComponent<Image>().color = new Color(COLOR_R, COLOR_G, COLOR_B, m_Alpha);
    }

    // Update is called once per frame
    void Update()
    {
        //フェードイン
        if (m_FadeIn)
        {
            if (m_IsFade)
            {
                m_Alpha -= SPEED * Time.deltaTime;

                if (m_Alpha <= 0.0f)
                {
                    m_Alpha = 0.0f;
                    m_FadeIn = false;
                }

                gameObject.GetComponent<Image>().color = new Color(COLOR_R, COLOR_G, COLOR_B, m_Alpha);
            }

            if (!m_IsFade)
                m_IsFade = true;

            if (!m_FadeIn)
                m_IsFade = false;
        }

        //フェードアウト
        if (m_FadeOut)
        {
            if (m_IsFade)
            {
                m_Alpha += SPEED * Time.deltaTime;

                if (m_Alpha >= 1.0f)
                {
                    m_Alpha = 1.0f;
                    m_FadeOut = false;
                }

                gameObject.GetComponent<Image>().color = new Color(COLOR_R, COLOR_G, COLOR_B, m_Alpha);
            }

            if (!m_IsFade)
                m_IsFade = true;

            if (!m_FadeOut)
                m_IsFade = false;
        }

        //フェードインアウト確認用
        if (Input.GetKeyDown(KeyCode.F1))
            StartFadeIn();
        //if (!m_IsFade)
        //    if (!m_FadeOut)
        //        m_FadeIn = true;

        if (Input.GetKeyDown(KeyCode.F2))
            StartFadeOut();
        //if (!m_IsFade)
        //    if (!m_FadeIn)
        //        m_FadeOut = true;

    }

    public void StartFadeOut()
    {
        if (!m_IsFade)
            if (!m_FadeIn)
                m_FadeOut = true;
    }

    public void StartFadeIn()
    {
        if (!m_IsFade)
            if (!m_FadeOut)
                m_FadeIn = true;
    }

    public bool GetIsFade()
    {
        return m_IsFade;
    }
}
