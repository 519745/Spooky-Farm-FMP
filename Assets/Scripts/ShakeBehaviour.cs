using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehaviour : MonoBehaviour
{ 
// Transform of the GameObject you want to shake
private Transform transform;

// Desired duration of the shake effect
public float shakeDuration = 0f;

// A measure of magnitude for the shake. Tweak based on your preference
private float shakeMagnitude = 0.2f;

// A measure of how quickly the shake effect should evaporate
private float dampingSpeed = 1.0f;

// The initial position of the GameObject
Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            if (initialPosition == Vector3.zero)
            {
                initialPosition = transform.localPosition;
            }
            
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            if (initialPosition != Vector3.zero)
            {
                transform.localPosition = initialPosition;
                initialPosition = Vector3.zero;
            }           
        }
    }

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    void OnEnable()
    {
        //initialPosition = transform.localPosition;
    }
 }

