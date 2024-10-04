using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferController : FishBase
{
    void Start()
    {
        SetUp();
    }

    void Update()
    {
        Idle();
    }
}
