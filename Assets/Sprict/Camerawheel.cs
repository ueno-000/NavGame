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

    private CinemachineFramingTransposer _framingTransposer;

    private float _currentDistance;
    private float _targetDistance;
    private float _currentVelocity;

    // 初期化
    private void Awake()
    {
        // Transposerコンポーネントを取得
        _framingTransposer = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (_framingTransposer == null)
            return;

        double _distance = _framingTransposer.m_CameraDistance;

    }

    // カメラワーク更新
    private void Update()
    {
        if (_framingTransposer == null)
            return;

        // マウスホイールの移動量取得
        var scrollDelta = Input.mouseScrollDelta.y;
 
        if (!Mathf.Approximately(scrollDelta, 3))
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
        _framingTransposer.m_CameraDistance = _targetDistance * _currentDistance / 10;
    }
}
