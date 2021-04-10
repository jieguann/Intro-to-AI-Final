using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M2MqttUnity.Examples;

public class RobotControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    public MQTTTest mqtt;
    float u;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        u = 0;
    }

    // Update is called once per frame
    void Update()
    {
        string speech = mqtt.speech;
        string objectDetection = mqtt.objectDetection;
        string teachablemachine = mqtt.teachablemachine;


        //Keyboard Control
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        

        //teachable machine code
        //print(teachablemachine);

        

        
        //Tensorflow.js control
        //print(objectDetection);
        if (objectDetection == "cell phone")
        {
            if (teachablemachine == "1.00")
            {
                z = 1f;
                x = 0f;
                //u = 1f;


            }
            else
            {
                z = 0f;
                x = 1f;
            }

            //print(speech);
            //one up, two down, three stop
            if (speech == "one")
            {
                u = 1f;
                print(1);
            }

            else if (speech == "two")
            {
                u = -1f;
                print(-1);
            }

            else if (speech == "three")
            {
                u = 0f;
                print(0);
            }
        }
        else { }


        
        //Move the Robot
        //Vector3 moveBy = transform.right * x + transform.forward * z;
        Vector3 moveBy = transform.forward * z;
        Vector3 moveUp = Vector3.up * u;
        rb.MovePosition(transform.position + moveBy.normalized * speed * Time.fixedDeltaTime + moveUp *speed* Time.fixedDeltaTime);
        //rb.MovePosition(transform.position + Vector3.up * z * speed * Time.fixedDeltaTime);
        float turn = x * rotationSpeed * Time.deltaTime;
        //Debug.Log(x);
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

    }
}
