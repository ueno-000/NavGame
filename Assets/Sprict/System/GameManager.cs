using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//忘れずに追加


public class GameManager : MonoBehaviour,IDeathCount
{
    [Header("SceneManagerを格納"), SerializeField] GameObject _sceneManager;
    Scenemanager scenemanager;

    /// <summary>1ラウンドのゲーム時間</summary>
    [Header("ゲームの制限時間"),SerializeField] public float _gameTimeCount;
    [Header("制限時間表示のテキスト"), SerializeField] Text _timeText;
    
    /// <summary>所持金</summary>
    [SerializeField] public int _money = 500;

    /// <summary>敵を倒した数</summary>
    [SerializeField] public int _enemyKnockCount = 0;
    [SerializeField] Text _enemyCountText;
    /// <summary>Playerの死亡フラグ</summary>
    bool _isDeath = false;
    /// <summary>Playerが死んだ数</summary>
    int _playerDeathCount = 0;

    /// <summary>
    /// Timeが0になった判定
    /// </summary>
    bool _isTimeOut;
    void Start()
    {
        scenemanager = _sceneManager.GetComponent<Scenemanager>();

    }
    void Update()
    {
        _enemyCountText.text = _enemyKnockCount.ToString();
    }

    private void FixedUpdate()
    {
        _gameTimeCount = Mathf.Clamp(_gameTimeCount,0,_gameTimeCount);
        //時間をカウントダウンする
           _gameTimeCount -= Time.deltaTime;

        //時間を表示する
        _timeText.text = _gameTimeCount.ToString("f1") + "s";

        //GameTimeCountが0以下になったとき
        if (_gameTimeCount <= 0 && _isTimeOut == false)
        {
            _isTimeOut = true;
            Debug.Log("ResultSceneへ遷移");
            scenemanager.Fade(false,"TutorialResultScene");
        }
    }

    public void CountDeath(int death)
    {
        _enemyKnockCount += death;
    }

}
