using UnityEngine;
/// <summary>
/// カメラのタスク
/// </summary>
public class Skill2Task : TutorialInterface
{

    public string _getTitle()
    {
        return "スキル２";
    }

    public string _getText()
    {
        return "真ん中のスキル\r\nターゲットの場所を爆発させる";
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
        return 5f;
    }
}