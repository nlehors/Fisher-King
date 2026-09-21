using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    
    InputAction moveLeft;
    InputAction moveRight;
    InputAction moveUp;
    InputAction moveDown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveLeft = InputSystem.actions.FindAction("MoveLeft");
        moveRight = InputSystem.actions.FindAction("MoveRight");
        moveUp = InputSystem.actions.FindAction("MoveUp");
        moveDown = InputSystem.actions.FindAction("MoveDown");
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
    }

    void Mouvement()
    {
        if (moveLeft.IsPressed())
        {
            transform.position = new Vector3(transform.position.x - playerSpeed, transform.position.y, transform.position.z);
        }
        else if (moveRight.IsPressed())
        {
            transform.position = new Vector3(transform.position.x + playerSpeed, transform.position.y, transform.position.z);
        }
        
        if (moveUp.IsPressed())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + playerSpeed, transform.position.z);
        }
        else if (moveDown.IsPressed())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - playerSpeed, transform.position.z);
        }
    }
}
