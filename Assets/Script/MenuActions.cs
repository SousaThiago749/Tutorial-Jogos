using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void IniciaJogo()
    {   
        GameController.Init();
        SceneManager.LoadScene(1);
    }

    public void VoltaMenu()
    {
        SceneManager.LoadScene(0);
    }

}
