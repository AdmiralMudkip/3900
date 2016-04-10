using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float movementSpeed = 10;
    
    public float smoothing = 15f, dampening = 1f, maxVelChange = 10.0f;
    Vector3 offset;
    Rigidbody body;

    Vector3 targetVel;
    Vector3 vel;
    Vector3 velChange;
    Vector3 maxVel;

    public bool active = false;
    
    void Start () {
        //offset = transform.position - transform.position;
        body = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (active)
        {
            // getaxis is automatically bound to WASD
            //float horizontal = Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime;
            //transform.Translate(horizontal, 0, 0);
            //Vector3 t = new Vector3(horizontal, transform.position.y, transform.position.z);
            //body.MovePosition(t);
            //float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            //transform.Translate(0, 0, vertical);
            
        }
    }

    void LateUpdate()
    {
        targetVel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVel = transform.TransformDirection(targetVel);
        targetVel *= movementSpeed;

        vel = body.velocity;
        velChange = (targetVel - vel);
        velChange.x = Mathf.Clamp(velChange.x, -maxVelChange, maxVelChange);
        velChange.y = Mathf.Clamp(velChange.y, -maxVelChange, maxVelChange);
        velChange.y = 0;

        body.AddForce(velChange, ForceMode.VelocityChange);
        if (body.velocity.magnitude > 3)
        {
            body.velocity = body.velocity.normalized * 1;
        }
    }

    //void LateUpdate()
    //{
    //    if (active)
    //    { // interpolate for smoothness
    //        //Vector3 desiredPosition = transform.position + offset;
    //        //Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * dampening);
    //        //transform.position = position;
    //    }
    //}


}
