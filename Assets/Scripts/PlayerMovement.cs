using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player movement
    public float playerSpeed;
    private Rigidbody2D rb2d;

    //Cam
    public Transform cam;
    public Transform player;
    private Vector3 camOffset;

    //Rotation
    public float rotationSpeed;
    private float angleRad;
    private float angleDeg;

    private void movement()
    {
        //Movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 directionForwards = Vector2.up;
        Vector2 directionRight = Vector2.right;

        Vector2 movement = (directionForwards * moveVertical + directionRight * moveHorizontal) * playerSpeed * Time.deltaTime;
        //Checks if player is moving because if not it will error
        if (movement.sqrMagnitude > 0)
        {
            movement = movement.normalized * playerSpeed * Time.deltaTime;
        }

        rb2d.velocity = movement;


    }

    private void turning()
    {
        //Rotation
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;

        float mousePos_y = mousePos.y;
        float mousePos_x = mousePos.x;

        float playerPos_y = playerPos.y;
        float playerPos_x = playerPos.x;

        float xAxis = mousePos_x - playerPos_x;
        float yAxis = mousePos_y - playerPos_y;

        angleRad = Mathf.Atan2(yAxis, xAxis);
        angleDeg = angleRad * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.forward * angleDeg;
        transform.eulerAngles += new Vector3(0, 0, -90);

    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        camOffset = new Vector3(0f, 0f, -10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        turning();
        cam.position = player.position + camOffset;

    }
}
