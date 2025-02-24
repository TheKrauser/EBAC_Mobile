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
        var newPosition = transform.position;
        newPosition.x = Mathf.Clamp(transform.position.x, -6.5f, 6.5f);
        newPosition += Vector3.right * speed * velocity * Time.deltaTime;
        transform.position = newPosition;
    }
}
