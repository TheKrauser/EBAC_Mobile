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
    [SerializeField] private GameObject particleDeath;

    private Vector3 pos;
    private bool isRunning;
    private bool isInvincible = false;
    private bool isDead = false;
    private float currentSpeed;
    private Vector3 startPosition;

    private Animator anim;
    public BounceHelper bounce;
    public ScaleHelper scale;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        bounce = GetComponentInChildren<BounceHelper>();
        scale = GetComponentInChildren<ScaleHelper>();
        startPosition = transform.position;
        ResetSpeed();
    }

    private void Update()
    {
        if (isDead) return;

        anim.SetBool("isRunning", isRunning);

        if (!isRunning)
            return;
        else
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            if (isInvincible) return;

            isRunning = false;
            isDead = true;
            var obj = Instantiate(particleDeath, transform.position, Quaternion.identity);
            Destroy(obj, 3f);
            scale.ScaleOut();
            anim.SetBool("isDead", isDead);
            ui.ShowEndScreen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(endLineTag))
        {
            isRunning = false;
            ui.ShowEndScreen();
        }
    }

    public void ToggleCanRun()
    {
        isRunning = !isRunning;
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

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
