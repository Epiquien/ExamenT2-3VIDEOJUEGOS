using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text vidasText;
    private int _score = 0;
    private int _vidas = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Puntaje: " + _score;
        vidasText.text = "Vidas: " + _vidas;
    }

    // Update is called once per frame
   
    
    public int GetScore()
    {
        return _score;
    }
    
    public void PlusScore(int score)
    {
        _score += score;
        scoreText.text = "Puntaje: " + _score;
    }

    public void DisminuirVidas(int vidas)
    {
        _vidas -= vidas;
        vidasText.text = "Vidas:" + _vidas;
    }
}
