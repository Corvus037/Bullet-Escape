using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
   
   
    void Update()
    {   
        if (ConfigController.instance.isPause) return;
       // Obtém a posição do mouse na tela
        Vector3 mousePosition = Input.mousePosition;

        // Calcula a posição do mouse no espaço 3D, na mesma profundidade do objeto
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcula a rotação em torno do eixo Z para olhar em direção ao mouse
        Vector3 direction = transform.position - worldPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Aplica a rotação apenas em torno do eixo Z ao objeto
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
