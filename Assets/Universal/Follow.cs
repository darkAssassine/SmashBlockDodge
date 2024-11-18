using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform target;
    void Update()
    {
        transform.position = target.position;
    }
}
