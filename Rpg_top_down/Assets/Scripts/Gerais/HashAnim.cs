using UnityEngine;

public sealed class HashAnim : MonoBehaviour
{
    //Hash Animator
    public static int andando = Animator.StringToHash("andando");
    public static int atacando = Animator.StringToHash("atacando");
    public static int vida = Animator.StringToHash("vida");
    public static int receberDano = Animator.StringToHash("dano");
    public static int morto = Animator.StringToHash("morto");
}
