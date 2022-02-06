using UnityEngine;

/// <summary>
/// スキル2
/// </summary>
public class SkillFire :SkillBace
{
    /// <summary>火玉プレハブ</summary>
    [SerializeField] GameObject _fireBall;
    /// <summary>火球が飛ぶ速さ</summary>
    public float _speed = 3f;
    /// <summary>火球の生存期間（秒）</summary>
    public  float _lifeTime = 5f;
    //生成する位置(プレーヤーの手)
    [SerializeField] Transform _hand;

    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    public override void OnMouseOver()
    {
        Debug.Log("MouseOver!");
        _setumeiImage.SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public override void OnMouseExit()
    {
        Debug.Log("MouseExit!");
        _setumeiImage.SetActive(false);
    }

    public void Skill2() => Instantiate(_fireBall,_hand.position ,Quaternion.identity);

}