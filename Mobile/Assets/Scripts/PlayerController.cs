using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private string endLineTag = "EndLine";

    [SerializeField] private UIGameplay ui;

    private Vector3 pos;
    private bool canRun;

    private void Start()
    {
        canRun = false;
    }

    private void Update()
    {
        if (!canRun) return;
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            canRun = false;
            ui.ShowEndScreen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(endLineTag))
        {
            ui.ShowEndScreen();
        }
    }

    public void ToggleCanRun()
    {
        canRun = !canRun;
    }
}
