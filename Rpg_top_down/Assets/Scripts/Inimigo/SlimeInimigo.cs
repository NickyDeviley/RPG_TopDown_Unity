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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioDeDeteccao);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jogador");
        }
    }
}
