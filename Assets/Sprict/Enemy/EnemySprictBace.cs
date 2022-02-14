using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySprictBace : MonoBehaviour
{
    // 巡回地点オブジェクトを格納する配列
    [Header("巡回Pointを指定する")]
    public Vector3[] _points;
    // 巡回地点のオブジェクト数（初期値=0）
    private int _destPoint = 0;

    /// <summary>
    /// NavMesh Agent コンポーネントを格納する変数
    /// </summary>
    [HideInInspector]
    public NavMeshAgent _agent;

    /// <summary>
    ///  SphereColliderで当たり判定をとる
    /// </summary>
    SphereCollider _attackCol = default;

    //SphereColliderの大きさ
    [Header("コライダーの範囲")]
    [SerializeField,Range(1.0f, 10.0f)] float _attackRange;

    [Space(10)]

    [SerializeField] int _hp;

    //animation
    Animator _anim = default;


    //Player
    GameObject _player = default;

    //インスペクター上から行動設定できるようにする
    [SerializeField] Action action = Action.Patrol;

    [Tooltip("Caractorを追う時間")]
    [SerializeField] float _time;
    [Tooltip("Caractorを攻撃する時間")]
    [SerializeField] float _timeAttack;


    enum Action
    {
        Patrol,//決められた地点を巡回する
        Chase,//対象のキャラクターを追いかける
        Attack//攻撃
    }


    void Start()
    {
        //Playerタグのオブジェクトを取得
        _player = GameObject.FindGameObjectWithTag("Player");

        _attackCol = GetComponent<SphereCollider>();
        
        //animation取得
        _anim = GetComponent<Animator>();

        _agent = GetComponent<NavMeshAgent>();
        // autoBraking を無効にする事で、目標地点の間を継続的に移動する(エージェントは目標地点に近づいても速度をおとさない)
        _agent.autoBraking = false;
        _agent.speed = 1;

        GotoNextPoint();
    }

    /// <summary>
    /// 次の巡回地点を設定する処理
    /// </summary>
    void GotoNextPoint()
    {
        // 巡回地点がなにも設定されていないときに返す
        if (_points.Length == 0)
        {
            return;
        }
        // 現在選択されている配列の座標を巡回地点の座標に代入
        _agent.destination = _points[_destPoint];
        // 配列内の次の位置を目標地点に設定し、 必要ならば出発地点にもどる
        _destPoint = (_destPoint + 1) % _points.Length;
    }


    void Update()
    {
        //コライダーの大きさをupdateで変える
        _attackCol.radius = _attackRange;

        //Animationの制御
        if (_anim)
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);
        }


        //＝＝＝＝以下列挙型の処理＝＝＝＝



        //＝＝＝＝actionがpatrolの場合
        if (action == Action.Patrol)
        {
            _agent.isStopped = false;
            // エージェントが現在の巡回地点に到達したら
            if (!_agent.pathPending && _agent.remainingDistance < 0.5)
            {
                Debug.Log("到達：次の巡回地点を設定");
                // 次の巡回地点を設定する処理を実行
                GotoNextPoint();
            }

        }
        //＝＝＝＝chaseの場合
        else if (action == Action.Chase)
        {
            _agent.destination = _player.transform.position;

            //５秒立ったらPatrolに戻る
            _time += Time.deltaTime;

            if (_time > 5)
            {
                action = Action.Patrol;
                _time = 0;
            }
        }
        //＝＝＝attackの場合
        else if (action == Action.Attack)
        {
            _agent.speed = 0f;
            _agent.isStopped = true;
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * 10, Space.World);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        //Patrolの時にPlayerタグのオブジェクトに当たったらChaseに
        if (col.gameObject.tag == "Player" && action == Action.Patrol)
        {
            action = Action.Chase;
        }

        //Chaseの時にPlayerタグのオブジェクトに当たったらAttackに
        if (col.gameObject.tag == "Player" && action == Action.Chase)
        {
            action = Action.Attack;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" && action == Action.Attack)
        {
            action = Action.Patrol;
            _agent.speed = 1f;
            _agent.isStopped = false;
            Debug.Log("到達：次の巡回地点を設定");
            // 次の巡回地点を設定する処理を実行
            GotoNextPoint();
        }
    }

}
