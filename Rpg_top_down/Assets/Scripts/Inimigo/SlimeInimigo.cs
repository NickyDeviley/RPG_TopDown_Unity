using UnityEngine;

public sealed class SlimeInimigo : InimigoControle
{
    void FixedUpdate()
    {
        if(!GameController.game.JogoPausado)
            VerificarJogador();
    }

    void Update()
    {
        if(!GameController.game.JogoPausado)
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
