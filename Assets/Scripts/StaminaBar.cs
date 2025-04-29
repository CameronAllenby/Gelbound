using UnityEngine;
using UnityEngine.UI;
public class Staminabar : MonoBehaviour
{
    public Slider staminaBarSlider;

    public void SetMaxStamina(int stamina)
    {
        staminaBarSlider.maxValue = stamina;
        staminaBarSlider.value = stamina;
    }

    public void SetStamina(int stamina)
    {
        staminaBarSlider.value = stamina;
    }
}
