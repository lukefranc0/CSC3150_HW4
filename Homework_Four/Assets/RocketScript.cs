using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource; 
    public AudioClip thrustSound; 
    Rigidbody rigidbody;
    [SerializeField] float rocketThrust = 1000f;
    [SerializeField] float rocketRotation = 25f;

    void Start()
    {
        // Assign the Rigidbody component
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
       if( Input.GetKey(KeyCode.W))
       {
        if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrustSound);
            }
            rigidbody.AddRelativeForce(Vector3.up * rocketThrust * Time.deltaTime);
        }
        else
        {
            audioSource.Stop();
        }

    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.J))
        {

            transform.Rotate(Vector3.forward * Time.deltaTime * rocketRotation);
        }
        else if(Input.GetKey(KeyCode.L))
        {

            transform.Rotate(Vector3.back * Time.deltaTime * rocketRotation);
        }
    }
}
