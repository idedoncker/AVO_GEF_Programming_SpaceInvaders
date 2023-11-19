using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    void Update()
    {
        Vector2 newDirection = Vector2.up * moveSpeed * Time.deltaTime;
        transform.Translate(newDirection);
    }
}
