using UnityEngine;

public class RockMoveUpDown : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingUp;
    private float Up_Move;
    private float Down_Move;

    private void Awake()
    {
        Up_Move = transform.position.y + movementDistance;
        Down_Move = transform.position.y - movementDistance;
    }

    private void Update()
    {
        if (movingUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Up_Move), speed * Time.deltaTime);
            if (transform.position.y >= Up_Move)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Down_Move), speed * Time.deltaTime);
            if (transform.position.y <= Down_Move)
            {
                movingUp = true;
            }
        }
    }


}