using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{

    public GameObject[] clouds;
    bool spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            spawn = false;
            GameObject c = Instantiate(clouds[Random.Range(0, clouds.Length)]);
            c.transform.position = new(11, Random.Range(2.2f, 4.2f), 0f);
            StartCoroutine("SpawnTimer");
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        spawn = true;
    }
}
