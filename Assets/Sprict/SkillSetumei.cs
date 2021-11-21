using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSetumei : MonoBehaviour
{
    [SerializeField] Image Setumei;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    void OnMouseOver()
    {
        Debug.Log("MouseOver!");
        Setumei.gameObject.SetActive(true);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    void OnMouseExit()
    {
        Debug.Log("MouseExit!");
        Setumei.gameObject.SetActive(false);
    }
}
