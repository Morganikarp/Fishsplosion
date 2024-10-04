using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TroatController : FishBase
{
    void Start()
    {
        SetUp();
    }

    void Update()
    {
        Idle();
    }
    void OnTriggerEnter2D(Collider2D subject)
    {
        switch (subject.tag)
        {
            case ("PistolProjectile"):
                Hit = true;
                Destroy(subject.gameObject);
                Destroy(this.gameObject);
                break;
            case ("ExplosionProjectile"):
                Hit = true;
                Destroy(this.gameObject);
                break;

        }
    }
}
