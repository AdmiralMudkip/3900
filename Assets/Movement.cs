using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float movementSpeed = 20;
    float strafeSpeed = 20;
    public float smoothing = 15f, dampening = 1f;
    Vector3 offset;
    
    public bool active = false;
    
    void Start () {
        offset = transform.position - transform.position;
    }

    void Update()
    {
        if (active)
        {
            // getaxis is automatically bound to WASD
            float horizontal = Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime;
            transform.Translate(horizontal, 0, 0);

            float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
    }

    void LateUpdate()
    {
        if (active)
        { // interpolate for smoothness
            Vector3 desiredPosition = transform.position + offset;
            Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * dampening);
            transform.position = position;
        }
    }
}
