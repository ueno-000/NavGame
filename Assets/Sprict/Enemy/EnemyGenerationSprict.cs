using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerationSprict : MonoBehaviour
{
    [Header("EnemyPrefabをセットする")]
    [SerializeField] GameObject _enemyPrefab;

    [Header("生成数")]
    [SerializeField] int _enemyNum;

    //生成ポジションの指定
    [Header("生成ポジションの配列")]
    [SerializeField] Transform[]  _position;

    [Header("SetTImeも同じ値を追加")]
    //生成間隔の時間指定
    [SerializeField] float _time = 5f;
    [SerializeField] float _setTime = 5f;

    /// <summary>
    /// ヒエラルキー上にいる敵の数
    /// </summary>
    private GameObject[] _enemyBox;



    void FixedUpdate()
    {
        _enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        //時間
        _time += Time.deltaTime;

        //ヒエラルキー上のEnemyの数が指定した数以下のときは生成する
        if (_enemyBox.Length <= _enemyNum)
        {
            //_timeが_setTimeより大きくなったらprefabを生成する
            if (_time > _setTime)
            {
                for (int i = 0; i < _position.Length; i++)
                {
                    if (_position[i] != null)
                    {
                        Instantiate(_enemyPrefab, _position[i]);
                    }
                    else
                    {
                        Debug.Log("生成できません");
                    }
                }
                _time = 0;
            }
        }
    }


}
