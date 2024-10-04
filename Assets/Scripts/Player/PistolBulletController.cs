using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletController : MonoBehaviour
{

    public Vector3 DirectionVector;

    void Update()
    {
        transform.position += DirectionVector * .1f;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
