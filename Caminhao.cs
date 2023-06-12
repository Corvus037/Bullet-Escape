using UnityEngine;

public class Caminhao : MonoBehaviour
{
    public float speed;
    public GameObject objetoVazio;
    public GameObject objetoInstanciar;
    public float intervaloDeInstanciacao = 2f;

    void Start()
    {
        
        InvokeRepeating("InstanciarObjeto", intervaloDeInstanciacao, intervaloDeInstanciacao);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void InstanciarObjeto()
    {
        // Verifica se o objeto vazio está definido
        if (objetoVazio != null)
        {
            // Obtém a posição do objeto vazio
            Vector3 posicao = objetoVazio.transform.position;

            // Instancia o objeto a ser criado na posição do objeto vazio
            Instantiate(objetoInstanciar, posicao, Quaternion.identity);
        }
    }
}
