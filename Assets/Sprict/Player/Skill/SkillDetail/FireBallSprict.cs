using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSprict : MonoBehaviour
{
    Rigidbody _rb;
    GameObject _skill3;
    PlayerSkill_3 _playerSkill_3;
    Vector3 _diretion;

    private void Awake()
    {
        _skill3 = GameObject.Find("Set_Skill3");
         _playerSkill_3 = GameObject.Find("Skill2").GetComponent<PlayerSkill_3>();
    }
    void Start()
    {
        Destroy(this.gameObject,3);
    }
 
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _playerSkill_3._speed;
    }   
}


