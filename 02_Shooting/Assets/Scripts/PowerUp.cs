using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir;
    
    
    // Start is called before the first frame update
    void Start()
    {
      


    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (speed * Time.deltaTime * dir);
    }
}
