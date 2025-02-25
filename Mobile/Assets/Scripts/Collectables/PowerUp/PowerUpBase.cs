using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("Power Up")]
    public float duration;
    
    [SerializeField] private GameObject particle;

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
        Invoke(nameof(EndPowerUp), duration);
        var obj = Instantiate(particle, base.Player.transform.position, Quaternion.identity, base.Player.transform);
        Destroy(obj, 3f);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");
    }
}
