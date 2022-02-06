using Cinemachine;
using UnityEngine;

/// <summary>
/// CinemachineVirtualCameraのドリー操作（滑らかな変化版）
/// </summary>
public class Camerawheel : MonoBehaviour
{
    //カメラ
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    //ホイール感度
    [SerializeField] private float _sensitivity = 1;

    // 対象との最大値
    [SerializeField] private float _maxDistance = 20;
    // 対象との最小値
    [SerializeField] private float _minDistance = 1;


    // 距離の切り替え時間
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
    }

    // カメラワーク更新
    private void Update()
    {    // マウスホイールの移動取得
        float _scrollDelta = Input.mouseScrollDelta.y;

        if (_framingTransposer == null)
            return;
 
        if (!Mathf.Approximately(_scrollDelta, 3))
        {
            _targetDistance = Mathf.Clamp(
                _targetDistance - _sensitivity * _scrollDelta,
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
