using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TutorialInterface
{
    /// <summary>
    /// チュートリアル用のタイトルを取得する
    /// </summary>
    /// <returns></returns>
    string _getTitle();

    /// <summary>
    /// 説明文を取得する
    /// </summary>
    /// <returns></returns>
    string _getText();

    /// <summary>
    /// チュートリアルのタスクが設定されたとき実行される
    /// </summary>
    void OnTaskSetting();

    /// <summary>
    ///チュートリアルが達成されたか判定 
    /// </summary>
    /// <returns></returns>
    bool _isCheckTask();

    /// <summary>
    /// 達成後に次のタスクに遷移するまでの時間
    /// </summary>
    /// <returns></returns>
    float _transitionTime();
}
