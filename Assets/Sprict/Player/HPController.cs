using UnityEngine;
using UnityEngine.UI;


public class HPController : MonoBehaviour
{
    /// <summary> Playerの体力 </summary>
    [SerializeField] public float _maxHp = 5f;
    [HideInInspector] public Slider hpSlider;
    
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        //スライダーの最大値の設定
        hpSlider.maxValue = _maxHp;
    }

    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public void UpdateSlider(int hp)
    {
        hpSlider.value = hp;
    }


}
