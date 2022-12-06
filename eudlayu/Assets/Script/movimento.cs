using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class movimento : MonoBehaviour
{
    private CharacterController controller;
    [Header("Movimento Player")]
    public float speed;


    [Header("Gravidade Player")]
    public float fatorMultiplicativo;
    public float gravidade;
    private Vector3 velocidadePulo;
    public float jumpForce;



    [Header("Jump")]
    private bool sensor;
    public LayerMask layerPulo;
    public Transform posicaoSensor;



    [Header("Player Run")]
    public float baseSpeed;
    public float addSpeed;

    private int pontuacao;
    public Text txtPontuacao;

    [Header("player Slow")]
    public float lowSpeed;


    [Header("Anim")]
    public GameObject animMonstro;
    public bool colidir;

    [Header("Pegar Cristal")]
    public GameObject cristal1;
    public GameObject cristal2;
    public GameObject cristal3;
    public TextMeshProUGUI numeroDeCristais;
    float contarCristais;

    [Header("Pause")]
    public GameObject painelPause;
    public bool pausado;

    [Header("Tiro")]
    public GameObject projetil;
    public Transform posTiro;

    [Header("Cursor")]
    public Texture2D cursorTexture;
    Vector2 cursorHotspot;

    // Start is called before the first frame update
    void Start()
    {
        
        controller = GetComponent<CharacterController>();  //controle
        gravidade = Physics.gravity.y;
        speed = baseSpeed;
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        Cursor.visible = false;
        
    }

    // Update is called once per frame


   

    // Update is called once per frame
    void Update()
    {
        MovimentacaoPlayer();

        GravidadePlayer();

        JumpPlayer();

        RunPlayer();

        sensor = Physics.CheckSphere(posicaoSensor.position, 0.5f, layerPulo);

        if (Input.GetKeyDown(KeyCode.E) && cristal1.gameObject.tag == "Cristal")
        {
            Destroy(cristal1.gameObject);
            contarCristais += 1;
            numeroDeCristais.text = contarCristais.ToString();

        }

        if (Input.GetButtonDown("Fire1"))
        {
            Atirar();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado == false)
            {
                painelPause.SetActive(true);
                pausado = true;
                Cursor.visible = true;
                Time.timeScale = 0;
                
            }
            else if(pausado == true)
            {
                painelPause.SetActive(false);
                pausado = false;
                Cursor.visible = false;
                Time.timeScale = 1;
                
            }

        }
 /* if(vida = 0)
    {
         painelGO.SetActive(true);
         Time.timeScale = 0;
    }

 */
    }


    public void MovimentacaoPlayer()
    {
        float x = Input.GetAxis("Horizontal"); //controle horizontal

        float z = Input.GetAxis("Vertical"); //contorle vertical

        Vector3 move = transform.right * x + transform.forward * z; //movimentação
        controller.Move(move * speed * Time.deltaTime); //velocidade
    }

    public void JumpPlayer()  //JumpPlayer
    {
        if (Input.GetButtonDown("Jump") && sensor == true)
        {
            velocidadePulo.y = jumpForce;
        }
    }
    public void GravidadePlayer() //gravidade Player
    {
        velocidadePulo.y += gravidade * fatorMultiplicativo * Time.deltaTime;

        controller.Move(velocidadePulo * Time.deltaTime);
    }

    public void RunPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed = baseSpeed + addSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = baseSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = baseSpeed - lowSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = baseSpeed;
        }


    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Portao")
        {
            animMonstro.GetComponent<Animator>().SetBool("playerPerto", true);
            
        }

       
    }

    private void OnTriggerExit(Collider coll)
    {
       if(coll.gameObject.tag == "Portao")
        {
            animMonstro.GetComponent<Animator>().SetBool("playerPerto", false);
        } 
    }
   
    void Atirar()
    {
        Instantiate(projetil,posTiro.transform.position, Quaternion.identity);
        projetil.GetComponent<Rigidbody>().AddForce(Vector3.one, ForceMode.Impulse);
    }
}

