using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// "NavMeshAgent"関連クラスを使用できるようにする
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    // 巡回地点オブジェクトを格納する配列
    [Tooltip("巡回Pointを指定する")]
    public Transform[] _points;
    // 巡回地点のオブジェクト数（初期値=0）
    private int _destPoint = 0;

    // NavMesh Agent コンポーネントを格納する変数
    [HideInInspector]
    public NavMeshAgent _agent;


    // ゲームスタート時の処理
    void Start()
    {
        // 変数"agent"に NavMesh Agent コンポーネントを格納
        _agent = GetComponent<NavMeshAgent>();
        // 巡回地点間の移動を継続させるために自動ブレーキを無効化
        //（エージェントは目的地点に近づいても減速しない)
        _agent.autoBraking = false;
        // 次の巡回地点の処理を実行
        GotoNextPoint();
    }
    // ゲーム実行中の繰り返し処理
    void Update()
    {
        // エージェントが現在の巡回地点に到達したら
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            // 次の巡回地点を設定する処理を実行
            GotoNextPoint();
    }
    // 次の巡回地点を設定する処理
    void GotoNextPoint()
    {
        // 巡回地点が設定されていなければ
        if (_points.Length == 0)
            // 処理を返します
            return;
        // 現在選択されている配列の座標を巡回地点の座標に代入
        _agent.destination = _points[_destPoint].position;
        // 配列の中から次の巡回地点を選択（必要に応じて繰り返し）
        _destPoint = (_destPoint + 1) % _points.Length;
    }

    //public void Explode(Vector3 center, float damage)
    //{
    //    Debug.Log("爆発によるダメージを受けた");
    //    //// 体力を増減してゲージに反映
    //    //HP += -damage;
    //    //HP = Mathf.Clamp(HP, 0f, 1f);
    //    //HpImage.fillAmount = HP;

    //}
}
