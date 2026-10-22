using UnityEngine;

public class HenSpawner : MonoBehaviour
{
    public GameManager Manager;
    public GameObject[] eggPrefabs;
    public float speed = 3f;

    public float left = -9f;
    public float right = 8.39f;
    bool movingRight = true;

    public float minInterval = 1f;
    public float maxInterval = 3f;

    float timer;
    float nextInterval;

    void Start()
    {
        nextInterval = Random.Range(minInterval, maxInterval);
    }

    void Update()
    {
        if (!Manager.started || Manager.losing)
            return;

        Vector3 scale = transform.localScale;
        float targetX;

        if (movingRight)
        {
            scale.x = -Mathf.Abs(scale.x);
            targetX = right;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
            targetX = left;
        }

        transform.localScale = scale;

        Vector3 target = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            movingRight = !movingRight;
        }

        timer += Time.deltaTime;

        if (timer >= nextInterval)
        {
            timer = 0f;

            Vector3 spawnPos = transform.position + Vector3.down * 0.6f;

            int index = Random.Range(0, eggPrefabs.Length);

            GameObject newEgg = Instantiate(eggPrefabs[index], spawnPos, Quaternion.identity);

            newEgg.GetComponent<Egg>().Manager = Manager;

            nextInterval = Random.Range(minInterval, maxInterval);
        }
    }
}
