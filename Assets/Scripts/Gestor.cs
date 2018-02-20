using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestor : MonoBehaviour {

	private Rigidbody carroRB;
	private Vector3 verificaVelocidade;
	private GameObject[] rodas;
	public float velocidade;
	private float aceleracao;
	private Vector3 posicaoTunel;
	public GameObject tunel;
	private Vector3  carroPosicao;
	public int arranca;
	public float velocidadeAtual;
	private float curvas;
	private int bloqueio = 0;
	public int bateu = 0;
	private int bater = 0;

	// Use this for initialization
	void Start () {
		aceleracao = GameObject.FindWithTag ("Player").GetComponent<CarroDesportivo>().aceleracao;
		velocidade = GameObject.FindWithTag ("Player").GetComponent<CarroDesportivo>().velocidade;
		curvas = GameObject.FindWithTag ("Player").GetComponent<CarroDesportivo> ().curvas;
		carroRB = GameObject.FindWithTag ("Player").GetComponent<Rigidbody> ();
		arranca = 0;
		Invoke ("Arranca", 3f);
		rodas = GameObject.FindGameObjectsWithTag ("Rodas");
		posicaoTunel = new Vector3 (0,-1,2320);
	}

	void Update (){
		if (bloqueio == 1){
			if (Input.GetKeyDown (KeyCode.RightArrow) == true) {
				if (carroPosicao.x == -5.7f){
					InvokeRepeating ("Direita1", 0f, 0.0001f);
					bloqueio = 0;
					Debug.Log ("11r");
				}
				if (carroPosicao.x == -1.9f){
					InvokeRepeating ("Direita2", 0f, 0.0001f);
					bloqueio = 0;
					Debug.Log ("4r");
				}
				if (carroPosicao.x == 1.9f){
					InvokeRepeating ("Direita3", 0f, 0.0001f);
					bloqueio = 0;
					Debug.Log ("7r");
				}

			}
			if (Input.GetKeyDown (KeyCode.LeftArrow) == true) {
				if (carroPosicao.x == 5.7f){
					InvokeRepeating ("Esquerda1", 0f, 0.0001f);
					bloqueio = 0;
				}
				if (carroPosicao.x == 1.9f){
					InvokeRepeating ("Esquerda2", 0f, 0.0001f);
					bloqueio = 0;
				}
				if (carroPosicao.x == -1.9f){
					InvokeRepeating ("Esquerda3", 0f, 0.0001f);
					bloqueio = 0;
				}

			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		velocidadeAtual = carroRB.velocity.magnitude;
		if (arranca == 1){
			carroPosicao = carroRB.transform.position;
			if (carroRB.velocity.magnitude < velocidade) {

				carroRB.AddForce (carroRB.transform.forward + new Vector3 (carroRB.transform.rotation.y * curvas * velocidadeAtual, 0, aceleracao));
				//Debug.Log (carroRB.transform.forward);
				verificaVelocidade = carroRB.transform.position;

			} else {
				carroRB.velocity = new Vector3 (carroRB.velocity.x,carroRB.velocity.y,carroRB.velocity.z-1);
			}

		}
	}


	void Arranca () {
		arranca = 1;
		bloqueio = 1;
		CancelInvoke ("Arranca");

	}

	void Esquerda1 () {
		float x = carroRB.transform.position.x;
		if (x < 4.0f) {
			if (carroRB.transform.rotation.y < 0){
			carroRB.transform.rotation *= Quaternion.AngleAxis (3f * Time.deltaTime, Vector3.up);
			}
			else{
				carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			}
		} else {
			carroRB.transform.rotation *= Quaternion.AngleAxis(-0.5f * Time.deltaTime, Vector3.up);
		}


		if (x < 1.9f) {
			carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			carroRB.velocity = new Vector3 (0,carroRB.velocity.y,carroRB.velocity.z);
			carroRB.transform.position = new Vector3 (1.9f,carroRB.transform.position.y,carroRB.transform.position.z);
			CancelInvoke ("Esquerda1");
			bloqueio = 1;
		}
	
	}
	void Esquerda2 () {
		float x = carroRB.transform.position.x;
		if (x < 0.2f) {
			if (carroRB.transform.rotation.y < 0){
				carroRB.transform.rotation *= Quaternion.AngleAxis (3f * Time.deltaTime, Vector3.up);
			}
			else{
				carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			}
		} else {
			carroRB.transform.rotation *= Quaternion.AngleAxis(-0.5f * Time.deltaTime, Vector3.up);
		}

		if (x < -1.9f) {
			carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			carroRB.velocity = new Vector3 (0,carroRB.velocity.y,carroRB.velocity.z);
			carroRB.transform.position = new Vector3 (-1.9f,carroRB.transform.position.y,carroRB.transform.position.z);
			CancelInvoke ("Esquerda2");
			bloqueio = 1;
		}

	}
	void Esquerda3 () {
		float x = carroRB.transform.position.x;
		if (x < -3.6f) {
			if (carroRB.transform.rotation.y < 0){
				carroRB.transform.rotation *= Quaternion.AngleAxis (3f * Time.deltaTime, Vector3.up);
			}
			else{
				carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			}
		} else {
			carroRB.transform.rotation *= Quaternion.AngleAxis(-0.5f * Time.deltaTime, Vector3.up);
		}
		if (x < -5.7f) {
			carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			carroRB.velocity = new Vector3 (0,carroRB.velocity.y,carroRB.velocity.z);
			carroRB.transform.position = new Vector3 (-5.7f,carroRB.transform.position.y,carroRB.transform.position.z);
			CancelInvoke ("Esquerda3");
			bloqueio = 1;
		}

	}
	void Direita1 () {
		float x = carroRB.transform.position.x;
		carroRB.transform.rotation *= Quaternion.AngleAxis(0.5f * Time.deltaTime, Vector3.up);
		if (x > -1.9f) {
			carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			carroRB.velocity = new Vector3 (0,carroRB.velocity.y,carroRB.velocity.z);
			carroRB.transform.position = new Vector3 (-1.9f,carroRB.transform.position.y,carroRB.transform.position.z);
			CancelInvoke ("Direita1");
			bloqueio = 1;
		}

	}
	void Direita2 () {
		float x = carroRB.transform.position.x;
		carroRB.transform.rotation *= Quaternion.AngleAxis(0.5f * Time.deltaTime, Vector3.up);
		if (x > 1.9f) {
			carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			carroRB.velocity = new Vector3 (0,carroRB.velocity.y,carroRB.velocity.z);
			carroRB.transform.position = new Vector3 (1.9f,carroRB.transform.position.y,carroRB.transform.position.z);
			CancelInvoke ("Direita2");
			bloqueio = 1;
		}

	}
	void Direita3 () {
		float x = carroRB.transform.position.x;
		carroRB.transform.rotation *= Quaternion.AngleAxis(0.5f * Time.deltaTime, Vector3.up);
		if (x > 5.7f) {
			carroRB.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			carroRB.velocity = new Vector3 (0,carroRB.velocity.y,carroRB.velocity.z);
			carroRB.transform.position = new Vector3 (5.7f,carroRB.transform.position.y,carroRB.transform.position.z);
			CancelInvoke ("Direita3");
			bloqueio = 1;
		}

	}



































































	void OnTriggerEnter(Collider objectoColisao){

		if (objectoColisao.gameObject.tag == "NovoTunel") {
			Destroy (objectoColisao.gameObject);
			posicaoTunel = new Vector3 (posicaoTunel.x,posicaoTunel.y,posicaoTunel.z+600);
			GameObject tunelD = Instantiate (tunel, posicaoTunel, Quaternion.Euler( new Vector3(0,-180,0))) as GameObject; 
		}


	}
		
	void OnCollisionEnter(Collision objecto){

		if (objecto.gameObject.tag == "Civil") {
			arranca = 0;
			if (bater == 0){
				carroRB.constraints = RigidbodyConstraints.None;
				for (int i = 0; i < rodas.Length; i++){
					if (i == 0 | i == 1) {
						rodas [i].GetComponent<Animator> ().enabled = false;
						rodas [i].GetComponent<MeshCollider> ().enabled = true;
						rodas[i].AddComponent<Rigidbody>();
						rodas [i].GetComponent<Rigidbody> ().AddForce (rodas[i].transform.position + new Vector3 (0, 0, velocidadeAtual*4*3));
					} else {
						rodas [i].GetComponent<Animator> ().enabled = false;
						rodas [i].GetComponent<MeshCollider> ().enabled = true;
					}
				}
				bateu = 1;
				bater = 1;
			}
		}

	}
}
