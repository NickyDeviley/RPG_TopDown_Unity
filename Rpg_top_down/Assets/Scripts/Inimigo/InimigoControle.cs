using System.Collections;
using UnityEngine;

public class InimigoControle : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Animator anim;

    [SerializeField] private Transform[] lugarAndar;
    private Transform lugarAtual;

    private Collider2D boxJogador;

    [Header("Atributos")]
    [SerializeField] private byte vida;
    [SerializeField] private float velocidade;

    [SerializeField] private float raioDeDeteccao;

    private bool danoLevado;
    private bool proximoLugar;


    //Propriedade
    public float RaioDeDeteccao {get => raioDeDeteccao; }


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
        if(boxJogador != null && !danoLevado)
        {
            anim.SetBool(HashAnim.andando, true);

            transform.position = Vector2.MoveTowards(transform.position, boxJogador.transform.position, velocidade);            
        }
        else
        {
            StartCoroutine(AndarRedor());
        }
    }

    private IEnumerator AndarRedor()
    {
        if (!proximoLugar)
        {
            proximoLugar = true;

            lugarAtual = lugarAndar[Random.Range(0, lugarAndar.Length)];

            anim.SetBool(HashAnim.andando, true);

            yield return new WaitForSeconds(5f);

            proximoLugar = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, lugarAtual.position, velocidade);

        if(transform.position == lugarAtual.position)
        {
            anim.SetBool(HashAnim.andando, false);
        }
    }

    
    public void ReceberDano()
    {
        StartCoroutine(ControleDano());
    }

    private IEnumerator ControleDano()
    {
        if (!danoLevado)
        {
            danoLevado = true;

            vida--;

            anim.SetTrigger(HashAnim.receberDano);

            if(vida <= 0)
            {
                anim.SetTrigger(HashAnim.morto);

                yield return new WaitForSeconds(.45f);

                Destroy(gameObject);
            }

            yield return new WaitForSeconds(.5f);

            danoLevado = false;
        }
    }
}
