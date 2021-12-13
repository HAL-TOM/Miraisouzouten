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
    public static int scoreNum;

    void Start()
    {
        backFlag = false;
    }

    protected override void OnClick(string objectName)
    {
        // �n���ꂽ�I�u�W�F�N�g���ŏ����𕪊�
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

    public static int GetScoreNum()
    {
        return scoreNum;
    }

    private void Button1Click()
    {
        sceneName = "Stage1";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 1)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 0;

    }

    private void Button2Click()
    {
        sceneName = "Stage2";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 2)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 1;
    }

    private void Button3Click()
    {
        sceneName = "Stage3";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 3)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 2;

    }

    private void Button4Click()
    {
        sceneName = "Stage4";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 4)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 3;
    }

    private void Button5Click()
    {
        sceneName = "Stage5";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 5)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 4;
    }

    private void Button6Click()
    {
        sceneName = "Stage6";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 6)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 5;
    }

    private void Button7Click()
    {
        sceneName = "Stage7";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 7)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 6;
    }

    private void Button8Click()
    {
        sceneName = "Stage8";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 8)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 7;
    }

    private void Button9Click()
    {
        sceneName = "Stage9";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 9)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 8;
    }

    private void Button10Click()
    {
        sceneName = "Stage10";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 10)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = false;

        scoreNum = 9;
    }

    private void Button11Click()
    {
        sceneName = "Stage11";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 11)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 10;
    }

    private void Button12Click()
    {
        sceneName = "Stage12";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 12)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 11;
    }

    private void Button13Click()
    {
        sceneName = "Stage13";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 13)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 12;
    }

    private void Button14Click()
    {
        sceneName = "Stage14";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 14)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 13;
    }

    private void Button15Click()
    {
        sceneName = "Stage15";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 15)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 14;
    }

    private void Button16Click()
    {
        sceneName = "Stage16";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 16)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 15;
    }

    private void Button17Click()
    {
        sceneName = "Stage17";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 17)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 16;
    }

    private void Button18Click()
    {
        sceneName = "Stage18";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 18)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 17;
    }

    private void Button19Click()
    {
        sceneName = "Stage19";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 19)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }
        backFlag = true;

        scoreNum = 18;
    }

    private void Button20Click()
    {
        sceneName = "Stage20";

        //�J������Ă��邩
        if (ReleaseStage.stageNum <= 20)
        {
            Enter.flag = false;
        }
        else
        {
            Enter.flag = true;
        }

        backFlag = true;

        scoreNum = 19;
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
        //�߂���
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