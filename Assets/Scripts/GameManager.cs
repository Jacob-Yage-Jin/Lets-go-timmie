using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private String activeScene;

    public PlayerInfo playerInfo;

    public SettingInfo settingInfo;

    public GameInfo gameInfo;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerInfo = new PlayerInfo();
            settingInfo = new SettingInfo();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        gameInfo = new GameInfo();
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
