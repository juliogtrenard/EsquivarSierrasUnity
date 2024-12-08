using UnityEngine;
using UnityEngine.UI;

// Controla la vida del jugador
public class VidasUI : MonoBehaviour
{
    // Referencias a los corazones
    public Image corazon1;
    public Image corazon2;
    public Image corazon3;

    // Las 3 vidas
    private int vidas;

    // Inicializa las vidas al iniciar el juego, en este caso 3
    void Start()
    {
        vidas = GameManager.Instance.vidas;
    }

    // Actualiza las imagenes de la vida siempre y cuando siga teniendo
    void Update()
    {
        if (vidas != GameManager.Instance.vidas)
        {
            vidas = GameManager.Instance.vidas;
            ActualizarCorazones();
        }
    }

    // Actualiza las imagenes de la vida
    void ActualizarCorazones()
    {
        if (vidas == 3) // 3 corazones
        {
            corazon1.enabled = true;
            corazon2.enabled = true;
            corazon3.enabled = true;
        }
        else if (vidas == 2) // 2 corazones
        {
            corazon1.enabled = false;
            corazon2.enabled = true;
            corazon3.enabled = true;
        }
        else if (vidas == 1) // 1 corazon
        {
            corazon1.enabled = false;
            corazon2.enabled = false;
            corazon3.enabled = true;
        }
        else // 0 corazones, game over
        {
            corazon1.enabled = false;
            corazon2.enabled = false;
            corazon3.enabled = false;
        }
    }
}