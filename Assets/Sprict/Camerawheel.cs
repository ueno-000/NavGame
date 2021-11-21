using Cinemachine;
using UnityEngine;

/// <summary>
/// CinemachineVirtualCameraのドリー操作（滑らかな変化版）
/// </summary>
public class Camerawheel : MonoBehaviour
{
    // バーチャルカメラ
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    // マウスホイールの操作感度
    [SerializeField] private float _sensitivity = 1;

    // 対象物との最小距離
    [SerializeField] private float _minDistance = 1;

    // 対象物との最大距離
    [SerializeField] private float _maxDistance = 20;

    // 距離が切り替わるまでのおおよその時間
    [SerializeField] private float _smoothTime = 1;

    private CinemachineTransposer _transposer;
    private Vector3 _direction;

    private float _currentDistance;
    private float _targetDistance;
    private float _currentVelocity;

    // 初期化
    private void Awake()
    {
        // Transposerコンポーネントを取得
        _transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        if (_transposer == null)
            return;

        // オフセットの方向保持
        // （この方向に沿ってオフセットを移動させる）
        var offset = _transposer.m_FollowOffset;
        _direction = offset.normalized;
        _currentDistance = _targetDistance = offset.magnitude;
    }

    // カメラワーク更新
    private void Update()
    {
        if (_transposer == null)
            return;

        // マウスホイールの移動量取得
        var scrollDelta = Input.mouseScrollDelta.y;
        if (!Mathf.Approximately(scrollDelta, 0))
        {
            _targetDistance = Mathf.Clamp(
                _targetDistance - _sensitivity * scrollDelta,
                _minDistance,
                _maxDistance
            );
        }

        // 滑らかに変化する距離の計算
        _currentDistance = Mathf.SmoothDamp(
            _currentDistance,
            _targetDistance,
            ref _currentVelocity,
            _smoothTime
        );

        // 向きと距離をもとに、次のオフセット計算・反映
        _transposer.m_FollowOffset = _direction * _currentDistance;
    }
}
