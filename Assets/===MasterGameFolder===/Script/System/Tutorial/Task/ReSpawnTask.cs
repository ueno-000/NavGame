using UnityEngine;
/// <summary>
/// カメラのタスク
/// </summary>
public class ReSpawnTask : TutorialInterface
    {

        public string _getTitle()
        {
            return "リスポーン";
        }

        public string _getText()
        {
            return "アイコンボタンで初期位置までリスポーンができます";
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