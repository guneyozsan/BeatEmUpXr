using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speedSeconds;
    
    private void Update()
    {
        transform.position += Time.deltaTime * speedSeconds * Vector3.forward;
    }
}