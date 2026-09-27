using System;
using Unity.VisualScripting;
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
    
    void Start()
    {
        moveLeft = InputSystem.actions.FindAction("MoveLeft");
        moveRight = InputSystem.actions.FindAction("MoveRight");
        moveUp = InputSystem.actions.FindAction("MoveUp");
        moveDown = InputSystem.actions.FindAction("MoveDown");

    }

    void Update()
    {
        Mouvement();
    }

    void Mouvement()
    {
        Vector2 mouvement = Vector2.zero;
        if (moveLeft.IsPressed())
        {
            mouvement.x = - 1;
        }
        else if (moveRight.IsPressed())
        {
            mouvement.x = 1;
        }
        
        if (moveUp.IsPressed())
        {
            mouvement.y = 1;
        }
        else if (moveDown.IsPressed())
        {
            mouvement.y = - 1;
        }

        mouvement = Vector2.Normalize(mouvement) * playerSpeed * Time.deltaTime;

        transform.position += new Vector3(mouvement.x,mouvement.y, 0);
    }
}
