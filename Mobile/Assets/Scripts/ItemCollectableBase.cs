using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
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

    }
}
