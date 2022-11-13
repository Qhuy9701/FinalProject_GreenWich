using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMoveRightLeft : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;

    private bool movingRight;
    private float Right_Move;
    private float Left_Move;

    private void Awake()
    {
        Right_Move = transform.position.x + movementDistance;
        Left_Move = transform.position.x - movementDistance;
    }

    private void Update()
    {
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Right_Move, transform.position.y), speed * Time.deltaTime);
            if (transform.position.x >= Right_Move)
            {
                movingRight = false;      
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Left_Move, transform.position.y), speed * Time.deltaTime);
            if (transform.position.x <= Left_Move)
            {
                movingRight = true;
            }
        }
    }
}
