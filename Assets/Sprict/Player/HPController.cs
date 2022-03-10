using UnityEngine;
using UnityEngine.UI;


public class HPController : MonoBehaviour
{
    /// <summary> 体力 </summary>
    [SerializeField] public int _maxHp = 5;
    [SerializeField] public int _minHp = 0;

    [HideInInspector] public Slider hpSlider;
    
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        //スライダーの最大値の設定
        hpSlider.maxValue = _maxHp;
    }

    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public virtual void UpdateSlider(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);
        hpSlider.value = hp;
    }


}
