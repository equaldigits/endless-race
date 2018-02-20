using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	private float velocidadeAtual;
	private float velocidade;
	private float verifica;
	private int bateu;
	private int animacao = 0;
	private float valor = 0;
	private int arranca = 0;
	private Vector3 carro;

	// Use this for initialization
	void Awake () {
		verifica = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		velocidade = GameObject.FindWithTag ("Player").GetComponent<Gestor>().velocidade;
		arranca = GameObject.FindWithTag ("Player").GetComponent<Gestor> ().arranca;
		carro = GameObject.FindWithTag ("Player").GetComponent<Gestor> ().transform.position;
		velocidadeAtual = GameObject.FindWithTag ("Player").GetComponent<Gestor>().velocidadeAtual;
		bateu = GameObject.FindWithTag ("Player").GetComponent<Gestor>().bateu;


		if (arranca == 1){
			this.transform.position = new Vector3 (carro.x, carro.y + 1.3f, carro.z - 3);

		}



		if (velocidadeAtual > verifica) {
			this.transform.localPosition -= new Vector3 (0, 0, 0.002f);
			verifica += velocidade*0.001f;
		}
		if (velocidadeAtual == velocidade){
			this.transform.localPosition = new Vector3 (0,1.3f,-5f);
		}
		if (bateu == 1) {
			animacao += 1;
			if (animacao < 10) {
				this.transform.localPosition += new Vector3 (0, 0, 0.100f);
			}
			if (animacao > 10 && animacao < 250) {
				this.transform.localPosition += new Vector3 (0, 0, 0.080f);
			}
			if (animacao >250) {
				this.transform.localPosition += new Vector3 (0, 0, 0.050f);
			}
	
		}
	}
}
