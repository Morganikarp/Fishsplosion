using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FishBase : MonoBehaviour
{
    public bool Hit;

    public float time;
    public float duration;
    public float PeakPos;
    public float ValleyPos;
    public bool RisingDir;
    public float IdleDistanceDif;

    public void SetUp()
    {
        Hit = false;
        time = 1;
        duration = Random.Range(1f, 4f);
        PeakPos = transform.position.y + .25f;
        ValleyPos = transform.position.y - .25f;
        RisingDir = true;
        IdleDistanceDif = 0.0001f;
    }

    public void Idle()
    {
        time += Time.deltaTime;
        float t = time / duration;
        t = t * t * (3f - 2f * t);

        switch (RisingDir)
        {
            case true:

                transform.position = new Vector3(transform.position.x, Mathf.Lerp(ValleyPos, PeakPos, t), transform.position.z);

                if ((PeakPos - IdleDistanceDif) < transform.position.y && transform.position.y < (PeakPos + IdleDistanceDif))
                {
                    time = 0;
                    RisingDir = false;
                }

                break;

            case false:

                transform.position = new Vector3(transform.position.x, Mathf.Lerp(PeakPos, ValleyPos, t), transform.position.z);

                if ((ValleyPos - IdleDistanceDif) < transform.position.y && transform.position.y < (ValleyPos + IdleDistanceDif))
                {
                    time = 0;
                    RisingDir = true;
                }

                break;
        }
    }
}
