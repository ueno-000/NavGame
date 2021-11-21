using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUIRotate : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    void LateUpdate()
    {
        //　カメラと同じ向きに設定
        transform.rotation = _mainCamera.transform.rotation;
    }
}
