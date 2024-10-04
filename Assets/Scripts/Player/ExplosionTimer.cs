using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ExplosionTime");
    }

    IEnumerator ExplosionTime()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
