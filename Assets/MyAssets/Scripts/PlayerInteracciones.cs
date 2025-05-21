using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class PlayerInteracciones : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    public float vida;

    public bool enNubeToxica;
    public float nubeToxTiempo;
    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        vida = 100f;
    }

    private void Update()
    {
        if (enNubeToxica)
        {
            if (nubeToxTiempo < 0.5f) nubeToxTiempo += Time.deltaTime;
            else
            {
                vida -= 5f;
                nubeToxTiempo = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NubesToxicas"))
        {
            enNubeToxica = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NubesToxicas"))
        {
            enNubeToxica = false;
            nubeToxTiempo = 0f;
        }
    }
    #endregion
    // ***********************************************
    #region 3) Funciones originales

    #endregion
    // ***********************************************
}
