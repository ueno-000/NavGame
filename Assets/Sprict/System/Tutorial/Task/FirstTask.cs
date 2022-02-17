using UnityEngine;
using System;
/// <summary>
/// マウスホイールのタスク
/// </summary>
public class FirstTask : TutorialInterface
{
    public string _getTitle()
    {
        return "ようこそ";
    }

    public string _getText()
    {
        return "最初の操作説明です\r\nまずはこのウィンドウを左クリックしてください。";
    }

    public void OnTaskSetting()
    {
    }

    public bool _isCheckTask()
    {
        if (Input.GetButton("Fire1"))
        {
            return true;
        }
        return false;
    }

    public float _transitionTime()
    {
        return 3f;
    }
}
