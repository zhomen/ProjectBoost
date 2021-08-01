using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float mainRotate = 100f;
    Rigidbody myRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        } 
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(mainRotate);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-mainRotate);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        myRigidbody.freezeRotation = true; // freezing rotation so we can manually rotate.
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        myRigidbody.freezeRotation = false;
    }
}
