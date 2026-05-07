using UnityEngine;

public class InimigoControle : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Animator anim;
    private Collider2D boxJogador;

    [Header("Atributos")]
    [SerializeField] private float velocidade;

    public float raioDeDeteccao;


    public void VerificarJogador()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, raioDeDeteccao, Vector2.zero, 0, LayerMask.GetMask("Jogador"));

        if(hit.collider != null)
        {
            boxJogador = hit.collider;
        }
        else
        {
            boxJogador = null;
        }
    }

    public void MoviInimigo()
    {
        if(boxJogador != null)
        {
            anim.SetBool(HashAnim.andando, true);

            transform.position = Vector2.MoveTowards(transform.position, boxJogador.transform.position, velocidade);            
        }
        else
        {
            anim.SetBool(HashAnim.andando, false);            
        }
    }
}
