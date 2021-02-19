using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}
