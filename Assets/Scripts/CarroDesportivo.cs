using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroDesportivo : MonoBehaviour {

	public float velocidade;
	public float aceleracao;
	public float curvas;

	void Awake () {
		velocidade = 300; //Maximo 480
		aceleracao = 10000;
		curvas = 20000;
	}

}