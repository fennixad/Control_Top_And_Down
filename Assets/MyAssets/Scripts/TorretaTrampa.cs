using Unity.VisualScripting;
using UnityEngine;

public class TorretaTrampa : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float velocidadRotacion = 20f; 
    [SerializeField] private GameObject player;
    [SerializeField] private Transform cabezaTorreta;
    private AudioSource audioSource;
    private bool rotacion;
    private bool jugadorEnRango;
    private float temporizador;
    private float proximoTemporizador;

    private void Awake()
    {
        cabezaTorreta = transform.GetChild(0);
        rotacion = true;
        jugadorEnRango = false;
        proximoTemporizador = Random.Range(1f, 2f);

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) Debug.LogError("No se encontró el jugador con tag 'Player'");
        }
    }

    void Update()
    {
        Rotacion();
        if (jugadorEnRango) DisparoAleatorio();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rotacion = false;
            jugadorEnRango = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rotacion = true;
            jugadorEnRango = false;
            temporizador = 0f;
        }
    }

    private void Rotacion()
    {
        if (rotacion)
        {
            cabezaTorreta.transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
        }
        else
        {
            Vector3 direccion = player.transform.position - cabezaTorreta.transform.position;
            direccion.y = 0; // Ignora altura
            cabezaTorreta.transform.rotation = Quaternion.LookRotation(direccion);

        }
    }

    private void DisparoAleatorio()
    {
        temporizador += Time.deltaTime;
        if (temporizador >= proximoTemporizador)
        {
            Debug.Log("Disparo");
            temporizador = 0f;
            proximoTemporizador = Random.Range(1f, 2f);
            // Instantiate(balaPrefab, transform.position, transform.rotation);
        }
    }
}
