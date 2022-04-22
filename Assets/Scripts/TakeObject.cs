using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : Interactable
{
    public int Amount;
    public override void Use()
    {
        base.Use();
        PlayerShooting.amountOfProjectiles+=Amount;
        Debug.Log("Added " + Amount);
        Destroy(gameObject);
    }
}
