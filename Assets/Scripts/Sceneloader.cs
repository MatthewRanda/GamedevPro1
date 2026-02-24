using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadWave1()
    {
        SceneManager.LoadScene("Wave1");
    }
}