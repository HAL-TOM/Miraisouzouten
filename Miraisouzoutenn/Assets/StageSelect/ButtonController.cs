using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : BaseButtonController
{
    public string sceneName;
    public PanelChange panel;
    public bool backFlag;
    public bool returnFlag;

    void Start()
    {
        backFlag = false;
    }

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
        else if ("Button11".Equals(objectName))
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
        else if ("Yes".Equals(objectName))
        {
            this.YesClick();
        }
        else if ("No".Equals(objectName))
        {
            this.NoClick();
        }
        else if ("Audio".Equals(objectName))
        {
        }
        else if ("Title".Equals(objectName))
        {
        }
        else if ("Back".Equals(objectName))
        {
            this.BackClick();
        }
        else
        {
            throw new System.Exception("Not implemented!!");
        }

    }

    private void Button1Click()
    {
        Debug.Log("Button1 Click");
        sceneName = "Stage1";
        backFlag = false;
    }

    private void Button2Click()
    {
        Debug.Log("Button2 Click");
        sceneName = "Stage2";
        backFlag = false;

    }

    private void Button3Click()
    {
        Debug.Log("Button3 Click");
        sceneName = "Stage3";
        backFlag = false;

    }

    private void Button4Click()
    {
        Debug.Log("Button4 Click");
        sceneName = "Stage4";
        backFlag = false;

    }

    private void Button5Click()
    {
        Debug.Log("Button5 Click");
        sceneName = "Stage5";
        backFlag = false;

    }

    private void Button6Click()
    {
        Debug.Log("Button6 Click");
        sceneName = "Stage6";
        backFlag = false;

    }

    private void Button7Click()
    {
        Debug.Log("Button7 Click");
        sceneName = "Stage7";
        backFlag = false;

    }

    private void Button8Click()
    {
        Debug.Log("Button8 Click");
        sceneName = "Stage8";
        backFlag = false;

    }

    private void Button9Click()
    {
        Debug.Log("Button9 Click");
        sceneName = "Stage9";
        backFlag = false;

    }

    private void Button10Click()
    {
        Debug.Log("Button10 Click");
        sceneName = "Stage10";
        backFlag = false;

    }

    private void Button11Click()
    {
        Debug.Log("Button11 Click");
        backFlag = true;

    }

    private void Button12Click()
    {
        Debug.Log("Button12 Click");
        backFlag = true;

    }

    private void Button13Click()
    {
        Debug.Log("Button13 Click");
        backFlag = true;

    }

    private void Button14Click()
    {
        Debug.Log("Button14 Click");
        backFlag = true;

    }

    private void Button15Click()
    {
        Debug.Log("Button15 Click");
        backFlag = true;

    }

    private void Button16Click()
    {
        Debug.Log("Button16 Click");
        backFlag = true;

    }

    private void Button17Click()
    {
        Debug.Log("Button17 Click");
        backFlag = true;

    }

    private void Button18Click()
    {
        Debug.Log("Button18 Click");
        backFlag = true;

    }

    private void Button19Click()
    {
        Debug.Log("Button19 Click");
        backFlag = true;

    }

    private void Button20Click()
    {
        Debug.Log("Button20 Click");
        backFlag = true;

    }

    private void YesClick()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void NoClick()
    {
        if (!backFlag)
        {
            panel.MainView();
        }
        else if (backFlag)
        {
            panel.SubView();
        }
    }

    private void BackClick()
    {
        if (!returnFlag)
        {
            panel.MainView();
        }
        else if (returnFlag)
        {
            panel.SubView();
        }
    }

}