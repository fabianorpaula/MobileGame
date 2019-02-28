using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {

    public Text pontucao;
    private Jogador MeuGatinho;
    public bool GameOn = false;
    public bool ControleBotao = true;

	// Use this for initialization
	void Start () {
        MeuGatinho = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
	}
	
	// Update is called once per frame
	void Update () {

        //pontucao.text = "Pontos: " + MeuGatinho.pontos.ToString();
	}


    public void Jogar()
    {
        GameOn = true;
    }

    public bool EstadoJogo()
    {
        return GameOn;
    }

    public bool EstadoControle()
    {
        return ControleBotao;
    }
}
