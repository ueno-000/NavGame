using UnityEngine;
using HC.Debug;

/// <summary>
/// Skill2 爆発するオブジェクトを投げる
/// </summary>

public class PlayerSkill_2 : OnMouseBace
{
    /// <summary>攻撃範囲 </summary>
    [Header("Player→Skill→[Skill2]をアタッチ"), SerializeField] GameObject _hitArea;
    [Header("Player→Skill→[Skill2]をアタッチ"), SerializeField] SphereCollider _hitAreaCol;
    [SerializeField, Range(0.1f, 2f)] float _hitRange = 0.5f;

    /// <summary>Effectのprefab</summary>
    [SerializeField] GameObject _skillEffect;
    //生成する位置
    [Header("Player"), SerializeField] Transform _playerPosition;

    /// <summary>Mouseのposition </summary>
    Vector3　_mouse;

    /// <summary>buttonが押された時の判定</summary>
    bool _isSkill2ButtonPushed = false; 

    //=====Physics Debuggeの設定=====
    [Header("可視コライダーの色"), Header("Physics Debuggeの設定"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("メッセージ"), SerializeField]
    private string _message;
    [Header("フォントサイズ"), SerializeField]
    private int _fontSize = 1;

    private void Start()
    {
        _hitArea.SetActive(false);
        _hitAreaCol = _hitArea.GetComponent<SphereCollider>();
    }
    void Update()
    {
        //コライダーの大きさをupdateで変える
        _hitAreaCol.radius = _hitRange;

        //ボタンが押されたら
        if (_isSkill2ButtonPushed == true)
        {
            _hitArea.SetActive(true);

            _mouse = Input.mousePosition;
            _mouse.x = Mathf.Clamp(_mouse.x, -Screen.width/2, Screen.width);
            _mouse.y = Mathf.Clamp(_mouse.y, -Screen.height/2, Screen.height);
            
            Ray ray = Camera.main.ScreenPointToRay(_mouse);
            // Ray が当たった時
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // _hitArea がアサインされていたら、それを移動する
                if (_hitArea)
                {
                    _hitArea.transform.position = hit.point;
                }
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(_skillEffect, _hitArea.transform.position, Quaternion.identity);
                Destroy(_hitArea.GetComponent<ColliderVisualizer>());
                _isSkill2ButtonPushed = false;
            }
        }
    }
    public override void OnMouseOver()
    {
        _image[0].SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public override void OnMouseExit()
    {
      //  Destroy(_hitArea.GetComponent<ColliderVisualizer>());
        _image[0].SetActive(false);
    }

    public void OnSkill2()
    {
        //Instantiate(_skillEffect, _position.position, Quaternion.identity);
        _hitArea.AddComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
        _isSkill2ButtonPushed = true;
    }
}
