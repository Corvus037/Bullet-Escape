using UnityEngine;
using UnityEngine.UI;

public class TelaVermelha : MonoBehaviour
{
    [SerializeField] private Life vidaController;
    [SerializeField] private Image telaVermelha;
    [Range(0, 1)]
    [SerializeField] private float taxaMinima = 0.5f;

    private void Update()
    {
        Color corAtual = telaVermelha.color;
        if (vidaController.TaxaDeVida <= taxaMinima) {
            corAtual.a = 1f - (vidaController.TaxaDeVida / taxaMinima);
        } else { 
            corAtual.a = 0;
        }
        telaVermelha.color = corAtual;
    }
}