using UnityEngine;

public sealed class HUDControle : MonoBehaviour
{
    public static HUDControle Hud {get; private set; }
    [SerializeField] private Animator vidaAnim;
    [SerializeField] private Transform hudPausa;

    void Awake()
    {
        if(Hud == null)
        {
            Hud = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AtualizarVida(byte vida)
    {
        vidaAnim.SetInteger(HashAnim.vida, vida);
    }

    public void MenuPausa()
    {
        hudPausa.gameObject.SetActive(GameController.game.JogoPausado);
    }
}
