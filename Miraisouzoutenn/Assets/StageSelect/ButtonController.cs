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
            this.Button1Click();
        }
        else if ("Button02".Equals(objectName))
        {
            this.Button2Click();
        }
        else if ("Button03".Equals(objectName))
        {
            this.Button3Click();
        }
        else if ("Button04".Equals(objectName))
        {
            this.Button4Click();
        }
        else if ("Button05".Equals(objectName))
        {
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
        if ("Button11".Equals(objectName))
        {
            this.Button11Click();
        }
        else if ("Button12".Equals(objectName))
        {
            this.Button12Click();
        }
        else if ("Button13".Equals(objectName))
        {
            this.Button13Click();
        }
        else if ("Button14".Equals(objectName))
        {
            this.Button14Click();
        }
        else if ("Button15".Equals(objectName))
        {
            this.Button15Click();
        }
        else if ("Button16".Equals(objectName))
        {
            this.Button16Click();
        }
        else if ("Button17".Equals(objectName))
        {
            this.Button17Click();
        }
        else if ("Button18".Equals(objectName))
        {
            this.Button18Click();
        }
        else if ("Button19".Equals(objectName))
        {
            this.Button19Click();
        }
        else if ("Button20".Equals(objectName))
        {
            this.Button20Click();
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

    private void Button11Click()
    {
        Debug.Log("Button11 Click");
    }

    private void Button12Click()
    {
        Debug.Log("Button12 Click");
    }

    private void Button13Click()
    {
        Debug.Log("Button13 Click");
    }

    private void Button14Click()
    {
        Debug.Log("Button14 Click");
    }

    private void Button15Click()
    {
        Debug.Log("Button15 Click");
    }

    private void Button16Click()
    {
        Debug.Log("Button16 Click");
    }

    private void Button17Click()
    {
        Debug.Log("Button17 Click");
    }

    private void Button18Click()
    {
        Debug.Log("Button18 Click");
    }

    private void Button19Click()
    {
        Debug.Log("Button19 Click");
    }

    private void Button20Click()
    {
        Debug.Log("Button20 Click");
    }
}