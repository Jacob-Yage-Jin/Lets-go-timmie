using UnityEngine;
using UnityEngine.UI;

public class EasyModeManager : MonoBehaviour
{

    public GameObject characterRed;
    public GameObject characterBlack;
    GameObject character;
    Transform groundCheckCollider;
    public LayerMask lavaLayer;
    public LayerMask goalLayer;

    GameObject resultScreen;

    void spawn()
    {
        character.transform.position = new Vector3(-7.5f, -6f, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        resultScreen = GameObject.Find("SuccessBox");
        resultScreen.SetActive(false);

        Button backButton = GameObject.Find("BackButton").GetComponent<Button>();
        backButton.onClick.AddListener(delegate {
            GameManager.Instance.LoadScene(0);
        });

        if (GameManager.Instance.settingInfo.color == "Red")
        {
            character = characterRed;
        }
        else
        {
            character = characterBlack;
        }
        groundCheckCollider = character.transform.Find("GroundCheck").transform;
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] deathColliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.05f, lavaLayer);

        if (deathColliders.Length > 0)
        {
            GameObject.Find("lose-sound").GetComponent<AudioSource>().Play();
            spawn();
        }

        Collider2D[] winColliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, .5f, goalLayer);

        if (winColliders.Length > 0)
        {
            GameObject.Find("win-sound").GetComponent<AudioSource>().Play();
            GameManager.Instance.gameInfo.gameOver = true;

            resultScreen.SetActive(true);

            Button nextButton = GameObject.Find("NextButton").GetComponent<Button>();
            nextButton.onClick.AddListener(delegate {
                GameManager.Instance.settingInfo.difficulty = "Exam";
                GameManager.Instance.StartGame();
                GameManager.Instance.LoadScene(4);
            });
        }
    }
}
