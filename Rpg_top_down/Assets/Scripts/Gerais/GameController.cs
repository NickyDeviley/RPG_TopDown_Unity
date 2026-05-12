using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameController : MonoBehaviour
{
    public static GameController game;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            jogoPausado = !jogoPausado;

            HUDControle.Hud.MenuPausa();
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
