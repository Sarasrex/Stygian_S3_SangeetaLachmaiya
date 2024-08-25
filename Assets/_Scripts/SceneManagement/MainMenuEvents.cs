using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;
    private AudioSource _audioSource;

    private Button _playButton;
    private Button _settingsButton;
    private Button _controlsButton;
    private Button _playGameButton;
    private Button _nextButtonOne;
    private Button _nextButtonTwo;
    private Button _nextButtonThree;
    private Button _nextButtonClose;

    private Label _narrativeOne;
    private Label _narrativeTwo;
    private Label _narrativeThree;
    private Label _narrativeFour;

    private List<Button> _menuButtons = new List<Button>();

    private VisualElement _settingsPanel;
    private VisualElement _controlsPanel;
    private VisualElement _containerZeroPanel;
    private VisualElement _containerGameNarrativeOnePanel;
    private VisualElement _mainButtonContainerPanel;

    private Button _settingsBackButton;
    private Button _controlsBackButton;

    private VisualElement _currentOpenPanel;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        // Initialize buttons
        _playButton = _document.rootVisualElement.Q<Button>("Play");
        _settingsButton = _document.rootVisualElement.Q<Button>("Settings");
        _controlsButton = _document.rootVisualElement.Q<Button>("Controls");
        _playGameButton = _document.rootVisualElement.Q<Button>("PlayGame");
        _nextButtonOne = _document.rootVisualElement.Q<Button>("NextButtonOne");
        _nextButtonTwo = _document.rootVisualElement.Q<Button>("NextButtonTwo");
        _nextButtonThree = _document.rootVisualElement.Q<Button>("NextButtonThree");
        _nextButtonClose = _document.rootVisualElement.Q<Button>("NextButtonClose");

        // Register button callbacks
        RegisterButtonCallbacks();

        // Initialize panels
        _settingsPanel = _document.rootVisualElement.Q<VisualElement>("SettingsPanel");
        _controlsPanel = _document.rootVisualElement.Q<VisualElement>("ControlsPanel");
        _containerZeroPanel = _document.rootVisualElement.Q<VisualElement>("ContainerZeroPanel");
        _containerGameNarrativeOnePanel = _document.rootVisualElement.Q<VisualElement>("ContainerGameNarrativeOnePanel");
        _mainButtonContainerPanel = _document.rootVisualElement.Q<VisualElement>("MainButtonContainerPanel");

        // Initialize Labels
        _narrativeOne = _document.rootVisualElement.Q<Label>("NarrativeOne");
        _narrativeTwo = _document.rootVisualElement.Q<Label>("NarrativeTwo");
        _narrativeThree = _document.rootVisualElement.Q<Label>("NarrativeThree");
        _narrativeFour = _document.rootVisualElement.Q<Label>("NarrativeFour");

        // Initialize back buttons
        _settingsBackButton = _settingsPanel?.Q<Button>("SettingsBackButton");
        _controlsBackButton = _controlsPanel?.Q<Button>("ControlsBackButton");

        // Register back button callbacks
        RegisterBackButtonCallbacks();

        // Register all menu buttons for audio
        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        foreach (var button in _menuButtons)
        {
            button.RegisterCallback<ClickEvent>(OnAllButtonClick);
        }
    }

    private void OnDisable()
    {
        // Unregister button callbacks
        UnregisterButtonCallbacks();

        // Unregister back button callbacks
        UnregisterBackButtonCallbacks();

        // Unregister all menu button callbacks
        foreach (var button in _menuButtons)
        {
            button.UnregisterCallback<ClickEvent>(OnAllButtonClick);
        }
    }

    private void RegisterButtonCallbacks()
    {
        if (_playButton != null) _playButton.RegisterCallback<ClickEvent>(OnPlayClick);
        if (_settingsButton != null) _settingsButton.RegisterCallback<ClickEvent>(OnSettingsClick);
        if (_controlsButton != null) _controlsButton.RegisterCallback<ClickEvent>(OnControlsClick);
        if (_playGameButton != null) _playGameButton.RegisterCallback<ClickEvent>(OnPlayGameClick);
        if (_nextButtonOne != null) _nextButtonOne.RegisterCallback<ClickEvent>(OnNextButtonOneClick);
        if (_nextButtonTwo != null) _nextButtonTwo.RegisterCallback<ClickEvent>(OnNextButtonTwoClick);
        if (_nextButtonThree != null) _nextButtonThree.RegisterCallback<ClickEvent>(OnNextButtonThreeClick);
        if (_nextButtonClose != null) _nextButtonClose.RegisterCallback<ClickEvent>(OnNextButtonCloseClick);
    }

    private void UnregisterButtonCallbacks()
    {
        if (_playButton != null) _playButton.UnregisterCallback<ClickEvent>(OnPlayClick);
        if (_settingsButton != null) _settingsButton.UnregisterCallback<ClickEvent>(OnSettingsClick);
        if (_controlsButton != null) _controlsButton.UnregisterCallback<ClickEvent>(OnControlsClick);
        if (_playGameButton != null) _playGameButton.UnregisterCallback<ClickEvent>(OnPlayGameClick);
        if (_nextButtonOne != null) _nextButtonOne.UnregisterCallback<ClickEvent>(OnNextButtonOneClick);
        if (_nextButtonTwo != null) _nextButtonTwo.UnregisterCallback<ClickEvent>(OnNextButtonTwoClick);
        if (_nextButtonThree != null) _nextButtonThree.UnregisterCallback<ClickEvent>(OnNextButtonThreeClick);
        if (_nextButtonClose != null) _nextButtonClose.UnregisterCallback<ClickEvent>(OnNextButtonCloseClick);
    }

    private void RegisterBackButtonCallbacks()
    {
        if (_settingsBackButton != null) _settingsBackButton.RegisterCallback<ClickEvent>(OnBackButtonClick);
        if (_controlsBackButton != null) _controlsBackButton.RegisterCallback<ClickEvent>(OnBackButtonClick);
    }

    private void UnregisterBackButtonCallbacks()
    {
        if (_settingsBackButton != null) _settingsBackButton.UnregisterCallback<ClickEvent>(OnBackButtonClick);
        if (_controlsBackButton != null) _controlsBackButton.UnregisterCallback<ClickEvent>(OnBackButtonClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("You pressed the Start Game Button");
        _containerZeroPanel?.AddToClassList("moveContainerZeroOutOfFrame");
        _containerGameNarrativeOnePanel?.AddToClassList("moveContainerGameNarrativeOneIntoFrame");
    }

    private void OnNextButtonOneClick(ClickEvent evt)
    {
        Debug.Log("You pressed the first next Button");

        // Update narrative label
        if (_narrativeOne != null) // Ensure label is not null
        {
            _narrativeOne.AddToClassList("makeInvisible"); // Add class to make invisible
        }
        if (_narrativeTwo != null) // Ensure label is not null
        {
            _narrativeTwo.AddToClassList("insertTextBoxTwo"); // Add class to show next narrative
        }

    }

    private void OnNextButtonTwoClick(ClickEvent evt)
    {
        // Update narrative label
        if (_narrativeTwo != null) // Ensure label is not null
        {
            _narrativeTwo.AddToClassList("makeInvisible"); // Add class to make invisible
        }
        if (_narrativeThree != null) // Ensure label is not null
        {
            _narrativeThree.AddToClassList("insertTextBoxThree"); // Add class to show next narrative
        }

    }

    private void OnNextButtonThreeClick(ClickEvent evt)
    {
        // Update narrative label
        if (_narrativeThree != null) // Ensure label is not null
        {
            _narrativeThree.AddToClassList("makeInvisible"); // Add class to make invisible
        }
        if (_narrativeFour != null) // Ensure label is not null
        {
            _narrativeFour.AddToClassList("insertTextBoxFour"); // Add class to show next narrative
        }
    }

    private void OnNextButtonCloseClick(ClickEvent evt)
    {
        Debug.Log("You pressed the next close Button");

        // Move main button container into view
        if (_mainButtonContainerPanel != null) // Ensure panel is not null
        {
            _mainButtonContainerPanel.AddToClassList("moveMainMenuPanelIntoFrame"); // Add class to move main menu into frame
            Debug.Log("Class 'moveMainMenuPanelIntoFrame' added to _mainButtonContainerPanel");

            _containerGameNarrativeOnePanel.RemoveFromClassList("moveContainerGameNarrativeOneIntoFrame");
        }
        else
        {
            Debug.LogError("_mainButtonContainerPanel is null");
        }
    }

    private void OnPlayClick(ClickEvent evt)
    {
        Debug.Log("You pressed the Play Button");
        SceneManager.LoadScene("PlayerSelection");
    }

    private void OnSettingsClick(ClickEvent evt)
    {
        Debug.Log("You pressed the Settings Button");
        OpenPanel(_settingsPanel, "moveSettingsPanelIntoFrame");
    }

    private void OnControlsClick(ClickEvent evt)
    {
        Debug.Log("You pressed the Controls Button");
        OpenPanel(_controlsPanel, "moveControlsPanelIntoFrame");
    }

    private void OnBackButtonClick(ClickEvent evt)
    {
        Debug.Log("You pressed the Back Button");
        CloseCurrentOpenPanel();
    }

    private void OpenPanel(VisualElement panel, string className)
    {
        CloseCurrentOpenPanel();
        if (panel != null)
        {
            panel.AddToClassList(className);
            _currentOpenPanel = panel;
        }
    }

    private void CloseCurrentOpenPanel()
    {
        if (_currentOpenPanel != null)
        {
            _currentOpenPanel.RemoveFromClassList("moveSettingsPanelIntoFrame");
            _currentOpenPanel.RemoveFromClassList("moveControlsPanelIntoFrame");
            _currentOpenPanel.RemoveFromClassList("moveContainerZeroOutOfFrame");
            _currentOpenPanel = null;
        }
    }

    private void OnAllButtonClick(ClickEvent evt)
    {
        _audioSource?.Play();
    }
}