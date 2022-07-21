using UnityEngine;
using UnityEngine.UI;
using HC.Debug;


/// <summary>
/// Skill1 Playerから360度範囲に波動が出る
/// </summary>

public class PlayerSkill_1 : OnMouseBace
{
    /// <summary>
    /// 攻撃範囲
    /// </summary>
    [Header("Player→Skill→[Skill1]をアタッチ"),SerializeField] private GameObject _hitArea;
    [Header("Player→Skill→[Skill1]をアタッチ"), SerializeField] private SphereCollider _hitAreaCol;
    [SerializeField, Range(0.1f, 2f)] private float _hitRange = 1f; 
    /// <summary>
    /// Effectのprefab
    /// </summary>
    [SerializeField] private GameObject _skillEffect;
    //生成する位置
    [Tooltip("生成位置"), SerializeField] private Transform _position;

    [SerializeField] private GameObject _player;

    /// <summary>
    /// Damage
    /// </summary>
    [Tooltip("ダメージ"), SerializeField] public int _damage = 10;
    /// <summary>
    /// 消費MP
    /// </summary>
    [Tooltip("消費MP"), SerializeField] public int _minusMP = 10;
    /// <summary>
    /// インターバル
    /// </summary>
    [Tooltip("スキルを使ってからのインターバル"), SerializeField] private float _skillInterval = 10f;
    [SerializeField] private Text _intervelText;


    //=====Physics Debuggeの設定=====
    [Header("可視コライダーの色"), Header("Physics Debuggeの設定"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("メッセージ"),SerializeField]
    private string _message;
    [Header("フォントサイズ"),SerializeField]
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
    }
    public override void OnMouseOver()
    {
        _hitArea.AddComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
        _image[0].SetActive(true);
        _hitArea.SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public override void OnMouseExit()
    {
        Destroy(_hitArea.GetComponent<ColliderVisualizer>());
        _image[0].SetActive(false);
    }

    public void OnSkill1()
    {
        Instantiate(_skillEffect, _position.position, Quaternion.identity);
        var mp = _player.GetComponent<IMPValue>();
        mp.MinusMP(_minusMP);
        _hitArea.SetActive(false);
    }
}
