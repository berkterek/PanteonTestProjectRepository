using UnityEngine;

public class Rotator : IRotator
{
    Transform _transform;
    float _turnSpeed;

    public Rotator(Transform transform,float turnSpeed)
    {
        _transform = transform;
        _turnSpeed = turnSpeed;
    }

    public void Tick(float mouseX)
    {
        _transform.Rotate(Vector3.up * _turnSpeed * Time.deltaTime * mouseX);
    }
}
