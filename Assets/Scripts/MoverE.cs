using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverE : Button
{
    private GameObject Personagem;
    void Start()
    {
        Personagem = GameObject.FindGameObjectWithTag("Player");
    }
    void Movimenta()
    {
        if (IsPressed())
        {
            Personagem.GetComponent<Jogador>().MoverE();
        }
    }
    void Update()
    {
        //Chama movimento
        Movimenta();
    }
}
