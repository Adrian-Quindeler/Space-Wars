using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator _anim;
    // Start is called before the first frame update
    void Start(){
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        animacao_direita();
        animacao_esquerda();
    }

    void animacao_direita(){
        if(Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow)){
            _anim.SetBool("esquerda", false);
            _anim.SetBool("direita", true);
        }
        if(Input.GetKeyUp(KeyCode.D) | Input.GetKeyUp(KeyCode.RightArrow)){
            _anim.SetBool("direita", false);
        }
    }

    void animacao_esquerda(){
        if(Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow)){
            _anim.SetBool("direita", false);
            _anim.SetBool("esquerda", true);
        }
        if(Input.GetKeyUp(KeyCode.A) | Input.GetKeyUp(KeyCode.UpArrow)){
            _anim.SetBool("esquerda", false);
        }
    }
}
