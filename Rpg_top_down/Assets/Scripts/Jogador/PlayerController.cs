using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    //Componentes
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private BoxCollider2D ataqueHit;

    //Variaveis privadas
    [Header("Variaveis")]
    [SerializeField] private float velocidade;

    private bool estaAtacando;

    //-------------------------Propriedades---------------------------------------------
    
    //Propriedades de Componentes
    public Rigidbody2D Rig{get => rig; }
    public Animator Anim {get => anim; }
    public SpriteRenderer Spr{get => spr; set => spr = value; }
    public BoxCollider2D AtaqueHit {get => ataqueHit; set => ataqueHit = value; }

    //Propridades de variaveis
    public float Velocidade{ get => velocidade; }

    public bool EstaAtacando {get => estaAtacando; set => estaAtacando = value; }

    //Arrays
    public int[] camadaAnimacao = new int[2];
}
