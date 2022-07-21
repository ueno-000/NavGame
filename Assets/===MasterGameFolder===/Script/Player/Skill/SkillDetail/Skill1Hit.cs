using UnityEngine;
/// <summary>
/// Skill1が与えるダメージ
/// </summary>
public class Skill1Hit : MonoBehaviour
{
    private GameObject _skill;
    private PlayerSkill_1 playerSkill_1;

    private void Start()
    {
        _skill = GameObject.Find("Skill1");
        playerSkill_1 = _skill.GetComponent<PlayerSkill_1>();
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // インターフェイスを取得
        var hit = other.gameObject.GetComponent<IReceiveDamage>();
        //Debug.Log(hit);
        // 触れた相手がダメージを受ける
        if (hit != null && other.tag != "Player")
        {
            hit.ReceiveDamage(playerSkill_1._damage);
        }
    }
}
