using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    //Valor atual de moedas do jogador
    private int bolsa;
    //Valor a ser mostrado na tela
    public Text MostrarBolsa;
    ///MOSTRAR INFORMACAO CORACAO
    public Text MostrarValorCoracao;
    //informacoes sobre meu coracao
    private int infocoracao;

    // Start is called before the first frame update
    void Start()
    {
        //Busca o Valor do Jogador
        bolsa = PlayerPrefs.GetInt("bolsa");
    }

    // Update is called once per frame
    void Update()
    {

        infocoracao = PlayerPrefs.GetInt("coracao");
        int valorC = infocoracao*5;
        MostrarValorCoracao.text = "NIVEL: "+infocoracao.ToString()+"$: "+valorC.ToString();

        //Manter o valor da bolsa atualizado
        bolsa = PlayerPrefs.GetInt("bolsa");
        //Atualizar no canvas
        MostrarBolsa.text = bolsa.ToString();
    }

    public void Comprar2(int tipo){

    }

    //COMPRAR CORACAO
    public void BTCompra1(){
        infocoracao = PlayerPrefs.GetInt("coracao");
        int valorC = infocoracao*5;
        //informa valor do coracao e numero da compra 1
        Comprar(valorC,1);
    }

    //VERIFICO PAGAMENTO
    void Comprar(int valor, int numerodoproduto){

        if (valor <= bolsa){
            //Comprou
            //diminui valor
            bolsa = bolsa - valor;
            PlayerPrefs.SetInt("bolsa", bolsa);
            //CHamara finalização de compra
            FinalizarCompra(numerodoproduto);
        }

    }

    //ENTREGO PRODUTO
    void FinalizarCompra(int numero){
        switch(numero){
            case 1:
                AumentarCoracoes();
                break;
            default:
                //NãoDeveOcorrer
                break;
        }
    }

    void AumentarCoracoes(){
        int coracao = PlayerPrefs.GetInt("coracao");
        coracao++;
        PlayerPrefs.SetInt("coracao", coracao);
    }
}
