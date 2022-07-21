using UnityEngine;
/// <summary>
/// 頭上HPバーを回転しないようにする
/// </summary>
public class HPUIRotate : MonoBehaviour
{
    void LateUpdate()
    {
        //　カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;
    }
}
