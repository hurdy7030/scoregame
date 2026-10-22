using UnityEngine;
using UnityEngine.InputSystem;

public class BasketMove : MonoBehaviour
{
    public GameManager Manager;
    public float speed = 7f;
    public float minX = -9f;
    public float maxX = 9f;

    void Update()
    {
        if (!Manager.started || Manager.losing)
            return;

        float direction = 0f;

        if (Keyboard.current.aKey.isPressed)
            direction -= 1f;

        if (Keyboard.current.dKey.isPressed)
            direction += 1f;

        Vector3 position = transform.position;
        position.x += direction * speed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }
}
