using UnityEngine;
using UnityEngine.UI;
using System.Linq;
/// <summary>
/// Playerの各種値の管理するscript
/// </summary>
public class PlayerValueController : MonoBehaviour,IGetValue
{
    [Header("【TextはCanvas→PlayerValueから格納する】")]
    [SerializeField] private bool _isCheck;
    /// <summary> プレイヤーレベル</summary>
    [Tooltip("プレイヤーレベル"),SerializeField] private int _playerLevel = 1;
    [SerializeField] Text _levelText;
    /// <summary> 所持金</summary>
    [Tooltip("所持コイン"), SerializeField] private int _playerCoin = 500;
    [SerializeField] private Text _coinText;
    /// <summary> 経験値 </summary>
    [Tooltip("経験値"),SerializeField] private int _playerExp = 0;
    [SerializeField] private Text _expText;
    /// <summary>EXPテーブル </summary>
    [SerializeField] private int[] _expTable = new int[10];
    /// <summary> 次のレベルに持ち越す残った経験値 </summary>
    [SerializeField] private int _remainExp;
    /// <summary>時間</summary>
    private float _time;

    /// <summary>
    /// 以下毎秒増える処理
    /// </summary>
    [Header("毎秒の加算処理")]
    [SerializeField] private int _everyCoin = 10;
    [SerializeField] private int _everyExp= 1;

    private void Start()
    {
        _playerExp = Mathf.Clamp(_playerExp, 0, _expTable[_expTable.Length - 1]);
    }
    private void Update()
    {
        _levelText.text = _playerLevel.ToString();
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

        //UpdateLevel(_expTable);
        //UpdateRemainExp(_expTable);

    }


    public void GetCoin(int getcoin)
    {
        _playerCoin += getcoin;
    }
    public void GetEXP(int getexp)
    {
        _playerExp += getexp;
    }

    //レベルアップの処理
    void UpdateLevel(int[] expArray)
    {
        // 現Exp以下の値の中で最大の値のインデックスを取得
        var maxIdx = expArray
                          .Where(x => x <= _playerExp)//ｘはＥＸＰ以下の値
                          .Select((val, idx) => new { V = val, I = idx })
                          .Aggregate((maxVal, nexVal) => (maxVal.V > nexVal.V) ? maxVal : nexVal)//maxValがnexValより大きい時maxValを返す
                          .I;//出た値のインデックスを取得
        _playerLevel = maxIdx + 1;
    }

    ///レベルアップ後の残ったExp
    void UpdateRemainExp(int[] expArray)
    {
        // 現Expより大きい値の中で最小の値のインデックスを取得
        var minIdx = expArray
                        .Where(x => x > _playerExp)//ｘはＥＸＰ以下の値
                        .Select((val, idx) => new { V = val, I = idx })
                        .Aggregate((minVal, nexVal) => (minVal.V < nexVal.V) ? minVal : nexVal)//minValがnexValより小さい時minValを返す
                        .I;//出た値のインデックスを取得
        _remainExp = expArray[minIdx] - _playerExp;
    }
}
