using UnityEngine;

public class HPMPTask : TutorialInterface
{

    public string _getTitle()
    {
        return "HPとMP";
    }

    public string _getText()
    {
        return "下のに2つのバーがあります\r\n上がHP　下がMPです\r\n左クリックで次のタスクへ";
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
        return 2f;
    }
}
