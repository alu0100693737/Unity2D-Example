using UnityEngine;
using System.Collections;

public class controladorPersonaje : MonoBehaviour {

    public float fuerzaSalto = 13f;

    private bool enSuelo = true;
    public Transform comprobadorSuelo;
    private float comprobadorRadio = 0.07f;
    public LayerMask mascaraSuelo;

    //se permite el doble salto
    private bool dobleSalto = false;
    private Animator animator;

    private bool corriendo = false;
    public float velocidad = 1f;

    void Awake() {
        animator = GetComponent<Animator>();
    }


	void Start () {
	
	}

    void FixedUpdate() {
        if(corriendo) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
        }
        animator.SetFloat("velocidadx", GetComponent<Rigidbody2D>().velocity.x);
        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
        animator.SetBool("isGrounded", enSuelo);
        if (enSuelo) {
            dobleSalto = false;
        }
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            if (corriendo) {
                if (enSuelo || !dobleSalto) {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
                    //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));
                    if (!dobleSalto && !enSuelo) {
                        dobleSalto = true;
                    }
                }
            } else
            {
                corriendo = true;
            }
        }
    }
}
