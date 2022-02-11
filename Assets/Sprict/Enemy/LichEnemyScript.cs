using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichEnemyScript : EnemySprictBace
{
    EnemyPatrol EnemyPatrol;
    private void Start()
    {
        
    }
    //CollisionEnemyスクリプトのOnTrrigerStayにセットし、衝突判定を受け取るメソッド。
    public void OnDetectObject(Collider collider)
    {
        //検知したオブジェクトにPlayerタグがついていた時の処理。
        if (collider.CompareTag("Player"))
        {
            //Playerのコライダーの位置を取得して追いかけます。
            _agent.destination = collider.transform.position;
        }
    }
}
