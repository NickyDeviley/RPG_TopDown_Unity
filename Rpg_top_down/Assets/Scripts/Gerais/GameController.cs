using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameController : MonoBehaviour
{
    public static GameController game;

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

    public void MudarFase()
    {
        SceneManager.LoadScene(1);
    }

}
