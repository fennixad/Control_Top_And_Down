using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed;
    Vector2 input;

    private void Awake()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input.x = horizontal * speed * Time.deltaTime;
        input.y = vertical * speed * Time.deltaTime;

        Debug.DrawRay(transform.position, new Vector3(input.x, 0f, input.y), Color.red);
    }

    void Movimiento()
    {

    }
}
