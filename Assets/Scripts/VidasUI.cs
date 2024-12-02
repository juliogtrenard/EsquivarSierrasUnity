using UnityEngine;
using UnityEngine.UI;

public class VidasUI : MonoBehaviour
{
    public Image corazon1;
    public Image corazon2;
    public Image corazon3;
    private int vidas;

    void Start()
    {
        vidas = GameManager.Instance.vidas;
    }

    void Update()
    {
        if (vidas != GameManager.Instance.vidas)
        {
            vidas = GameManager.Instance.vidas;
            ActualizarCorazones();
        }
    }

    void ActualizarCorazones()
    {
        if (vidas == 3)
        {
            corazon1.enabled = true;
            corazon2.enabled = true;
            corazon3.enabled = true;
        }
        else if (vidas == 2)
        {
            corazon1.enabled = false;
            corazon2.enabled = true;
            corazon3.enabled = true;
        }
        else if (vidas == 1)
        {
            corazon1.enabled = false;
            corazon2.enabled = false;
            corazon3.enabled = true;
        }
        else
        {
            corazon1.enabled = false;
            corazon2.enabled = false;
            corazon3.enabled = false;
        }
    }
}