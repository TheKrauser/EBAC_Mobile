using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    private void Awake()
    {

    }

    protected override void OnCollect()
    {
        base.OnCollect();
        Destroy(gameObject);
    }
}
