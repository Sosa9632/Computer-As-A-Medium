using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private bool consumed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (consumed || !other.CompareTag("Player"))
            return;

        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player == null || !player.Heal(10))
            return;

        consumed = true;
        Destroy(gameObject);
    }

    public static void Create(Vector2 position)
    {
        GameObject pack = new GameObject("Health Pack");
        pack.transform.position = position;
        BoxCollider2D trigger = pack.AddComponent<BoxCollider2D>();
        trigger.isTrigger = true;
        trigger.size = new Vector2(0.6f, 0.6f);
        pack.AddComponent<HealthPack>();

        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();
        SpriteRenderer renderer = pack.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1f / 0.6f);
        renderer.color = Color.green;
        renderer.sortingOrder = 2;
    }
}
