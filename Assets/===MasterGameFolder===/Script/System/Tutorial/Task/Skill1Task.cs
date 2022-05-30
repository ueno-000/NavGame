using UnityEngine;
/// <summary>
/// カメラのタスク
/// </summary>
public class Skill1Task : TutorialInterface
{

    public string _getTitle()
    {
        return "スキル";
    }

    public string _getText()
    {
        return "一番左のスキル\r\n自分から波動が出る";
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