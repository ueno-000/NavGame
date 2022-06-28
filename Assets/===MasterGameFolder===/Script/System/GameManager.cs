using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//忘れずに追加


public class GameManager : MonoBehaviour,IKillCount
{
    public readonly static GameManager Instance = new GameManager();

    [Tooltip("SceneManagerを格納"), SerializeField] GameObject _sceneManager;
    Scenemanager scenemanager;

    /// <summary>1ラウンドのゲーム時間</summary>
    [Tooltip("ゲームの制限時間"),SerializeField] public float _gameTimeCount;
    [Tooltip("制限時間表示のテキスト"), SerializeField] Text _timeText;
    
    /// <summary>所持金</summary>
    [SerializeField] public int _money = 500;

    /// <summary>敵を倒した数</summary>
    [SerializeField] public static int _enemyKillCount = 0;
    [SerializeField] Text _killCountText;

    /// <summary>Playerの死亡フラグ</summary>
    bool _isDeath = false;

    /// <summary>Playerが死んだ数</summary>
    public static int _playerDeathCount = 0;

    /// <summary> Timeが0になった判定 </summary>
    public bool _isTimeOut = false;

    [Header("EnemyTowerをアタッチ"), SerializeField] GameObject _enemyTower;
    /// <summary>クリアできたかの判定</summary>
    public static bool _isClear = false;

    public static int getScore()
    {
        return _enemyKillCount;        
    }
    public static bool getJudge()
    {
        return _isClear;
    }

    private void Awake()
    {
        _enemyKillCount = 0;
        _isClear = false;
    }
    void Start()
    {

        scenemanager = _sceneManager.GetComponent<Scenemanager>();

    }
    void Update()
    {
        _killCountText.text = _enemyKillCount.ToString();

        if (_enemyTower == null)
        {
            _isClear = true;
        }
    }

    private void FixedUpdate()
    {
        _gameTimeCount = Mathf.Clamp(_gameTimeCount,0,_gameTimeCount);
        //時間をカウントダウンする
           _gameTimeCount -= Time.deltaTime;

        //時間を表示する
        _timeText.text = _gameTimeCount.ToString("f1") + "s";

        //GameTimeCountが0以下になったとき
        if ((_gameTimeCount <= 0 && _isTimeOut == false)||(_isClear == true && _isTimeOut == false))
        {
            _isTimeOut = true;
            Debug.Log("ResultSceneへ遷移");
            scenemanager.Fade(false,"TutorialResultScene");
        }
    }

    public void CountKill(int death)
    {
        _enemyKillCount += death;
    }

}
