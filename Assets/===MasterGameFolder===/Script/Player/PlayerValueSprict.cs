using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerValueSprict : MonoBehaviour,IReceiveDamage,IMPValue
{
    /// <summary>デバッグモードTrueにすると攻撃を受けない </summary>
    [Header("【デバッグ用】：✔をつけると攻撃を受けない"), SerializeField] private bool _debugMode = false;

    /// <summary>キャラクターなどのアニメーションするオブジェクトを指定する</summary>
    [SerializeField] private Animator _anim = default;

    [Header("HP")]
    /// <summary>HitPoint</summary>
    [SerializeField] private int _hp = 20;
    private int _maxHp;
    [SerializeField] private GameObject HPController;
    [SerializeField] private HPController helth;
    [SerializeField] private HPController helth2;
    [Header("MP")]
    /// <summary>MagicPoint</summary>
    [SerializeField] private int _mp = 20;
    private int _maxMp;
    [SerializeField] private HPController mp;
    [SerializeField] private GameObject MPController;


    [Tooltip("リスポーン"),SerializeField] private GameObject _reSpawnButton;
    private SkillReSpawn _reSpawn;

    [Tooltip("ポストプロセッシング"),SerializeField] private GameObject postproseccing;
    [Tooltip("プレイヤー"), SerializeField] private GameObject _player;
    [Header("Canvas→ButtonProcess→DontTouchをアタッチ"), SerializeField] private GameObject _dontTouchSkill;
    /// <summary>攻撃を受けたかの判定</summary>
    private bool _isKnock = false;
    /// <summary>生死判定</summary>
    private bool _isDeath = false;
    private float _timeleft;

    public int Hp
    {
        set
        {
            _hp = Mathf.Clamp(value, 0, _maxHp);
        }
        get
        {
            return _hp;
        }
    }
    public int Mp
    {
        set
        {
            _mp = Mathf.Clamp(value, 0, _maxMp);
        }
        get
        {
            return _mp;
        }
    }
    void Start()
    {
        //animation取得
        _anim = _player.GetComponent<Animator>();

        _maxHp = HPController.GetComponent<HPController>()._maxHp;
        helth = helth.GetComponent<HPController>();
        helth2 = helth2.GetComponent<TextHPSprict>();
        mp = mp.GetComponent<TextHPSprict>();
        _maxMp = MPController.GetComponent<TextHPSprict>()._maxHp;

        _reSpawn = _reSpawnButton.GetComponent<SkillReSpawn>();

    }


    void Update()
    {
        //hp処理
        helth.UpdateSlider(_hp);
        helth2.UpdateSlider(_hp);
        mp.UpdateSlider(_mp);

        if (_hp <= 0)
        {
            Debug.Log("HPが０になった");
            _isDeath = true;

            if (_isDeath == true)
            {
                postproseccing.SetActive(true);
                _dontTouchSkill.SetActive(true);
                StartCoroutine("DeathReSpawn");
            }
        }

        //アニメーション制御
        if (_anim)
        {
            _anim.SetInteger("HP", _hp);
        }

        //1秒ごとにHPとMPが回復する処理
        _timeleft -= Time.deltaTime;
        if (_timeleft <= 0.0 && _isDeath ==false)
        {
            _timeleft = 1.0f;
            _hp += 1;
            _mp += 1;
        }
    }

    /// <summary>
    /// MP消費
    /// </summary>
    /// <param name="minusMp"></param>
    public void MinusMP(int minusMp)
    {
        _mp -= minusMp;
    }

    /// <summary>
    /// ダメージ判定
    /// </summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(int damage)
    {
        Debug.Log(damage + "ダメージ食らった");

        if (_isKnock == false && _debugMode == false)
        {
            //_anim.SetTrigger("Damage");
            _hp -= damage;
            _isKnock = true;
            StartCoroutine("DamageTime");
        }
    }

    private IEnumerator DamageTime()
    {
        yield return new WaitForSeconds(0.5f);
        _isKnock = false;
    }
    private IEnumerator DeathReSpawn()
    {
        yield return new WaitForSeconds(3f);
        _reSpawn.OnReSpawn();
        _hp = _maxHp;
        postproseccing.SetActive(false);
        _dontTouchSkill.SetActive(false);
        _isDeath = false;
    }
}
