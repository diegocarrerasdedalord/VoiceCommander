using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    float gravedad;
    CharacterController cc;
    private float playerSpeed;
    public float playerSpeedAir;
    public float playerSpeedGround;
    public float gravityForce;
    private int jumpsCounter;
    public float jumpForce;
    public int maxJumps;
    private float rotationSpeedX;
    private float rotationSpeedY;
    private float rotationRange = 60.0f;
    public float mouseSensitivity;

    public float totalHP;
    public float currentHP;

    Manager manager;


    public void Awake()
    {
        cc = GetComponent<CharacterController>();
        manager = FindObjectOfType<Manager>();

    }

    public void Update()
    {
        if (currentHP<=0)
        {
            Die();
        }
        if (cc.isGrounded)
        {
            gravedad = 0;
            jumpsCounter = 0;
            playerSpeed = playerSpeedGround;
        }

        if (jumpsCounter < maxJumps)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravedad -= jumpForce;
                jumpsCounter++;
                playerSpeed = playerSpeedAir;
            }
        }



        gravedad += gravityForce * Time.deltaTime;

        //Mirar a los costados
        rotationSpeedX += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.eulerAngles = new Vector3(0, rotationSpeedX, 0);
        rotationSpeedY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationSpeedY = Mathf.Clamp(rotationSpeedY, -rotationRange, rotationRange);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationSpeedY, 0, 0);

        Vector3 mov = Vector3.zero;
        mov += Vector3.down * gravedad;
        mov += transform.forward * Input.GetAxis("Vertical") * playerSpeed;
        mov += transform.right * Input.GetAxis("Horizontal") * playerSpeed;
        cc.Move(mov * Time.deltaTime);
    }

    public void Die()
    {
        SceneManager.LoadScene(manager.currentLevel);
    }
}



