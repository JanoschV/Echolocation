using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Diagnostics;
using System;
using UnityEngine.UI;

public class PlayerScriptScene2 : MonoBehaviour
{
    Collider m_ObjectCollider;
    MeshRenderer m_render;
  //  SerialPort sp = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
    public float speed;
    public GameObject player;
    public GameObject Bounceball;
    float BallDist;
    public Vector3 direction;
    double angle;
    public Transform playerMove;
    public Rigidbody capsule;
    // Start is called before the first frame update
    public CharacterController _controller;
    public float _speed = 10;
    public float _rotationSpeed = 180;
    public Camera cam1;
    public Camera cam2;
    private Stopwatch timer;
    long time;
    private Vector3 rotation;
    public TrailRenderer trail;
    public Text text;
    Color c;

    public System.Random rand;
    
    string filepath;
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        rand = new System.Random();
        capsule.freezeRotation = true;
        cam1.enabled = true;
        cam2.enabled = false;
        timer = new Stopwatch();
        timer.Start();
        filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        text.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        BallDist = Vector3.Distance(Bounceball.transform.position, capsule.transform.position);
        if (BallDist < 5)
        {
            timer.Stop();
            cam1.enabled = false;
            cam2.enabled = true;
            time =timer.ElapsedMilliseconds;
            time = time / 1000;
            ScreenCapture.CaptureScreenshot(filepath +@"/ThesisScreenshot.png");
            
            text.text = time.ToString();
                

        }
        direction = new Vector3((Bounceball.transform.position.x - player.transform.position.x),(Bounceball.transform.position.z - player.transform.position.z));
        angle = Vector3.Angle(Vector3.up, direction);
        int angleint = (int)angle;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        CharacterController controller = GetComponent<CharacterController>();

        Vector3 moveValues = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveValues = new Vector3(moveValues.x * 0.5f, moveValues.y * 0.5f, moveValues.z * 0.5f);
        //controller.Move(moveValues);

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
 
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);
    

    }


    void OnCollisionEnter(Collision c)
    {

        if (c.collider.tag == "Solids")
        {
         //   Debug.Log("collision happened");
        }


    }

    void OnCollisionExit(Collision e)
    {
    }


    void OnTriggerEnter(Collider c)
    {
       

    }

    void OnTriggerExit(Collider c)
    {
    }

}