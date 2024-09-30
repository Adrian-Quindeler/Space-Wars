using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public Sprite[] vidas = new Sprite[4];
    public TextMeshProUGUI pontuacao;
    public Image imagemVidas;
    public Image titulo;
    int _pontuacao = 0;

    public void AtualizarVidas(int vidaAtual){
        imagemVidas.sprite = vidas[vidaAtual];
    }

    public void AtualizarPontuação(){
        _pontuacao += 1;
        pontuacao.SetText("Pontuação: " + _pontuacao);
    }

    public void ResetarPontuação(){
        _pontuacao += 0;
        pontuacao.SetText("Pontuação: " + _pontuacao);
    }

    public void RemoverTitulo(){
        titulo.gameObject.SetActive(false);
        ResetarPontuação();
    }

    public void AtivarTitulo(){
        titulo.gameObject.SetActive(true);
    }
}
