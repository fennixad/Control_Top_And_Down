using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Disparo : MonoBehaviour
{
    public Rigidbody balaOriginal;
    public Transform puntoOrigenBalas;
    [Range(1f, 25f)] public float fuerza;
    [SerializeField] AudioClip clip;
    AudioSource audioSource;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posBala = puntoOrigenBalas.position;
            Quaternion rotBala = puntoOrigenBalas.rotation;

            Rigidbody balaClonada = Instantiate(balaOriginal, posBala, rotBala);
            Vector3 dirFuerza = balaClonada.transform.forward;

            balaClonada.AddForce(dirFuerza * fuerza, ForceMode.VelocityChange);
            audioSource.PlayOneShot(clip);
        }
    }
}
