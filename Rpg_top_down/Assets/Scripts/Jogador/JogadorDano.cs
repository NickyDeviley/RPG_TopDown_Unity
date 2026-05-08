using UnityEngine;

public sealed class JogadorDano : MonoBehaviour
{
    [SerializeField] private PlayerController jogador;

    public void ReceberDano()
    {
        jogador.Vida--;
        
        if(jogador.Vida > 0)
        {
            HUDControle.Hud.AtualizarVida(jogador.Vida);
        }
        else if(jogador.Vida == 0)
        {
            HUDControle.Hud.AtualizarVida(jogador.Vida);

            Debug.Log("Game Over!");
        }
    }
}
