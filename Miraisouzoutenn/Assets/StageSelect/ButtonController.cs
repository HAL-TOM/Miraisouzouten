using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonController : BaseButtonController
{
    protected override void OnClick(string objectName)
    {
        // 渡されたオブジェクト名で処理を分岐
        //（オブジェクト名はどこかで一括管理した方がいいかも）
        if ("Button01".Equals(objectName))
        {
            // Button1がクリックされたとき
            this.Button1Click();
        }
        else if ("Button02".Equals(objectName))
        {
            // Button2がクリックされたとき
            this.Button2Click();
        }
        else if ("Button03".Equals(objectName))
        {
            // Button3がクリックされたとき
            this.Button3Click();
        }
        else if ("Button04".Equals(objectName))
        {
            // Button4がクリックされたとき
            this.Button4Click();
        }
        else if ("Button05".Equals(objectName))
        {
            // Button5がクリックされたとき
            this.Button5Click();
        }
        else if ("Button06".Equals(objectName))
        {
            this.Button6Click();
        }
        else if ("Button07".Equals(objectName))
        {
            this.Button7Click();
        }
        else if ("Button08".Equals(objectName))
        {
            this.Button8Click();
        }
        else if ("Button09".Equals(objectName))
        {
            this.Button9Click();
        }
        else if ("Button10".Equals(objectName))
        {
            this.Button10Click();
        }
        else
        {
            throw new System.Exception("Not implemented!!");
        }
    }

    private void Button1Click()
    {
        Debug.Log("Button1 Click");
        SceneManager.LoadScene("Stage1");
    }

    private void Button2Click()
    {
        Debug.Log("Button2 Click");
        SceneManager.LoadScene("Stage2");

    }

    private void Button3Click()
    {
        Debug.Log("Button3 Click");
        SceneManager.LoadScene("Stage3");

    }

    private void Button4Click()
    {
        Debug.Log("Button4 Click");
        SceneManager.LoadScene("Stage4");

    }

    private void Button5Click()
    {
        Debug.Log("Button5 Click");
        SceneManager.LoadScene("Stage5");

    }

    private void Button6Click()
    {
        Debug.Log("Button6 Click");
        SceneManager.LoadScene("Stage6");

    }
    private void Button7Click()
    {
        Debug.Log("Button7 Click");
        SceneManager.LoadScene("Stage7");

    }
    private void Button8Click()
    {
        Debug.Log("Button8 Click");
        SceneManager.LoadScene("Stage8");

    }
    private void Button9Click()
    {
        Debug.Log("Button9 Click");
        SceneManager.LoadScene("Stage9");

    }
    private void Button10Click()
    {
        Debug.Log("Button10 Click");
        SceneManager.LoadScene("Stage10");

    }
}