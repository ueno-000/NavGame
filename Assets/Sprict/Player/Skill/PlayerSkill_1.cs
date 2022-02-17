﻿using UnityEngine;
using HC.Debug;

/// <summary>
/// Skill1 Playerから360度範囲に波動が出る
/// </summary>

public class PlayerSkill_1 : OnMouseBace
{
    /// <summary>
    /// 攻撃範囲
    /// </summary>
    [Header("Player→Skill→[Skill1]をアタッチ"),SerializeField] GameObject _hitArea;
    [Header("Player→Skill→[Skill1]をアタッチ"), SerializeField] SphereCollider _hitAreaCol;
    [SerializeField, Range(0.1f, 2f)] float _hitRange = 1f; 
    /// <summary>
    /// Effectのprefab
    /// </summary>
    [SerializeField] GameObject _skillEffect;
    //生成する位置
    [Header("生成位置"), SerializeField] Transform _position;

    //=====Physics Debuggeの設定=====
    [Header("可視コライダーの色"), Header("Physics Debuggeの設定"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("メッセージ"),SerializeField]
    private string _message;
    [Header("フォントサイズ"),SerializeField]
    private int _fontSize = 1;

    private void Start()
    {
        _hitAreaCol = _hitArea.GetComponent<SphereCollider>();
        //_hitArea.AddComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
    }
    void Update()
    {
        //コライダーの大きさをupdateで変える
        _hitAreaCol.radius = _hitRange;
    }
    public override void OnMouseOver()
    {
        _hitArea.AddComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
        _image[1].SetActive(true);
        _hitArea.SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public override void OnMouseExit()
    {
        Destroy(_hitArea.GetComponent<ColliderVisualizer>());
        _image[1].SetActive(false);
        _hitArea.SetActive(false);
    }

    public void OnSkill1() => Instantiate(_skillEffect,_position.position,Quaternion.identity);

}