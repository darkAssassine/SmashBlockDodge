using UnityEngine;

public class CheckForCollision : MonoBehaviour
{
    public bool isColliding { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
