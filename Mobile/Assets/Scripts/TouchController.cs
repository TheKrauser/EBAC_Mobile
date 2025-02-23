using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private float velocity = 1;

    private Vector2 lastPosition;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - lastPosition.x);
        }

        lastPosition = Input.mousePosition;
    }

    private void Move(float speed)
    {
        transform.position += Vector3.right * speed * velocity * Time.deltaTime;
    }
}
