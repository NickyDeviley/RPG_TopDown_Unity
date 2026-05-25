using UnityEngine;

public class AnimalControle : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Animator anim;
    private Vector2 posJogador;

    [Header("Variaveis")]
    [SerializeField] private float velocidade;
    [SerializeField] public float raioDeteccao;

    public void DetectarJogador()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, raioDeteccao, Vector2.zero, 0, LayerMask.GetMask("Jogador"));

        if(hit.collider != null)
        {
            posJogador = (transform.position - hit.collider.transform.position).normalized;
        }
        else
        {
            posJogador = Vector2.zero;
        }
    }

    public void FugirJogador()
    {
        transform.Translate(posJogador * velocidade * Time.deltaTime);
    }
}
