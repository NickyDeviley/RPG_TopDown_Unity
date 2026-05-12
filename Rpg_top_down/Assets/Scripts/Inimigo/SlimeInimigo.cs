using UnityEngine;

public sealed class SlimeInimigo : InimigoControle
{
    void FixedUpdate()
    {
        VerificarJogador();
    }

    void Update()
    {
        MoviInimigo();
    }

    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RaioDeDeteccao);
    }
    #endif

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<JogadorDano>().ReceberDano();
        }
    }
}
