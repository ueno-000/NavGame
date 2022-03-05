using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//忘れずに追加

public class GameManager : MonoBehaviour
{
    /// <summary>1ラウンドのゲーム時間</summary>
    [SerializeField] public float _gameTime;

    /// <summary>所持金</summary>
    [SerializeField] public int _money = 500;
    /// <summary>1分間に増える金</summary>
    [SerializeField] int _intervalMoney = 1;
    

    /// <summary>敵を倒した数</summary>
    int _enemyKnockCount = 0;
    /// <summary>Playerの死亡フラグ</summary>
    bool _isDeath = false;
    /// <summary>Playerが死んだ数</summary>
    int _playerDeathCount = 0;
    /// <summary></summary>
    void Start()
    {
        // アクティブなオブジェクトを探す
        GameObject target1 = GameObject.Find("FindTarget1");
        Debug.Log("target1 = " + target1);
        // 非アクティブなオブジェクトを探す
        GameObject target2 = GameObject.Find("FindTarget2");
        Debug.Log("target2 = " + target2);
    }
    void Update()
    {
        
    }

}
