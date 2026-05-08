using UnityEngine;

public sealed class HUDControle : MonoBehaviour
{
    public static HUDControle Hud {get; private set; }
    [SerializeField] private Animator vidaAnim;

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
}
