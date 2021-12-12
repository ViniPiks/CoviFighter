using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 70;
    public float rotationSpeed = 10;
    private GameObject shootPoint;
    public GameObject projectile;
    public float delayTimer;
    private float _instantiationTimer;
    private Rigidbody _playerRb;
    
    
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        shootPoint = GameObject.FindGameObjectWithTag("shootPoint");
        _playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveByKeys();
        LookAtMouse();
        Shoot();
    }

    private void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hits);

        position = new Vector3(hits.point.x, hits.point.y, hits.point.z);

        Quaternion newRot = Quaternion.LookRotation(position - transform.position, Vector3.up);
        newRot.x = 0f;
        newRot.z = 0f;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * 5);

    }

    void MoveByKeys()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(Vector3.forward * speed * verInput);
        _playerRb.AddForce(Vector3.right * speed * horInput);
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            _instantiationTimer -= Time.deltaTime;
            if (_instantiationTimer <= 0)
            {
                Instantiate(projectile,shootPoint.transform.position , transform.rotation);
                _instantiationTimer = delayTimer;
            }

        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerUp"))
        {
            Destroy(other.gameObject);
            Debug.Log("POWER UP!!");
        }
    }
}





