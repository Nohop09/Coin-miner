using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public float respawnTime = 5f; // через сколько секунд монета появится снова

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Монета собрана!");

            // Прячем монету
            gameObject.SetActive(false);

            // Запускаем повторное появление
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    private void Respawn()
    {
        // Получаем границы камеры
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // Случайная позиция внутри границ камеры
        float x = Random.Range(cam.transform.position.x - camWidth / 2f, cam.transform.position.x + camWidth / 2f);
        float y = Random.Range(cam.transform.position.y - camHeight / 2f, cam.transform.position.y + camHeight / 2f);

        transform.position = new Vector3(x, y, 0);
        gameObject.SetActive(true);
    }
}
