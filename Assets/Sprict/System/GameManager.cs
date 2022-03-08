using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;//忘れずに追加


public class GameManager : MonoBehaviour,IDeathCount
{
    public static GameManager Instance;

    /// <summary>1ラウンドのゲーム時間</summary>
    [SerializeField] public float _gameTime;

    /// <summary>所持金</summary>
    [SerializeField] public int _money = 500;

    

    /// <summary>敵を倒した数</summary>
    [SerializeField] public int _enemyKnockCount = 0;
    [SerializeField] Text _enemyCountText;
    /// <summary>Playerの死亡フラグ</summary>
    bool _isDeath = false;
    /// <summary>Playerが死んだ数</summary>
    int _playerDeathCount = 0;
    /// <summary></summary>
    void Start()
    {


    }
    void Update()
    {
        _enemyCountText.text = _enemyKnockCount.ToString();
    }

    public void CountDeath(int death)
    {
        _enemyKnockCount += death;
    }

}
