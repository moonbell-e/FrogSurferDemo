using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    private float _speed;
    private Vector3 _direction;


    void Start()
    {
        _speed = 5f;
    }

    void FixedUpdate()
    {
        if (SwipeController.swipeRight)
        {
            if (transform.position.z != 1.5f)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        if (SwipeController.swipeLeft)
        {
            if (transform.position.z != -2.5)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
        
        _direction.x = _speed;
        transform.Translate(-_direction * Time.deltaTime);
    }
}
