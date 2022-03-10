using UnityEngine;
/// <summary>
/// Skill2が与えるダメージ
/// </summary>
public class Skill2Hit : MonoBehaviour
{
    GameObject _skill;
    PlayerSkill_2 playerSkill_2;

    private void Start()
    {
        _skill = GameObject.Find("Skill2");
        playerSkill_2 = _skill.GetComponent<PlayerSkill_2>();
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // インターフェイスを取得
        var hit = other.gameObject.GetComponent<IReceiveDamage>();
        // 触れた相手がダメージを受ける
        if (hit != null && other.tag != "Player")
        {
            hit.ReceiveDamage(playerSkill_2._damage);
        }
    }
}
