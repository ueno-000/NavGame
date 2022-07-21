using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム上のチュートリアルを管理するマネージャクラス
/// </summary>
public class TutorialManager : MonoBehaviour
{
    // チュートリアル用UI
    protected RectTransform _tutorialTextArea;
    protected Text _tutorialTitle;
    protected Text _tutorialText;

    // チュートリアルタスク
    protected TutorialInterface _currentTask;
    protected List<TutorialInterface> _tutorialTask;

    // チュートリアル表示フラグ
    private bool isEnabled;

    // チュートリアルタスクの条件を満たした際の遷移用フラグ
    private bool _taskExecuted = false;

    // チュートリアル表示時のUI移動距離
    private float _fadePosX = 250;

    void Start()
    {
        // チュートリアル表示用UIのインスタンス取得
        _tutorialTextArea = GameObject.Find("TutorialTextArea").GetComponent<RectTransform>();
        _tutorialTitle = _tutorialTextArea.Find("Title").GetComponent<Text>();
        _tutorialText = _tutorialTextArea.Find("Text").GetComponentInChildren<Text>();

        // チュートリアルの一覧
        _tutorialTask = new List<TutorialInterface>()
        {
            new FirstTask(),
            new MouseWheelTask(),
            new MoveTask(),
            new CameraTask(),
            new ReSpawnTask(),
            new Skill1Task(),
            new Skill2Task(),
            new HPMPTask(),
        };

        // 最初のチュートリアルを設定
        StartCoroutine(SetCurrentTask(_tutorialTask.First()));

        isEnabled = true;
    }

    void Update()
    {
        // チュートリアルが存在し実行されていない場合に処理
        if (_currentTask != null && !_taskExecuted)
        {
            // 現在のチュートリアルが実行されたか判定
            if (_currentTask._isCheckTask())
            {
                _taskExecuted = true;

                DOVirtual.DelayedCall(_currentTask._transitionTime(), () => {
                    iTween.MoveTo(_tutorialTextArea.gameObject, iTween.Hash(
                        "position", _tutorialTextArea.transform.position + new Vector3(_fadePosX, 0, 0),
                        "time", 1f
                    ));

                    _tutorialTask.RemoveAt(0);

                    var nextTask = _tutorialTask.FirstOrDefault();
                    if (nextTask != null)
                    {
                        StartCoroutine(SetCurrentTask(nextTask, 1f));
                    }
                });
            }
        }

        if (Input.GetButtonDown("Help"))
        {
            SwitchEnabled();
        }
    }

    /// <summary>
    /// 新しいチュートリアルタスクを設定する
    /// </summary>
    /// <param name="task"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    protected IEnumerator SetCurrentTask(TutorialInterface task, float time = 0)
    {
        // timeが指定されている場合は待機
        yield return new WaitForSeconds(time);

        _currentTask = task;
        _taskExecuted = false;

        // UIにタイトルと説明文を設定
        _tutorialTitle.text = task._getTitle();
        _tutorialText.text = task._getText();

        // チュートリアルタスク設定時用の関数を実行
        task.OnTaskSetting();

        iTween.MoveTo(_tutorialTextArea.gameObject, iTween.Hash(
            "position", _tutorialTextArea.transform.position - new Vector3(_fadePosX, 0, 0),
            "time", 1f
        ));
    }

    /// <summary>
    /// チュートリアルの有効・無効の切り替え
    /// </summary>
    protected void SwitchEnabled()
    {
        isEnabled = !isEnabled;

        // UIの表示切り替え
        float alpha = isEnabled ? 1f : 0;
        _tutorialTextArea.GetComponent<CanvasGroup>().alpha = alpha;
    }
}