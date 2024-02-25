using UnityEngine;

public class CompleteCameraController : MonoBehaviour
{

    public GameObject player;       // Variable publique pour stocker la r�f�rence vers l'objet du joueur


    private Vector3 offset;         // Variable priv�e pour stocker le d�calage entre le joueur et la cam�ra

    // Initialisation
    void Start()
    {
        // Calcul et stocke le d�calage entre le joueur et la cam�ra
        offset = transform.position - player.transform.position;
    }

    // La fonction LateUpdate() est appel�e apr�s la fonction Update() � chaque image
    void LateUpdate()
    {
        // D�finit la position de la cam�ra avec celle du joueur tout en ajoutant un d�calage.
        transform.position = player.transform.position + offset;
    }
}
