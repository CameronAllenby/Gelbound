using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
   public Slider healthbarSlider;

    public void SetMaxHealth(int health)
    {
        healthbarSlider.maxValue = health;
        healthbarSlider.value = health;
    }

    public void SetHealth(int health)
    {
        healthbarSlider.value = health;
    }
}
