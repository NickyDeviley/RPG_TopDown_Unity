using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public sealed class GameController : MonoBehaviour
{
    public static GameController game;

    //Variaveis para o controlar o dia e noite
    [SerializeField] private Light2D luzGlobal;
    [SerializeField] private bool dia;
    [SerializeField] private float duracaoDia;

    private bool jogoPausado;

    //Propriedade
    public bool JogoPausado {get => jogoPausado; }

    void Awake()
    {
        if(game == null)
        {
            game = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(DiaNoite());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            jogoPausado = !jogoPausado;

            HUDControle.Hud.MenuPausa();
        }

        //StartCoroutine(DiaNoite());
    }

    private IEnumerator DiaNoite()
    {
        if (dia)
        {
            luzGlobal.intensity -= .03f;

            yield return new WaitForSeconds(duracaoDia);

            StartCoroutine(DiaNoite());
        }
        else
        {
            luzGlobal.intensity += .03f;

            yield return new WaitForSeconds(duracaoDia);

            StartCoroutine(DiaNoite());
        }

        if(luzGlobal.intensity <= 0.4f)
        {
            dia = false;
        }
        else if(luzGlobal.intensity >= 1f)
        {
            dia = true;
        }
    }

    public void MudarFase()
    {
        SceneManager.LoadScene(1);
    }

    public void RetomarJogo()
    {
        jogoPausado = false;
        HUDControle.Hud.MenuPausa();
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
