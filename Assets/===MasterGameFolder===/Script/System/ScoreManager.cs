using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコア表示のscript 
/// </summary>

public class ScoreManager : MonoBehaviour
{
    [Tooltip("敵を倒した数"), SerializeField] private int _killCount;
    [SerializeField] private Text _killCountText;
    [Tooltip("勝敗のテキスト"),SerializeField] private Text _resultText;

    /// <summary>勝敗の判定</summary>
    private bool _isClear = false;

    private void Start()
    {
        _killCount = GameManager.getScore();
       _killCountText.text = _killCount.ToString();
        _isClear = GameManager.getJudge();
        
        if (_isClear == true)
        {
            _resultText.text = "CLEAR";
        }
        else 
        {
            _resultText.text = "DEFEAT";
        }

    }
}
