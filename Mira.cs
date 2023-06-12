using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
   [SerializeField] private Transform pointer;
     void Start()
    {
       Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (ConfigController.instance.isPause){
            Cursor.visible = true;
            return;
        } else{
            Cursor.visible = false;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 0.5f;
            pointer.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
