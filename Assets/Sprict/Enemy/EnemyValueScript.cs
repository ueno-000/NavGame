using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyValueScript : MonoBehaviour, IReceiveDamage
{
    [SerializeField, Range(0, 100)] int _hp = Mathf.Clamp(100, 0, 100);
    [SerializeField] int _maxHp;
    [SerializeField] HPController helth;
    /// <summary>
    /// 持っているコインと経験値
    /// </summary>
    [Header("持っているコインと経験値"), SerializeField]
    int _hasCoin = 50;
    [SerializeField] int _hasExp = 100;

    /// <summary>攻撃を受けたかの判定</summary>
    bool _isKnock = false;


    //enemyの点滅で使う
    [Header("Lichのマテリアルがついているゲームオブジェクトを格納"), SerializeField] GameObject _skinObject;
    SkinnedMeshRenderer _renderer;

    /// <summary>
    /// プレイヤーの持っている値を取得等するため
    /// </summary>
    GameObject _player;
    /// <summary>
    /// Gamemanager
    /// </summary>
    GameObject gameManager;
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

    private void Start()
    {
        helth = helth.GetComponent<HPController>();
        _player = GameObject.Find("PlayerValueController");
        gameManager = GameObject.Find("GameManager");
        //点滅処理の為に呼び出しておく
        _renderer = _skinObject.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        helth.UpdateSlider(_hp);

        if (_hp == 0)
        {
            Debug.Log("リッチを倒した");

            var _value = _player.GetComponent<IGetValue>();
            var _death = gameManager.GetComponent<IDeathCount>();

            //プレイヤーにコインと経験値を送る
            if (_value != null)
            {
                _value.GetCoin(_hasCoin);
                _value.GetEXP(_hasExp);
                _death.CountDeath(1);
            }
            Destroy(transform.parent.gameObject);
        }
    }
    public void ReceiveDamage(int damage)
    {
        Debug.Log("リッチは " + damage + "ダメージ食らった");

        if (_isKnock == false)
        {
            _hp -= damage;
            _isKnock = true;
            StartCoroutine("DamageTime");
        }
    }
    IEnumerator DamageTime()
    {
        yield return new WaitForSeconds(1f);
        _isKnock = false;
    }
}
