using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    float spd;
    void Update()
    {
        spd = Random.Range(0.001f, 0.003f);
        transform.position -= new Vector3(1f * spd, 0f, 0f);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
