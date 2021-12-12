using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float range = 100;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed*Time.deltaTime);
        OutOfRange();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    void OutOfRange()
    {
        float PosX =  transform.position.x;
        float PosZ = transform.position.z;

        if ((PosX > range) || (PosX < -range)|| (PosZ > range)|| (PosZ < -range))
        {
            Destroy(gameObject);
        }
    }
}
