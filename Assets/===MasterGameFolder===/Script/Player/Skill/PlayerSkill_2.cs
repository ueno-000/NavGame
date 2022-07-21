using UnityEngine;
using System.Linq;
using HC.Debug;

/// <summary>
/// Skill2 爆発するオブジェクトを投げる
/// </summary>

public class PlayerSkill_2 : OnMouseBace
{ 
    /// <summary>攻撃範囲 </summary>
    [Header("Player→Skill→[Skill2]をアタッチ"), SerializeField] private GameObject _hitArea;
    [Header("Player→Skill→[Skill2]をアタッチ"), SerializeField] private SphereCollider _hitAreaCol;
    [SerializeField, Range(0.1f, 2f)] private float _hitRange = 0.5f;

    /// <summary>Effectのprefab</summary>
    [SerializeField] private GameObject _skillEffect;
    //生成する位置
    Vector3 _position;

    [SerializeField] private GameObject _hitRangeArea;
    [SerializeField] private Collider _collider;

    [Tooltip("Player"), SerializeField] private GameObject _player;

    /// <summary>Mouse</summary>
    private Vector3 _mouse;
    [Tooltip("マウスのテクスチャを変える"),SerializeField] private Texture2D cursorTexture;

    /// <summary>buttonが押された時の判定</summary>
    private bool _isSkill2ButtonPushed = false;

    /// <summary>
    /// Damage
    /// </summary>
    [Tooltip("ダメージ"), SerializeField] public int _damage = 10;
    /// <summary>
    /// 消費MP
    /// </summary>
    [Tooltip("消費MP"), SerializeField] public int _minusMP = 10;

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

        HitSkill();
    }

    /// <summary>
    /// スキルの処理
    /// </summary>
    private void HitSkill()
    {
        //ボタンが押されたら
        if (_isSkill2ButtonPushed == true)
        {
            //cursorを変更
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
            //ヒットエリアを可視化する
            _hitArea.SetActive(true);
            _hitRangeArea.SetActive(true);

            _mouse = Input.mousePosition;

            // スクリーン座標をワールド座標に変換する
            _position = Camera.main.ScreenToWorldPoint(_mouse);


            Ray ray = Camera.main.ScreenPointToRay(_mouse);

            // Ray が当たった時
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // _hitArea がアサインされていたら、それを移動する
                if (_hitArea && Physics.OverlapSphere(hit.point, 0).Any(col => col == _collider))
                {
                    _hitArea.transform.position = hit.point;
                }
            }

            //右クリックされた時スキルをキャンセルする
            if (Input.GetButtonDown("Fire2"))
            {
                //マウスカーソルを戻す
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                //hitArea可視化解除
                _hitRangeArea.SetActive(false);
                Destroy(_hitArea.GetComponent<ColliderVisualizer>());
                _isSkill2ButtonPushed = false;
            }
            //左クリックでエフェクトとダメージ判定をする
            if (Input.GetButtonDown("Fire1"))
            {
                //マウスカーソルを戻す
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                //生成する
                Instantiate(_skillEffect, _hitArea.transform.position, Quaternion.identity);
                //MP消費処理
                var mp = _player.GetComponent<IMPValue>();
                mp.MinusMP(_minusMP);
                //hitArea可視化解除
                _hitRangeArea.SetActive(false);
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
        _hitArea.AddComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
        _isSkill2ButtonPushed = true;
    }
}
