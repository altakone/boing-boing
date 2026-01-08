using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    public float rotationSpeed = 80f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate 360 degrees around the Y axis continuously
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
