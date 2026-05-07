using System.Collections;
using UnityEngine;

public sealed class JogadorAtaque : MonoBehaviour
{
    [SerializeField] private PlayerController jogador;

    void Update()
    {
        DirecaoAtaque();

        StartCoroutine(Atacando());
    }

    private IEnumerator Atacando()
    {
        if (Input.GetMouseButtonDown(0) && !jogador.EstaAtacando)
        {
            jogador.EstaAtacando = true;
            
            jogador.Anim.SetTrigger(HashAnim.atacando);

            yield return new WaitForSeconds(.46f);

            jogador.EstaAtacando = false;
        }
    }

    private void DirecaoAtaque()
    {
        if(jogador.Rig.linearVelocityX > 0)
        {
            jogador.AtaqueHit.offset = new(0.82f, -0.448f);
            jogador.AtaqueHit.size = new(1.03f, 0.6f);
        }
        else if(jogador.Rig.linearVelocityX < 0)
        {
            jogador.AtaqueHit.offset = new(-0.82f, -0.448f);
            jogador.AtaqueHit.size = new(1.03f, 0.6f);
        }

        if(jogador.Rig.linearVelocityY > 0)
        {
            jogador.AtaqueHit.offset = new(-0.01f, 0.52f);            
            jogador.AtaqueHit.size = new(0.6f, 1.03f);
        }
        else if(jogador.Rig.linearVelocityY < 0)
        {
            jogador.AtaqueHit.offset = new(-0.01f, -1.18f);                        
            jogador.AtaqueHit.size = new(0.6f, 1.03f);
        }
    }
}
