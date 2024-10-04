using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4Controller : MonoBehaviour
{
    public float Force = 10f;
    public Vector3 DirectionVector;
    Rigidbody2D RB2D;

    public GameObject ExplosionPrefab;
    GameObject Explo;
    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        RB2D.velocity = DirectionVector * Force;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RB2D.simulated = false;
            Explo = Instantiate(ExplosionPrefab);
            Explo.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
