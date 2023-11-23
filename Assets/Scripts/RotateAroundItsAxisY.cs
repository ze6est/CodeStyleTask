using UnityEngine;

public class RotateAroundItsAxisY : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update() => 
        transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0);
}
