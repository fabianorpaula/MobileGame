using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour {



    public GameObject Peixe;
    public GameObject PeixeEnvenenado;
    public GameObject Moeda;
    private int contador = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControler>().EstadoJogo() == true)
        {
            contador++;

            if (contador > 50)
            {
                float posX = Random.Range(-2.5f, 2.5f);
                Vector3 PosInicial = new Vector3(posX, 6, 0);
                float sorteio = Random.Range(0, 10);
                
                if(sorteio ==0)
                {
                    //Sortei moeda
                    GameObject MinhaMoeda = Instantiate(Moeda, PosInicial, Quaternion.identity);
                    Destroy(MinhaMoeda, 3f);
                }else if (sorteio >0 && sorteio < 4) {
                    //Sortei peixe
                    GameObject MeuPeixe = Instantiate(Peixe, PosInicial, Quaternion.identity);
                    Destroy(MeuPeixe, 3f);
                }
                else {
                    //sorteia veneno
                    GameObject MeuVeneno = Instantiate(PeixeEnvenenado, PosInicial, Quaternion.identity);
                    Destroy(MeuVeneno, 3f);

                }
                contador = 0;
            }

        }

	}
}
