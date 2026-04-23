using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    //Componentes
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spr;

    //Variaveis privadas
    [Header("Variaveis")]
    [SerializeField] private float velocidade;
    
    //Propriedades de Componentes
    public Rigidbody2D Rig{get => rig; }
    public Animator Anim {get => anim; }
    public SpriteRenderer Spr{get => spr; set => spr = value; }

    //Propridades de variaveis
    public float Velocidade{ get => velocidade; }

    //Arrays
    public int[] camadaAnimacao = new int[2];
}
