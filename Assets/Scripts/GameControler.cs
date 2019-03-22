using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour {

    public GameObject GameOver;
    public Text MelhorPontuacao;
    public Text Pontuacao;

    //Dinheiro Total
    public Text Bolsa;
    //DInheiro Da Partida
    public Text MoedadaPartida;
    public Text ponto;
    public Text vida;
    public Text moeda;
    private Jogador MeuGatinho;
    public bool GameOn = false;
    public bool ControleBotao = true;
    public int maiorpontos;

    // Use this for initialization
    void Start () {
        //ZERAR BANCO
        //PlayerPrefs.DeleteAll();

        MeuGatinho = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
        if (PlayerPrefs.HasKey("recorde")) {
            // fazer nada, pq ela já existe
        } else {
            PlayerPrefs.SetInt("recorde", 0);
        }
        ///GARANTE QUE O CORAÇÃO TENHA VALOR INICIAL
        if (PlayerPrefs.HasKey("coracao")) {
            // fazer nada, pq ela já existe
        } else {
            PlayerPrefs.SetInt("coracao", 1);
        }
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //Só atualiza quando o jogo tá rolando
        if(GameOn == true){
            AtualizarDados();
             Morreu();
        }
        
	}

    public void DadosIniciaisdoJogo(){
        MeuGatinho.pontos = 0;
        MeuGatinho.vidas = PlayerPrefs.GetInt("coracao");
        MeuGatinho.moedas = 0;
        GameOn = true;
        Time.timeScale = 1;
    }

    public void Reiniciar() 
    {
        MeuGatinho.pontos = 0;
        MeuGatinho.vidas = PlayerPrefs.GetInt("coracao");
        MeuGatinho.moedas = 0;
        GameOn = true;
        Time.timeScale = 1;
        Limpar();
    }

    void Morreu()
    {
        if(MeuGatinho.vidas <=0) 
        {
            GameOn = false;
            // PARAR A FISICA
            Time.timeScale = 0;

            GameOver.SetActive(true);
            Pontuacao.text = "PONTOS: " + MeuGatinho.pontos.ToString();
            maiorpontos = PlayerPrefs.GetInt("recorde");
            if (maiorpontos >= MeuGatinho.pontos) 
            {
                MelhorPontuacao.text = "RECORDE " + maiorpontos.ToString();
            } else 
            {
                MelhorPontuacao.text = "RECORDE " + maiorpontos.ToString();
                PlayerPrefs.SetInt("recorde" , MeuGatinho.pontos);
            }
            ///CUIDANDO DAS MOEDAS
            MoedadaPartida.text = "MOEDAS: " + MeuGatinho.moedas.ToString();
            //recebe a quantidade de moedas que eu tinhas
            int minhasmoedas = PlayerPrefs.GetInt("bolsa");
            //somo as moedas que eu já tenho com as moedas novas
            minhasmoedas = minhasmoedas + MeuGatinho.moedas;
            //Valor para exibir na bolsa
            Bolsa.text = "BOLSA: "+minhasmoedas.ToString();
            //salvando valor
            PlayerPrefs.SetInt("bolsa", minhasmoedas);



        }
    }

    void AtualizarDados() 
    {
        ponto.text = "PONTOS: " + MeuGatinho.pontos.ToString();
        vida.text = "VIDAS: " + MeuGatinho.vidas.ToString();
        moeda.text = ": " + MeuGatinho.moedas.ToString();
    }

    public void Jogar()
    {
        GameOn = true;
        DadosIniciaisdoJogo();
    }

    //Limpa Cena
    void Limpar() {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Comida");
        foreach (GameObject item in inimigos) 
        {
            Destroy(item);
        }

        GameObject[] inimigos2 = GameObject.FindGameObjectsWithTag("Veneno");
        foreach (GameObject item in inimigos2) 
        {
            Destroy(item);
        }
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
