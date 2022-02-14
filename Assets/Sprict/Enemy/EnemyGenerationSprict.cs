using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerationSprict : MonoBehaviour
{
    [Header("EnemyPrefabをセットする")]
    [SerializeField] GameObject _enemyPrefab;

    //生成ポジションの指定
    [SerializeField] Transform _position;

    //生成間隔の時間指定
    [SerializeField] float _time = 5f;

    float _setTime = 5f;
    // Update is called once per frame
    void Update()
    {

        //時間
        _time += Time.deltaTime;

        //_timeが_setTimeより大きくなったらprefabを生成する

        if (_time > _setTime)
        {
            Instantiate(_enemyPrefab, _position);

            _time = 0;
        }
    }
}
