using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    Button exitButton;
    Button backButton;
    Button playButton;

    InputField lastNameInput;
    Dropdown colorDropdown;
    Dropdown difficultyDropdown;

    void Start()
    {
        exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(delegate {
            GameManager.Instance.QuitGame();
        });
        backButton = GameObject.Find("BackButton").GetComponent<Button>();
        backButton.onClick.AddListener(delegate {
            GameManager.Instance.LoadScene(0);
        });
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(delegate {
            GameManager.Instance.StartGame();
            GameManager.Instance.LoadScene(3);
        });

        lastNameInput = GameObject.Find("LastName").GetComponent<InputField>();
        lastNameInput.text = GameManager.Instance.playerInfo.lastName;
        lastNameInput.onValueChanged.AddListener(delegate {
            onNameChange();
        });

        colorDropdown = GameObject.Find("ColorDropdown").GetComponent<Dropdown>();
        colorDropdown.value = colorDropdown.options.FindIndex((option) => {
            return option.text.Equals(GameManager.Instance.settingInfo.color);
        });
        colorDropdown.onValueChanged.AddListener(delegate {
            onColorChange();
        });

        difficultyDropdown = GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>();
        difficultyDropdown.value = difficultyDropdown.options.FindIndex((option) => {
            return option.text.Equals(GameManager.Instance.settingInfo.difficulty);
        });
        difficultyDropdown.onValueChanged.AddListener(delegate {
            onDifficultyChange();
        });
    }

    private void onNameChange()
    {
        GameManager.Instance.playerInfo.lastName = lastNameInput.text;
    }

    private void onColorChange()
    {
        GameManager.Instance.settingInfo.color = colorDropdown.options[colorDropdown.value].text;
    }

    private void onDifficultyChange()
    {
        GameManager.Instance.settingInfo.difficulty = difficultyDropdown.options[difficultyDropdown.value].text;
    }
}
