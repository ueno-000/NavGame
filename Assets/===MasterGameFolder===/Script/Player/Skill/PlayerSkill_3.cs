﻿using UnityEngine;

/// <summary>
/// Skill3 光弾を3秒間飛ばす
/// </summary>
public class PlayerSkill_3 : OnMouseBace
{

    /// <summary>発射する向き</summary>
    [Header("Player→Skill→[Skill3]をアタッチ"), SerializeField] public GameObject _hitDirection;

    [Header("Prefub→Skill→[SkillEffect3]をアタッチ"), SerializeField] private GameObject _lightBullet;

    //生成する位置
    [Tooltip("Player"), SerializeField] public Transform _playerPosition;

    /// <summary>光弾のスピード</summary>
    [Tooltip("スピード"), SerializeField] public float _speed = 5f;

    /// <summary>
    /// Damage
    /// </summary>
    [Tooltip("ダメージ"), SerializeField] public int _damage = 10;
    /// <summary>
    /// 消費MP
    /// </summary>
    [Tooltip("消費MP"), SerializeField] public int _minusMP = 10;

    /// <summary>Mouseのposition </summary>
    private Vector3 _mouse;

    /// <summary>buttonが押された時の判定</summary>
    private bool _isSkill2ButtonPushed = false;

    private void Start()
    {
        _hitDirection.SetActive(false);
    }
    void Update()
    {
        HitSkill();
    }

    private void HitSkill()
    {
        //ボタンが押されたら
        if (_isSkill2ButtonPushed == true)
        {
            _hitDirection.SetActive(true);

            _mouse = Input.mousePosition;
            _mouse.x = Mathf.Clamp(_mouse.x, -Screen.width / 2, Screen.width);
            _mouse.y = Mathf.Clamp(_mouse.y, -Screen.height / 2, Screen.height);

            Ray ray = Camera.main.ScreenPointToRay(_mouse);
            // Ray が当たった時
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // _hitdirection がアサインされていたら、それを移動する
                if (_hitDirection)
                {
                    _hitDirection.transform.position = hit.point;
                }
            }
            Vector3 Vector3Test = _hitDirection.transform.position - _playerPosition.transform.position;
            Quaternion quaternion = Quaternion.identity;
            quaternion = Quaternion.Euler(Vector3Test);
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(_lightBullet, _playerPosition.position, quaternion);
                _hitDirection.SetActive(false);
                _isSkill2ButtonPushed = false;
            }
        }
    }

    public override void OnMouseOver()
    {
        _image[0].SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public override void OnMouseExit()
    {
        //  Destroy(_hitArea.GetComponent<ColliderVisualizer>());
        _image[0].SetActive(false);
    }

    public void OnSkill3()
    {
        _isSkill2ButtonPushed = true;
    }
}
