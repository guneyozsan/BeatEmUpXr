using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speedSeconds;
    [SerializeField] private float maxDistance;
    
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        Translate();
        DestroyIfMaxDistance();

        void Translate() =>
            transform.position += Time.deltaTime * speedSeconds * Vector3.forward;

        void DestroyIfMaxDistance()
        {
            Vector3 deltaPosition = transform.position - initialPosition;
        }
    }
}