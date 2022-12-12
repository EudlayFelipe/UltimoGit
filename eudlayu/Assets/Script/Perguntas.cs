using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Perguntas : MonoBehaviour
{
    public GameObject painelPergunta1, painelPergunta2, painelPergunta3;
 
    public int contResp;

    private movimento movePlayer;

    // Start is called before the first frame update
    void Start()
    {
        movePlayer = FindObjectOfType(typeof(movimento)) as movimento;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fecharPergunta1()
    {
        painelPergunta1.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }


    public void fecharPergunta2()
    {
        painelPergunta2.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }
    public void fecharPergunta3()
    {
        painelPergunta3.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void respotaCorreta1()
    {
     
            movePlayer.contarCristais ++;
            painelPergunta1.SetActive(false);

            Time.timeScale = 1;
            Cursor.visible = false;
         
        movePlayer.numeroDeCristais.text = movePlayer.contarCristais.ToString();
        contResp++;
    }
    public void respotaCorreta2()
    {

        movePlayer.contarCristais++;
        painelPergunta2.SetActive(false);

        Time.timeScale = 1;
        Cursor.visible = false;
        
        movePlayer.numeroDeCristais.text = movePlayer.contarCristais.ToString();
        contResp++;
    }
    public void respotaCorreta3()
    {

        movePlayer.contarCristais++;
        painelPergunta3.SetActive(false);

        Time.timeScale = 1;
        Cursor.visible = false;
        
        movePlayer.numeroDeCristais.text = movePlayer.contarCristais.ToString();
        contResp++;

    }
    public void respotaErrada()
    {     
            movePlayer.contarCristais++;
            painelPergunta1.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;      
    }
  
}
