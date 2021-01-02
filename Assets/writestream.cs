using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class writestream : MonoBehaviour
{
    public GameObject wall1;

    public GameObject wall2;

    public GameObject wall3;
    float distance_w1_x;


    Collider m_ObjectCollider;
    MeshRenderer m_render;
    SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //wall1.transform.position.x
        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = true;
        m_render = GetComponent<MeshRenderer>();
        m_render.enabled = false;
        Debug.Log("OpenConnection started");
        if (sp != null)
        {
            if (sp.IsOpen)
            {
               // sp.Close();
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
        sp.Write("200");
        if (Input.GetKey("right"))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("left"))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("up"))
        {
            this.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey("down"))
        {
            this.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKeyDown("space"))
        {
            m_ObjectCollider.isTrigger = false;
            m_render.enabled = true;
            //new WaitForSeconds(1);
            //m_ObjectCollider.isTrigger = true;
            // new WaitForSeconds(3);
        }
        if (Input.GetKeyUp("space"))
        {
            m_ObjectCollider.isTrigger = true;
            m_render.enabled = false;
            //new WaitForSeconds(1);
            //m_ObjectCollider.isTrigger = true;
            // new WaitForSeconds(3);
        }

    }

    

}
