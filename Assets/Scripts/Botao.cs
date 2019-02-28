using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botao : Button
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void APETOU()
    {
        if(IsPressed())
        {
            Debug.Log("APERTANDO");
        }

    }

    // Update is called once per frame
    void Update()
    {
        APETOU();
    }
}
