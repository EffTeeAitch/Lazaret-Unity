using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class playerMovement : MonoBehaviour
{

    public float playerSpeed;
    public float walkSpeed = 2f;
    public float mouseSensitivity = 2f;
    public float jumpHeight = 1f;
    private bool isMoving = false;
    private float yRot;

    private Rigidbody rigidBody;
    private bool isPaused = false;
    private bool lockCursor = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerSpeed = walkSpeed;
        rigidBody = GetComponent<Rigidbody>();

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            lockCursor = !lockCursor;
        }

        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.Confined;
        Cursor.visible = !lockCursor;
   
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.timeScale > 0.5f)
            {
                Time.timeScale -= 0.4f;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.timeScale <= 15)
            {
                Time.timeScale += 0.5f;
            }
            else
            {
                Debug.Log(message: "You can not speed up time no more");
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
            else if (isPaused)
            {
                Time.timeScale = 3f;
                isPaused = false;
            }
        }

       

        yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);

        isMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
            rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
            isMoving = true;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed;
            isMoving = true;
        }

        ResetScene();
    }

    private void ResetScene()
    {
        if(this.transform.position.y <= -2)
        {
            SceneManager.LoadScene(4);
        }
    }
}