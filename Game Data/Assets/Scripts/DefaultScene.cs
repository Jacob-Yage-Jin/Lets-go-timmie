using UnityEngine;
using UnityEngine.UI;

public class DefaultScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(delegate {
            GameManager.Instance.QuitGame();
        });
        Button backButton = GameObject.Find("BackButton").GetComponent<Button>();
        backButton.onClick.AddListener(delegate {
            GameManager.Instance.LoadScene(0);
        });
    }
}
