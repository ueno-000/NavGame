using UnityEngine;
using System;
/// <summary>
/// マウスホイールのタスク
/// </summary>
public class MouseWheelTask : TutorialInterface
{
    public string _getTitle()
    {
        return "マウスホイール";
    }

    public string _getText()
    {
        return "次の操作説明です\r\nマウスホイールで画面の距離を変えることができます";
    }

    public void OnTaskSetting()
    {
    }

    public bool _isCheckTask()
    {
       float _wheel = Input.GetAxis("Mouse Scroll");

        if (0 != _wheel)
        {
            return true;
        }

        return false;
    }

    public float _transitionTime()
    {
        return 2f;
    }
}
