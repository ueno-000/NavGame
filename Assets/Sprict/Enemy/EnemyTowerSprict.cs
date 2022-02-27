using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerSprict : MonoBehaviour
{
    [SerializeField,Range(0,100)] int _hp = Mathf.Clamp(100, 0, 100); 

    // Update is called once per frame
    void Update()
    {
        if(_hp == 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
