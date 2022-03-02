using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerSprict : MonoBehaviour, IReceiveDamage
{
    [SerializeField,Range(0,100)] int _hp = Mathf.Clamp(100, 0, 100);
    [SerializeField] TextHPSprict helth;

    private void Start()
    {
        helth = helth.GetComponent<TextHPSprict>();
    }
    // Update is called once per frame
    void Update()
    {
        helth.UpdateSlider(_hp);

        if(_hp == 0)
        {
            Debug.Log("タワーが消滅しました");
            Destroy(this.gameObject);
        }
    }
    public void ReceiveDamage(int damage)
    {
        Debug.Log("タワーは " + damage + "ダメージ食らった");
        _hp -= damage;
    }

}
