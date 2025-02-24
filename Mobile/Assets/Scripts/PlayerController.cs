using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private float speed = 1f;

    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private string endLineTag = "EndLine";

    [SerializeField] private UIGameplay ui;
    [SerializeField] private TMP_Text uiTextPowerUp;

    [SerializeField] private GameObject coinCollector;

    private Vector3 pos;
    private bool canRun;
    private bool isInvincible = false;
    private float currentSpeed;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        ResetSpeed();
    }

    private void Update()
    {
        if (!canRun) return;
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            if (isInvincible) return;

            canRun = false;
            ui.ShowEndScreen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(endLineTag))
        {
            canRun = false;
            ui.ShowEndScreen();
        }
    }

    public void ToggleCanRun()
    {
        canRun = !canRun;
    }

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        currentSpeed = f;
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }

    public void SetInvincible(bool b = true)
    {
        isInvincible = b;
    }

    public void ChangeHeight(float amount, float animationDuration)
    {
        var p = transform.position; p.y = startPosition.y + amount;
        transform.position = p;
    }

    public void ResetHeight()
    {
        var p = transform.position;
        p.y = startPosition.y;
        transform.position = p;
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
}
