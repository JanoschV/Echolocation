﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class NewBehaviourScript : MonoBehaviour
{
    Collider m_ObjectCollider;
    MeshRenderer m_render;
    SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("OpenConnection started");
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                Debug.Log("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();  // opens the connection
                sp.ReadTimeout = 16;            // sets the timeout value before reporting error
                Debug.Log("Port Opened!");
            }
        }

        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
        Debug.Log("Open Connection finished running");
    }


    // Update is called once per frame
    void Update()
    {
        rb.freezeRotation = true;
        this.transform.position += new Vector3(0, 0, 4 * Time.deltaTime);

        if (Input.GetKey("right"))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("left"))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
       
        

    }

    void OnCollisionEnter(Collision c)
    {

        if (c.collider.tag == "Solids")
        {
            sp.Write("y");
        }

        if (c.collider.tag == "Solids Left")
        {
            sp.Write("u");
        }

        if (c.collider.tag == "Finish")
        {
            sp.Write("w");
        }



    }

    void OnCollisionExit(Collision e)
    {
        sp.Write("e");
    }


    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Proximity")
        {
            Debug.Log("in proximity zone");
            sp.Write("p");
        }

        if (c.tag == "Outer")
        {
            Debug.Log("in proximity zone");
            sp.Write("o");
        }

        if (c.tag == "ProximityLeft")
        {
            Debug.Log("in proximity zone");
            sp.Write("l");
        }
        if (c.tag == "OuterLeft")
        {
            Debug.Log("in proximity zone");
            sp.Write("n");
        }

    }

    void OnTriggerExit(Collider c)
    {
        sp.Write("e");
    }

}