using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public int mana = 100;

    private const int ManaCost = 10;
    private TMP_Text manaText;

    private void Start()
    {
        TMP_Text healthText = GetComponent<PlayerHealth>().healthText;
        manaText = Instantiate(healthText, healthText.transform.parent);
        manaText.name = "ManaText";
        manaText.color = new Color(0.55f, 0.83f, 1f);
        PlayerHealth.PositionHud(manaText, 50f);
        ShowMana();
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        animator.SetBool("attack", keyboard.fKey.isPressed);

        if (keyboard.rKey.wasPressedThisFrame && mana >= ManaCost)
        {
            mana -= ManaCost;
            animator.Play("Base Layer.swordAnim", 0, 0f);
            ShowMana();
        }
    }

    private void ShowMana()
    {
        manaText.text = "Mana: " + mana + "  [R]";
    }
}
