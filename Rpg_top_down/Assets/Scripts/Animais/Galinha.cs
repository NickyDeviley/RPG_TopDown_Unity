using UnityEngine;

public sealed class Galinha : AnimalControle
{
    void FixedUpdate()
    {
        DetectarJogador();
    }

    void Update()
    {
        FugirJogador();
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioDeteccao);
    }
    #endif
}
