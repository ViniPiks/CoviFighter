using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody enemyRb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        enemyRb =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 attackVec = _player.transform.position - transform.position;
        enemyRb.AddForce(attackVec.normalized * speed, ForceMode.Impulse);
        if (transform.position.y< -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        
    }
    
}
