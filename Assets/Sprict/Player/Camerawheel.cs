using Cinemachine;
using UnityEngine;

/// <summary>
/// CinemachineVirtualCameraのドリー操作（滑らかな変化版）
/// </summary>
public class Camerawheel : MonoBehaviour
{

    //カメラ
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] GameObject _camera;
     bool _isMainCamera = false;
    [SerializeField] GameObject _spriteCameraOff;
    /// <summary>
    /// ホイール感度
    /// </summary>
    [SerializeField] private float _sensitivity = 1;

    // 対象との最大値
    [SerializeField] private float _maxDistance = 20;
    // 対象との最小値
    [SerializeField] private float _minDistance = 1;


    /// <summary>
    /// 距離の切り替え時間
    /// </summary>
    [SerializeField] private float _smoothTime = 1;

    private CinemachineFramingTransposer _framingTransposer;

    /// <summary>
    /// 現在値
    /// </summary>
    private float _currentDistance;
    /// <summary>
    /// 目標値
    /// </summary>
    private float _targetDistance;
    /// <summary>
    /// 現在速度を格納する変数
    /// </summary>
    private float _currentVelocity;


    private void Awake()
    {
     // Transposerコンポーネントを取得
     _framingTransposer = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (_framingTransposer == null)
            return;

     _framingTransposer.m_CameraDistance = 4;

    }

    // カメラワーク更新
    private void Update()
    {
        // マウスホイールの移動取得
        float _scrollDelta = Input.mouseScrollDelta.y;

        if (_framingTransposer == null)
            return;

        //Debug.Log(_framingTransposer.m_CameraDistance);

        //スクロールの値が３と近似していない場合
        if (!Mathf.Approximately(_scrollDelta, 3))
        {
            //targetDistance(目標値)はminとmaxの範囲内に収めた値にする
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

    public void OnswitchingCamera()
    {
        //virtualカメラがtrueの時virtualカメラをfalseにする
        if (_isMainCamera == false)
        {
            _camera.SetActive(false);
            _spriteCameraOff.SetActive(true);
            _isMainCamera = true;
        }
        else
        {
            _camera.SetActive(true);
            _spriteCameraOff.SetActive(false);
            _isMainCamera = false;
        }
    }
}
