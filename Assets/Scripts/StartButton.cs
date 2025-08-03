using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void SpielStarten()
    {
        SceneManager.LoadScene("Zelda Scene");
    }
}
