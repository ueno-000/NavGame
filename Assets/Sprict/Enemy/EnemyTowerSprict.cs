using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerSprict : MonoBehaviour, IReceiveDamage
{
    [SerializeField,Range(0,100)] int _hp = Mathf.Clamp(100, 0, 100);
    [SerializeField] TextHPSprict helth;

    /// <summary>
    /// 持っているコインと経験値
    /// </summary>
    [Header("持っているコインと経験値"),SerializeField]
    int _hasCoin = 50;
    [SerializeField] int _hasExp = 100;

    /// <summary>
    /// プレイヤーの持っている値を取得等するため
    /// </summary>
    GameObject _player;
    
     private void Start()
    {
        helth = helth.GetComponent<TextHPSprict>();
        _player = GameObject.Find("PlayerValueController");
    }

    void Update()
    {
        helth.UpdateSlider(_hp);

        if(_hp == 0)
        {
            Debug.Log("タワーが消滅しました");

            var _value = _player.GetComponent<IGetValue>();
            //プレイヤーにコインと経験値を送る
            if (_value != null)
            {
                _value.GetCoin(_hasCoin);
                _value.GetEXP(_hasExp);
            }
            Destroy(this.gameObject);
        }
    }
    public void ReceiveDamage(int damage)
    {
        Debug.Log("タワーは " + damage + "ダメージ食らった");
        _hp -= damage;
    }

}
