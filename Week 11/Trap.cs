using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private GameObject popup;
    private Coroutine hidePopup;

    private void Start()
    {
        SpriteRenderer trapSprite = GetComponent<SpriteRenderer>();
        popup = new GameObject("Trap Popup");
        popup.transform.SetParent(transform, false);
        popup.transform.position = transform.position + Vector3.up * 1.1f;
        popup.transform.localScale = new Vector3(1.8f, 0.8f, 1f);

        SpriteRenderer popupSprite = popup.AddComponent<SpriteRenderer>();
        Texture2D square = new Texture2D(1, 1);
        square.SetPixel(0, 0, Color.white);
        square.Apply();
        popupSprite.sprite = Sprite.Create(square, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1);
        popupSprite.color = Color.yellow;
        popupSprite.sortingOrder = trapSprite.sortingOrder + 1;
        popup.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerHealth.health -= 10;
        popup.SetActive(true);
        if (hidePopup != null)
            StopCoroutine(hidePopup);
        hidePopup = StartCoroutine(HidePopup());
    }

    private IEnumerator HidePopup()
    {
        yield return new WaitForSeconds(1f);
        popup.SetActive(false);
        hidePopup = null;
    }
}
