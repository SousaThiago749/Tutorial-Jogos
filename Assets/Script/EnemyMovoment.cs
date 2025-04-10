using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float speedIncreasePerSecond = 0.1f;
    public float speedIncreaseOnCollect = 0.5f;

    private Transform player;
    private UIManager uiManager;
    private float elapsedTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        speed += speedIncreasePerSecond * Time.deltaTime;

        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Inimigo tocou no jogador!");
            if (uiManager != null)
            {
                uiManager.ShowGameOverFromEnemy();
            }
        }
        else if (other.CompareTag("Coletavel"))
        {
            // Opcional: aumenta velocidade se encostar em coletável (pouco comum)
            speed += speedIncreaseOnCollect;
        }
    }

    public void BoostSpeedOnCollect()
    {
        speed += speedIncreaseOnCollect;
    }
}
