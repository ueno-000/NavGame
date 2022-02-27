using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerationSprict : MonoBehaviour
{
    [Header("EnemyPrefabをセットする")]
    [SerializeField] GameObject _enemyPrefab;

    //生成ポジションの指定
    [Header("生成ポジションの配列")]
    [SerializeField] Transform[]  _position;

    [Header("SetTImeも同じ値を追加")]
    //生成間隔の時間指定
    [SerializeField] float _time = 5f;
    [SerializeField] float _setTime = 5f;
    // Update is called once per frame
    void Update()
    {

        //時間
        _time += Time.deltaTime;

        //_timeが_setTimeより大きくなったらprefabを生成する

        if (_time > _setTime)
        {
            for (int i = 0; i < _position.Length; i++) 
            {
                Instantiate(_enemyPrefab, _position[i]);
            }
            _time = 0;
        }
    }
}
