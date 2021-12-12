using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    GameObject player;
    public Vector3 plPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        plPos = player.transform.position;
        transform.position = plPos + new Vector3(0f, 45f, -20f);
    }
}
