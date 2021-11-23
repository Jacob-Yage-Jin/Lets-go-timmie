using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button aboutButton = GameObject.Find("AboutButton").GetComponent<Button>();
        aboutButton.onClick.AddListener(delegate {
            GameManager.Instance.LoadScene(1);
        });

        Button play2DButton = GameObject.Find("Play2DButton").GetComponent<Button>();
        play2DButton.onClick.AddListener(delegate {
            GameManager.Instance.LoadScene(2);
        });

        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(delegate {
            GameManager.Instance.QuitGame();
        });
    }
}
