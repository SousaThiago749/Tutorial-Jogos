using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    AudioSource audio;

    public GameObject endPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        GameController.Init(); // garante que a contagem comece certa
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            Destroy(other.gameObject);
            GameController.CollectableCollected();
            audio.Play();

            EnemyMovement enemy = FindObjectOfType<EnemyMovement>();
            if (enemy != null)
            {
                enemy.BoostSpeedOnCollect();
            }

            if (GameController.IsGameOver && endPanel != null)
            {
                endPanel.SetActive(true);
            }
        }
    }
}
