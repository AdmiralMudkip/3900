using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    float movementSpeed = 2;
    float strafeSpeed = 2;
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
            float horizontal = Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime;
            transform.Translate(horizontal, 0, 0);

            float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            transform.Translate(0, 0, vertical);
        }
    }

    void LateUpdate()
    {
        if (active)
        {
            Vector3 desiredPosition = transform.position + offset;
            Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * dampening);
            transform.position = position;
        }
    }
}
