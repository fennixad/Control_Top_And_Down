using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    Vector2 input;
    Vector3 dirMovimiento;

    Rigidbody rb;
    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        EjesVirtuales();
        CalcularDir();
        Rotar();
        Mover();
        TeletransporteCaida();
    }
    #endregion
    // ***********************************************
    #region 3) Funciones originales
    void EjesVirtuales()
    {
        input.x = Input.GetAxisRaw("Horizontal"); // teclas AD
        input.y = Input.GetAxisRaw("Vertical");   // teclas WS
    }

    void CalcularDir()
    {
        dirMovimiento = new Vector3(input.x, 0f, input.y);
        dirMovimiento.Normalize();

        Debug.DrawRay(transform.position, dirMovimiento, Color.red);
    }

    void Rotar()
    {
        if (input.x != 0f || input.y != 0f)
        {
            Quaternion rotActual = transform.rotation;
            Quaternion rotFinal = Quaternion.LookRotation(dirMovimiento);
            Quaternion rotSuave = Quaternion.RotateTowards(rotActual, rotFinal, 720f * Time.deltaTime);

            transform.rotation = rotSuave;
        }
    }

    void Mover()
    {
        transform.Translate(dirMovimiento * 2f * Time.deltaTime, Space.World);
    }

    void TeletransporteCaida()
    {
        // teletransporte al centro si se cae alcanzando en y un valor por debajo de -2
        if (transform.position.y <= -2f)
        {
            transform.position = Vector3.zero;
            rb.linearVelocity = Vector3.zero;
        }
    }
    #endregion
    // ***********************************************
}
