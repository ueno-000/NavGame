using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprictBace : MonoBehaviour
{
    //SphereCollider
    SphereCollider _attackCol = default;
    //SphereColliderの大きさ
    [Header("コライダーの範囲")]
    [SerializeField,Range(1.0f, 10.0f)] float _attackRange;
    [Space(10)]
    //animation
    Animator _anim = default;
    //EnemyPatrolから_Agentを取得するため
    EnemyPatrol enemyPatrol;
    //Player
    GameObject _player = default;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _attackCol = GetComponent<SphereCollider>();
        _anim = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
    }

    private void Update()
    {
        _attackCol.radius = _attackRange;
        //Animationの制御
        if (_anim)
        {
            _anim.SetFloat("Speed", enemyPatrol._agent.velocity.magnitude);
        }
    }

    //void LateUpdate()
    //{
    //    // プレイヤーの方を見る
    //    if (_player)
    //    {
    //        this.transform.forward = _player.transform.position - this.transform.position;
    //    }
    //}

}
