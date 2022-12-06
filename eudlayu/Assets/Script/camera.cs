using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivityMouse; //sensibilidade do mouse
    public Transform rotatePlayer;  //rota��o do player
    public Vector3 Mira;




    private float xRotation; //rota��o

    public float minOTX, maxOTX; //minimo e maximo que a camera pode ir


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked //tirar o cursor do mouse da tela
       
        //Cursor.lockState = CursorLockMode.Locked;
       
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime; //sensibilidade x
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime; //sensibilidade y

        xRotation -= mouseY; //rota��o Y

        xRotation = Mathf.Clamp(xRotation, minOTX, maxOTX); //o maximo e a minima rota��o que ele podem fazer

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  //rota��o para os lados

        rotatePlayer.Rotate(Vector3.up * mouseX); //rota��o X

        float camera = Screen.width / 2;
        float cameraY = Screen.height / 2;

        Vector3 Mira = new Vector3(camera, cameraY, 0);

        Ray raio = Camera.main.ScreenPointToRay(Mira);


    }
}
