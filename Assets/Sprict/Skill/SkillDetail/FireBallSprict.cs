using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSprict : MonoBehaviour
{
    Rigidbody _rb;
    SkillFire skillfire;
    GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody>();
         skillfire = GameObject.Find("Skill2").GetComponent<SkillFire>();
    }
    void Start()
    {

        Vector3 vector3 = _player.transform.forward.normalized * skillfire._speed;
        _rb.velocity = vector3;

        Destroy(this.gameObject,skillfire._lifeTime);
    }

}
