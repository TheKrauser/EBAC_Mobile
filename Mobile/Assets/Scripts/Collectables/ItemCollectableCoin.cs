using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    [SerializeField] private GameObject particle;

    protected override void OnCollect()
    {
        base.ToggleCollider(false);
        collect = true;
    }

    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.GetPosition(), lerp * Time.deltaTime);
            if (Vector3.Distance(transform.position, PlayerController.Instance.GetPosition()) < minDistance)
            {
                base.OnCollect();
                collect = false;
                var obj = Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(obj, 3f);
            }
        }
    }
}
