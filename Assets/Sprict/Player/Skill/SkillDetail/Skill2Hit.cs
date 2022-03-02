using UnityEngine;
/// <summary>
/// Skill2が与えるダメージ
/// </summary>
public class Skill2Hit : MonoBehaviour
{
    private void Start()
    {
        Destroy(this, 2f);
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
