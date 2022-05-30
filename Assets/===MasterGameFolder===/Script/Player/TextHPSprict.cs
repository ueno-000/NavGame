using UnityEngine;
using UnityEngine.UI;
public class TextHPSprict :HPController
{
    [SerializeField] Text _hpText;


    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public override void UpdateSlider(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);
        hpSlider.value = hp;
        _hpText.text = hp.ToString();
    }
}
