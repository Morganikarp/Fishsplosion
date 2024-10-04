using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{

    public GameObject Fish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newFish = Instantiate(Fish);
            newFish.transform.position = new(Random.Range(-2.7f, 7.4f), Random.Range(-4.1f, 0.7f), 0f);

            if (Random.Range(0, 2) > .5f)
            {
                newFish.transform.localScale = Vector3.one;
            }

            else
            {
                newFish.transform.localScale = new(-1, 1, 1); ;
            }
        }
    }
}
