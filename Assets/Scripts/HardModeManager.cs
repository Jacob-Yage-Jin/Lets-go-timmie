using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HardModeManager : MonoBehaviour
{

    public GameObject characterRed;
    public GameObject characterBlack;
    GameObject character;
    Transform groundCheckCollider;
    Transform headCheckCollider;
    public LayerMask lavaLayer;
    public LayerMask goalLayer;
    public LayerMask headTrapLayer;
    public LayerMask flagLayer;

    bool hideFlagCalled;

    GameObject resultScreen;
    GameObject failScreen;

    void spawn()
    {
        GameObject.Find("HeadTrap").GetComponent<Renderer>().enabled = false;
        GameObject.Find("pole").transform.Find("just-flag").gameObject.SetActive(true);
        hideFlagCalled = false;
        character.transform.position = new Vector3(-7.5f, -6f, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        resultScreen = GameObject.Find("SuccessBox");
        resultScreen.SetActive(false);
        failScreen = GameObject.Find("FailBox");
        failScreen.SetActive(false);

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
        headCheckCollider = character.transform.Find("HeadCheck").transform;

        spawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] deathColliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.5f, lavaLayer);

        if (deathColliders.Length > 0)
        {
            failScreen.SetActive(true);
            GameManager.Instance.gameInfo.gameOver = true;

            Button retryButton = GameObject.Find("RetryButton").GetComponent<Button>();
            retryButton.onClick.AddListener(delegate {
                failScreen.SetActive(false);
                GameManager.Instance.gameInfo.gameOver = false;
                spawn();
            });
        }

        Collider2D[] winColliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.5f, goalLayer);

        if (winColliders.Length > 0)
        {
            resultScreen.SetActive(true);
            GameManager.Instance.gameInfo.gameOver = true;

            Button nextButton = GameObject.Find("NextButton").GetComponent<Button>();
            nextButton.onClick.AddListener(delegate {
                GameManager.Instance.LoadScene(0);
            });
        }

        Collider2D[] headTrapColliders = Physics2D.OverlapCircleAll(headCheckCollider.position, 0.5f, headTrapLayer);

        if (headTrapColliders.Length > 0)
        {
            GameObject.Find("HeadTrap").GetComponent<Renderer>().enabled = true;
        }

        Collider2D[] flagColliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.5f, flagLayer);

        if (flagColliders.Length > 0 && hideFlagCalled == false)
        {
            hideFlagCalled = true;
            StartCoroutine(hideFlag());
        }
    }

    IEnumerator hideFlag()
    {
        yield return new WaitForSeconds(0.3f);

        GameObject.Find("just-flag").SetActive(false);
    }
}
