using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerValueSprict : MonoBehaviour,IReceiveDamage,IMPValue
{
    /// <summary>
    /// デバッグモードTrueにすると攻撃を受けない
    /// </summary>
    [Header("【デバッグ用】：✔をつけると攻撃を受けない"), SerializeField] bool _debugMode = false;

    /// <summary>キャラクターなどのアニメーションするオブジェクトを指定する</summary>
    [SerializeField] Animator _anim = default;

    [Header("各種変動値")]
    /// <summary>HitPoint</summary>
    [SerializeField] int _hp = 20;
     int _maxHp;
    [SerializeField] GameObject HPController;
    [SerializeField] HPController helth;
    [SerializeField] HPController helth2;

    /// <summary>MagicPoint</summary>
    [SerializeField] int _mp = 20; 
    int _maxMp;
    [SerializeField] HPController mp;
    [SerializeField] GameObject MPController;

    [SerializeField] GameObject postproseccing;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _reSpawnButton;
    SkillReSpawn _reSpawn;
    /// <summary>攻撃を受けたかの判定</summary>
    bool _isKnock = false;

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
        helth.UpdateSlider(_hp);
        helth2.UpdateSlider(_hp);
        mp.UpdateSlider(_mp);

        if (_hp == 0)
        {
            Debug.Log("HPが０になった");
            postproseccing.SetActive(true);
            StartCoroutine("DeathReSpawn");
        }

        //アニメーション制御
        if (_anim)
        {
            _anim.SetInteger("HP", _hp);
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

        if (_isKnock == false)
        {
            _anim.SetTrigger("Damage");
            _hp -= damage;
            _isKnock = true;
            StartCoroutine("DamageTime");
        }
    }

    IEnumerator DamageTime()
    {
        yield return new WaitForSeconds(0.5f);
        _isKnock = false;
    }
    IEnumerator DeathReSpawn()
    {
        yield return new WaitForSeconds(3f);
        _reSpawn.OnReSpawn();
        _hp = _maxHp;
        postproseccing.SetActive(false);
    }
}
