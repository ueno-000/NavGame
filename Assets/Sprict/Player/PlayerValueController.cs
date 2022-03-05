using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValueController : MonoBehaviour,IGetValue
{
    [Header("【TextはCanvas→PlayerValueから格納する】")]
    [SerializeField] bool _isCheck;
    /// <summary>
    /// プレイヤーレベル
    /// </summary>
    [Header("プレイヤーレベル"),SerializeField] int _playerLevel = 1;
    [SerializeField] Text _levelText;
    /// <summary> 
    /// 所持金
    /// </summary>
    [Header("所持コイン"), SerializeField] int _playerCoin = 500;
    [SerializeField] Text _coinText;
    /// <summary>
    /// 経験値 
    /// </summary>
    [Header("経験値"),SerializeField] float _playerExp = 0;
    [SerializeField] Text _expText;
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
        _coinText.text = _playerCoin.ToString();
        _expText.text = _playerExp.ToString();

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
       // _coinText.text = _playerCoin.ToString();
    }
    public void GetEXP(float getexp)
    {
        _playerExp += getexp;
        //_expText.text = _playerExp.ToString();
    }

    //// Expを加算してLvを初期化する
    //public void AddExp(int exp, int[] expArray)
    //{
    //    //カンストを考慮して加算
    //    _exp = Mathf.Clamp(_exp + exp, 0, expArray[expArray.Length - 1]);
    //    // 値の更新
    //    UpdateLevel(expArray);
    //    UpdateRemainExp(expArray);
    //}

    //void UpdateLevel(int[] expArray)
    //{
    //    // 現Exp以下の値の中で最大の値のインデックスを取得
    //    var maxIdx = expArray.Where(x => x <= _exp).Select((val, idx) => new { V = val, I = idx })
    //        .Aggregate((max, working) => (max.V > working.V) ? max : working).I;
    //    _level = maxIdx + 1;
    //}

    //void UpdateRemainExp(int[] expArray)
    //{
    //    // 現Expより大きい値の中で最小の値のインデックスを取得
    //    var minIdx = expArray.Where(x => x > _exp).Select((val, idx) => new { V = val, I = idx })
    //        .Aggregate((min, working) => (min.V < working.V) ? min : working).I;
    //    _remainExp = expArray[minIdx] - _exp;
    //}
}
