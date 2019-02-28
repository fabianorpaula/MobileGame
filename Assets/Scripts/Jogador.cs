using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

    public int pontos = 0;
    public GameObject PeixeComido;
    public float move = 0.5f;
    public GameObject ControladorDOJogo;
	// Use this for initialization
	void Start () {
        ControladorDOJogo = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        if(ControladorDOJogo.GetComponent<GameControler>().EstadoControle() == false)
        {
            //MOVER PELO DEDO
            Mover();
        }
        
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Comida")
        {
            pontos++;
            //GameObject Comida = Instantiate(PeixeComido, col.gameObject.transform.position, Quaternion.identity);
            //Destroy(Comida, 1f);
            Destroy(col.gameObject);
        }
    }

    public void MoverE()
    {
        //MOVER PELO BOTAO
        if (ControladorDOJogo.GetComponent<GameControler>().EstadoControle() == true)
        {
            transform.position = new Vector3(transform.position.x - move, transform.position.y, transform.position.z);
        }
    }

    public void MoverD()
    {
        //MOVER PELO BOTAO
        if (ControladorDOJogo.GetComponent<GameControler>().EstadoControle() == true)
        {
            transform.position = new Vector3(transform.position.x + move, transform.position.y, transform.position.z);
        }
    }


    public void Mover()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 destino = Input.mousePosition;
            Vector3 posD = Camera.main.ScreenToWorldPoint(destino);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(posD.x, posD.y, 0), 0.05f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(posD.x, transform.position.y, 0), 0.05f);
        }
        
    }

}
