using UnityEngine;

/// <summary>
/// リスポーンの処理
/// </summary>
public class SkillReSpawn : OnMouseBace
{
    /// <summary>
    /// Respawnボタンが押されたかの判定
    /// </summary>

    [SerializeField]public bool isReSpawn = false;
    

    public void OnReSpawn()
    {
        isReSpawn = true;
    }
}
