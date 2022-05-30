using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [Header("敵を倒した数"), SerializeField] int _killCount;
    [SerializeField] Text _killCountText;
    [Header("勝敗のテキスト"),SerializeField] Text _resultText;

    /// <summary>勝敗の判定</summary>
    bool _isClear = false;

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
