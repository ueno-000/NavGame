using UnityEngine;
/// <summary>
/// カメラのタスク
/// </summary>
public class CameraTask : TutorialInterface
{

    public string _getTitle()
    {
        return "カメラの追従";
    }

    public string _getText()
    {
        return "右下のボタンからカメラの追従制御を変えられます";
    }

    public void OnTaskSetting()
    {
    }

    public bool _isCheckTask()
    {
        if (Input.GetButton("Fire2"))
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

