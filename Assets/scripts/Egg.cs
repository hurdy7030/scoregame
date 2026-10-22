using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameManager Manager;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Basket")
        {
            Manager.AddScore();
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "ground")
        {
            Manager.LoseGame();
            Destroy(gameObject);
        }
    }
}
