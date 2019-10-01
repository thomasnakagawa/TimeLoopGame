using System.Collections;
using System.Collections.Generic;
using OatsUtil;
using ObjectTub;
using UnityEngine;

public class TennisBall : PoolableObject
{
    private Rigidbody rb;

    public override void InitializeForUse()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public override void PutAway()
    {
        
    }

    void Awake()
    {
        rb = this.RequireComponent<Rigidbody>();
    }
}
