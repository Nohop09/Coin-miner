using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public float respawnTime = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            GameManager.Instance.AddCoins(value);


            gameObject.SetActive(false);

            Invoke(nameof(Respawn), respawnTime);
        }
    }

    private void Respawn()
    {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float x = Random.Range(cam.transform.position.x - camWidth / 2f, cam.transform.position.x + camWidth / 2f);
        float y = Random.Range(cam.transform.position.y - camHeight / 2f, cam.transform.position.y + camHeight / 2f);

        transform.position = new Vector3(x, y, 0);
        gameObject.SetActive(true);
    }
}
