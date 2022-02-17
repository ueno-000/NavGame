using UnityEngine;
/// <summary>
/// 移動のタスク
/// </summary>
public class MoveTask : TutorialInterface
{

    public string _getTitle()
    {
        return "移動";
    }

    public string _getText()
    {
        return "右クリックで指定した位置まで移動できます";
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
