using UnityEngine;
using UnityEngine.AI;   // Navmesh Agent を使うために必要

/// <summary>
/// Navmesh Agent を使って経路探索を行い、移動するためのコンポーネント
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMoveController : MonoBehaviour
{
    /// <summary>拠点のTransform</summary>
    [Tooltip("ReSpawn位置：ReSpawnPrefab→Area→［Spawn］をアタッチ"), SerializeField] private Transform _reSpawnArea;
    /// <summary>移動先となる位置情報</summary>
    [Space(5),]
    [SerializeField] private Transform _maker = default;
    /// <summary>移動先座標を保存する変数</summary>
    private Vector3 _cachedTargetPosition;

    /// <summary>キャラクターなどのアニメーションするオブジェクトを指定する</summary>
    [SerializeField] private Animator _anim = default;

    /// <summary> NavMesh Agent コンポーネントを格納する変数</summary>
    private NavMeshAgent _agent = default;

    /// <summary>ReSpawnの判定に使う</summary>
    [Header("Canvas→PlayerUI→Respawnをアタッチ"),SerializeField] private SkillReSpawn _respwanSprict;

    /// <summary>リスポーンしたら動かしたくないので作った判定</summary>
    private bool isStop = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        // 初期位置を保存する（※）
        _cachedTargetPosition = _maker.position; 
        //Playerを指定したポジションから開始させる
        this.transform.position = _reSpawnArea.position;

    }

    /*
     * （※）_cachedTargetPosition を使って座標を保存しているのは、
     * 以下の Update() 内で「毎フレーム座標をセットする」という処理を避け、負荷を下げるためである。
     * 毎フレーム座標をセットすることで経路の計算を毎フレームしてしまうことを避けるため、
     * 「Target が移動した時のみ」目的地をセットして経路の計算を行わせている。
     */

    void Update()
    {

        // _target が移動したら Navmesh Agent を使って移動させる
        if (Vector3.Distance(_cachedTargetPosition, _maker.position) > Mathf.Epsilon) // _target が移動したら
        {
            if (isStop == false)
            {
                _cachedTargetPosition = _maker.position; // 移動先の座標を保存する
                _agent.SetDestination(_cachedTargetPosition);  // Navmesh Agent に目的地をセットする
            }

        }
        //リスポーンに戻る処理が行われた場合
        if (_respwanSprict.isReSpawn == true)
        {
            //Playerをリスポ地点に移動
            this.transform.position = _reSpawnArea.position;
            //動きを止める
            isStop = true;
            _maker.position = _reSpawnArea.position; // 移動先の座標を保存する
            _cachedTargetPosition = _maker.position; // 移動先の座標をリスポ地点にセットする
            _agent.SetDestination(_cachedTargetPosition);  // Navmesh Agent に目的地をセットする
            isStop = false;
            _respwanSprict.isReSpawn = false;
        }
        // m_animator がアサインされていたら Animator Controller にパラメーターを設定する
        if (_anim)
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }
 


}
