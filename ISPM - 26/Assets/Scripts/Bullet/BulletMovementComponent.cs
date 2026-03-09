using System;
using UnityEngine;

public class BulletMovementComponent : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
