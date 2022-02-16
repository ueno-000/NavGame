using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スキル３
/// </summary>
 public class SkillBomb : OnMouseBace

{
    //爆発の範囲
    [SerializeField] GameObject _hitArea;
    //爆弾のPrefab
    [SerializeField] GameObject _bomb;
    //生成する位置(プレーヤーの手)
    [SerializeField] Transform _hund;

    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    public override void OnMouseOver()
    {
        Debug.Log("爆発範囲ー表示");
        _image[1].SetActive(true);
        _hitArea.SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public override void OnMouseExit()
    {
        Debug.Log("爆発範囲ー非表示");
        _image[1].SetActive(false);
        _hitArea.SetActive(false);
    }
    public void Skill3() => Instantiate(_bomb, this._hund.position, Quaternion.identity);
}
