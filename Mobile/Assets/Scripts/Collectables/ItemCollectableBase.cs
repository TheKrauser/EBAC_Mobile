using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [SerializeField] private GameObject visuals;
    [SerializeField] private Collider coll;
    [SerializeField] private string compareTag = "Player";
    [SerializeField] private bool bouncePlayer = false;

    private Collider player;
    public Collider Player { get { return player; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(compareTag))
        {
            player = other;
            Collect();

            if (bouncePlayer)
            {
                PlayerController.Instance.bounce.Bounce();
            }
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        visuals.gameObject.SetActive(false);
        coll.enabled = false;
    }

    public void ToggleCollider(bool b = false)
    {
        coll.enabled = b;
    }
}
