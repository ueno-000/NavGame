using UnityEngine;
using UnityEngine.AI;   // Navmesh Agent を使うために必要
using Photon.Pun;

/// <summary>
/// Navmesh Agent を使って経路探索を行い、移動するためのコンポーネント
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMoveController : MonoBehaviour
{

    [Header("ReSpawn位置：ReSpawnPrefab→Area→［Spawn］をアタッチ"), SerializeField] Transform _reSpawnArea;

    /// <summary>移動先となる位置情報</summary>
    [Space(5),SerializeField] Transform _maker = default;
    /// <summary>移動先座標を保存する変数</summary>
    Vector3 _cachedTargetPosition;

    /// <summary>キャラクターなどのアニメーションするオブジェクトを指定する</summary>
    [SerializeField] Animator _anim = default;

    /// <summary> NavMesh Agent コンポーネントを格納する変数</summary>
    NavMeshAgent _agent = default;

    /// <summary>ReSpawnの判定に使う</summary>
    [Header("Canvas→PlayerUI→Respawnをアタッチ"),SerializeField]SkillReSpawn _respwanSprict;

    /// <summary>リスポーンしたら動かしたくないので作った判定</summary>
    bool _isStop = false;

    PhotonView m_view;
    Rigidbody m_rb;

    void Start()
    {
        m_view = GetComponent<PhotonView>();
        if (m_view)
        {
            if (m_view.IsMine)
            {
                // 同期元（自分で操作して動かす）オブジェクトの場合のみ Rigidbody を使う
                m_rb = GetComponent<Rigidbody>();
            }
        }
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
        if (m_view && !m_view.IsMine) return;  // 同期先のオブジェクトだった場合は何もしない

        // _target が移動したら Navmesh Agent を使って移動させる
        if (Vector3.Distance(_cachedTargetPosition, _maker.position) > Mathf.Epsilon) // _target が移動したら
        {
            if (_isStop == false)
            {
                _cachedTargetPosition = _maker.position; // 移動先の座標を保存する
                _agent.SetDestination(_cachedTargetPosition);  // Navmesh Agent に目的地をセットする
            }

        }
        //リスポーンに戻る処理が行われた場合
        if (_respwanSprict._isReSpawn == true)
        {
            //Playerをリスポ地点に移動
            this.transform.position = _reSpawnArea.position;
            //動きを止める
            _isStop = true;
            _maker.position = _reSpawnArea.position; // 移動先の座標を保存する
            _cachedTargetPosition = _maker.position; // 移動先の座標をリスポ地点にセットする
            _agent.SetDestination(_cachedTargetPosition);  // Navmesh Agent に目的地をセットする
            _isStop = false;
            _respwanSprict._isReSpawn = false;
        }
        // m_animator がアサインされていたら Animator Controller にパラメーターを設定する
        if (_anim)
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }
 


}
