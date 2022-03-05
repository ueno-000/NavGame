using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValueController : MonoBehaviour,IGetValue
{
    /// <summary>プレイヤーレベル</summary>
    [SerializeField] int _level = 1;
    /// <summary> 所持金</summary>
    [SerializeField] int _playerCoin = 500;
    /// <summary> 経験値 </summary>
    [SerializeField] float _playerExp = 0;
    /// <summary>EXPテーブル </summary>
    [SerializeField] int[] _expTable = new int[10];
    /// <summary>時間</summary>
    float _time;

    /// <summary>
    /// 以下毎秒増える処理
    /// </summary>
    [Header("毎秒の加算処理")]
    [SerializeField] int _everyCoin = 10;
    [SerializeField] float _everyExp= 1f;

    private void Update()
    {


        //1秒ごとにコインと経験値が1増える
        _time -= Time.deltaTime;
        if (_time <= 0f)
        {
            _time = 1f;
            _playerCoin += _everyCoin; 
            _playerExp += _everyExp;
        }
    }

    public void GetCoin(int getcoin)
    {
        _playerCoin += getcoin;
    }
    public void GetEXP(float getexp)
    {
        _playerExp += getexp;
    }

    void AddExp(int exp)
    { 
    }
}
