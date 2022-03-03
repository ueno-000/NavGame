using UnityEngine;
/// <summary>
/// Skill1が与えるダメージ
/// </summary>
public class Skill1Hit : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("何かに触れた");
        // インターフェイスを取得
        var hit = other.gameObject.GetComponent<IReceiveDamage>();
        // 触れた相手がダメージを受ける
        if (hit != null)
        {
            hit.ReceiveDamage(10);
        }
    }
}
