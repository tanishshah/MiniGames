using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
    }

    // Update is called once per frame
    public void StartGame()
    {
        Instantiate(bird, new Vector3(2.0f, 1.0f, 0.0f), Quaternion.identity);
        startScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
