using UnityEngine;
using UnityEngine.AI;   // Navmesh Agent を使うために必要

/// <summary>
/// Navmesh Agent を使って経路探索を行い、移動するためのコンポーネント
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// デバッグモードTrueにすると攻撃を受けない
    /// </summary>
    [Header("【デバッグ用】：✔をつけると攻撃を受けない"),SerializeField] bool _debugMode = false;

    [Header("ReSpawn位置：ReSpawnPrefab→Area→［Spawn］をアタッチ"), SerializeField] Transform _reSpawnArea;
    /// <summary>移動先となる位置情報</summary>
    [Space(5),SerializeField] Transform _target = default;
    /// <summary>移動先座標を保存する変数</summary>
    Vector3 _cachedTargetPosition;

    /// <summary>HitPoint</summary>
    [SerializeField] int _hp = 20;
    /// <summary>MagicPoint</summary>
    [SerializeField] int _mp = 20;


    /// <summary>キャラクターなどのアニメーションするオブジェクトを指定する</summary>
    [SerializeField] Animator _anim = default;

    /// <summary> NavMesh Agent コンポーネントを格納する変数</summary>
    NavMeshAgent _agent = default;


    

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _cachedTargetPosition = _target.position; // 初期位置を保存する（※）
        this.transform.position = _reSpawnArea.position;
    }

    /*
     * （※）_cachedTargetPosition を使って座標を保存しているのは、以下の Update() 内で「毎フレーム座標をセットする」という処理を避け、負荷を下げるためである。
     * 毎フレーム座標をセットすることで経路の計算を毎フレームしてしまうことを避けるため、「Target が移動した時のみ」目的地をセットして経路の計算を行わせている。
     */

    void Update()
    {
        // _target が移動したら Navmesh Agent を使って移動させる
        if (Vector3.Distance(_cachedTargetPosition, _target.position) > Mathf.Epsilon) // _target が移動したら
        {
            _cachedTargetPosition = _target.position; // 移動先の座標を保存する
            _agent.SetDestination(_cachedTargetPosition); // Navmesh Agent に目的地をセットする（Vector3 で座標を設定していることに注意。Transform でも GameObject でもなく、Vector3 で目的地を指定する）
        }

        // m_animator がアサインされていたら Animator Controller にパラメーターを設定する
        if (_anim)
        {
            _anim.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("ダメージを受けた");
            _anim.SetTrigger("Damage");
        }
    }
}
