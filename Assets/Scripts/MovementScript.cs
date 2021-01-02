using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
public class MovementScript : MonoBehaviour
{
    public GameObject Bounceball;
    public GameObject player;
    float distance;
    Collider m_ObjectCollider;
    MeshRenderer m_render;
    SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
    float speed;
    System.Random r;
    bool hasCollided;
    bool hasPressed;
    float CollisionTime;
    float ButtonPress;
    float reactionTime;
    double BallDist;
    // Start is called before the first frame update
    void Start()
    {
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
        // BallDist = Math.Sqrt(Math.Pow(player.transform.position.x - Bounceball.transform.position.x, 2) + Math.Pow(player.transform.position.y - Bounceball.transform.position.y, 2));
        BallDist = Bounceball.transform.position.y - player.transform.position.y;

       // BallDist = remap(BallDist);
        Debug.Log(BallDist);
        if (BallDist > 100)
        {
            sp.Write(100.ToString());
        }
        else
        {
            sp.Write(0.ToString());
        }

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
            ButtonPress = Time.time;

            if (hasCollided)
            {
                reactionTime = Mathf.Abs(CollisionTime - ButtonPress);
                Debug.Log(reactionTime);
                ButtonPress = 0;
                CollisionTime = 0;
                hasCollided = false;

            }
            else
                hasPressed = true;


        }
        if (Input.GetKeyUp("space"))
        {
            r = new System.Random();
            speed = r.Next(4, 10);
        }


    }

    void OnCollisionEnter(Collision c)
    {

        if (c.collider.tag == "Solids")
        {
            sp.Write("y");
            CollisionTime = Time.time;
            hasCollided = true;
            if (hasPressed)
            {
                reactionTime = Mathf.Abs(CollisionTime - ButtonPress);
                ButtonPress = 0;
                CollisionTime = 0;
                Debug.Log(reactionTime);
                hasPressed = false;
            }
            else
                hasCollided = true;

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
            sp.Write("p");
        }

        if (c.tag == "Outer")
        {
            sp.Write("1");
        }

        if (c.tag == "Outer4")
        {
            sp.Write("4");
        }
        if (c.tag == "Outer2")
        {
            sp.Write("2");
        }
        if (c.tag == "Outer3")
        {
            sp.Write("3");
        }

        if (c.tag == "Outer5")
        {
            sp.Write("5");
        }

        if (c.tag == "Outer6")
        {
            sp.Write("6");
        }
        if (c.tag == "Outer7")
        {
            sp.Write("7");
        }
        if (c.tag == "Outer8")
        {
            /*ButtonPress = 0;
            CollisionTime = 0;
            counter += 1;
            if (counter == 22)
            {
                Debug.Log("Break");
                Debug.Break();
            }*/
            sp.Write("8");

        }

    }
    void OnTriggerExit(Collider c)
        {
            sp.Write("e");
        }
}
  /*public int remap(double input)
    {

    int output = (int)((1/input) * 256);
    return output;
        
    }*/

