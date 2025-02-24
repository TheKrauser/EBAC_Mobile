using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [SerializeField] private GameObject visuals;
    [SerializeField] private Collider coll;
    [SerializeField] private string compareTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(compareTag))
        {
            Collect();
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
