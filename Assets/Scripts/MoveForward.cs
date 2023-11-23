using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update() => 
        transform.Translate(transform.forward * _speed * Time.deltaTime);
}