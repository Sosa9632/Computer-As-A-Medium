using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public const int MaxHealth = 100;
    public int health = MaxHealth;
    public TMP_Text healthText;

    private void Start()
    {
        health = Mathf.Clamp(health, 0, MaxHealth);
        PositionHud(healthText, 16f);
        HealthPack.Create(new Vector2(-3.3f, -1.2f));
        HealthPack.Create(new Vector2(-2.0f, -1.2f));
        Update();
    }

    private void Update()
    {
        healthText.text = "Health: " + health;
    }

    public bool Heal(int amount)
    {
        if (health <= 0 || health >= MaxHealth)
            return false;

        health = Mathf.Min(health + amount, MaxHealth);
        return true;
    }

    public static void PositionHud(TMP_Text label, float top)
    {
        RectTransform rect = label.rectTransform;
        rect.anchorMin = rect.anchorMax = rect.pivot = new Vector2(0f, 1f);
        rect.anchoredPosition = new Vector2(16f, -top);
        rect.sizeDelta = new Vector2(220f, 34f);
        label.alignment = TextAlignmentOptions.MidlineLeft;
        label.enableAutoSizing = false;
        label.fontSize = 24f;
    }
}
