using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSprict : MonoBehaviour
{
    /// <summary>
    /// 爆弾が爆発する処理のスプリクト
    /// </summary>
    [SerializeField] float _enemyDistance = 20f;

    void Start()
    {
        StartCoroutine("Explode");
    }
    void Update()
    {
        // 5秒後に自分を削除
        Destroy(this.gameObject,4f);
    }
    //IEnumerator  Explode()
    //{
    //    GameObject[] _enemys = GameObject.FindGameObjectsWithTag("Enemy"); // 敵を探す

    //    Vector3 center = transform.position; // グレネードの位置

    //    // 敵がいれば
    //    if (_enemys.Length != 0)
    //    {
    //        yield return new WaitForSeconds(3.5f);

    //        foreach (GameObject e in _enemys)
    //        {
    //            EnemyPatrol _enemy = e.GetComponent<EnemyPatrol>();

    //            if (_enemy)
    //            {
    //                // 敵との距離
    //                float _distance = Vector3.Distance(e.transform.position, center);
    //                if (_distance <= _enemyDistance)
    //                {
    //                    _enemy.Explode(center, 1f - _distance * 0.05f);

    //                }
    //            }
    //        }
    //    }
    //}
}
