using UnityEngine;

public sealed class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private PlayerController jogador;

    void Start()
    {
        jogador.camadaAnimacao[0] = jogador.Anim.GetLayerIndex("Direita");
        jogador.camadaAnimacao[1] = jogador.Anim.GetLayerIndex("Cima");
    }

    void FixedUpdate()
    {
        Movi();        
    }

    private void Movi()
    {
        Vector2 pos = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        jogador.Rig.linearVelocity = pos * jogador.Velocidade;

        AnimacaoMovi(pos.x, pos.y);
    }

    private void AnimacaoMovi(float x, float y)
    {
        if(x > 0 && y == 0)
        {
            jogador.Spr.flipX = false;

            jogador.Anim.SetLayerWeight(jogador.camadaAnimacao[1], 0);
            jogador.Anim.SetLayerWeight(jogador.camadaAnimacao[0], 1);

            jogador.Anim.SetBool(HashAnim.andando, true);
        }
        else if(x < 0 && y == 0)
        {
            jogador.Spr.flipX = true;

            jogador.Anim.SetLayerWeight(jogador.camadaAnimacao[1], 0);
            jogador.Anim.SetLayerWeight(jogador.camadaAnimacao[0], 1);

            jogador.Anim.SetBool(HashAnim.andando, true);
        }

        if(y > 0 && x == 0)
        {
            jogador.Anim.SetLayerWeight(jogador.camadaAnimacao[0], 0);
            jogador.Anim.SetLayerWeight(jogador.camadaAnimacao[1], 1);

            jogador.Anim.SetBool(HashAnim.andando, true);
        }
        else if(y < 0)
        {
            jogador.Anim.SetLayerWeight(jogador.camadaAnimacao[0], 0);
            jogador.Anim.SetLayerWeight(jogador.camadaAnimacao[1], 0);
            
            jogador.Anim.SetBool(HashAnim.andando, true);
        }

        if(x == 0 && y == 0)
        {
            jogador.Anim.SetBool(HashAnim.andando, false);            
        }

    }
}
