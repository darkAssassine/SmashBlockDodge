using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;

    //the layer needs to be correct to work
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>()?.TryTakeDamage(damage);
    }
}
