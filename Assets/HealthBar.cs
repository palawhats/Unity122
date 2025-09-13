using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;      // ลาก Slider จาก Canvas
    public Text valueText;     // (ไม่จำเป็น) แสดงข้อความ "HP 80/100" ถ้าอยากให้มี ให้ลาก Text ลง

    public void SetMaxHealth(float max)
    {
        if (slider != null)
        {
            slider.maxValue = max;
            slider.value = max;
        }
        UpdateText(max, max);
    }

    public void SetHealth(float current)
    {
        if (slider != null)
        {
            slider.value = current;
        }
        UpdateText(current, slider != null ? slider.maxValue : current);
    }

    private void UpdateText(float current, float max)
    {
        if (valueText != null)
        {
            valueText.text = Mathf.CeilToInt(current).ToString() + " / " + Mathf.CeilToInt(max).ToString();
        }
    }
}
