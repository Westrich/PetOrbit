using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Button _button;
    private List<Button> _menueButtons = new List<Button>();
    private GameManager GameManager;
    private AudioSource _audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        _audioSource = GetComponent<AudioSource>();
        _uiDocument = GetComponent<UIDocument>();
        
        _button = _uiDocument.rootVisualElement.Q("StartButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnStartClick);

        _menueButtons = _uiDocument.rootVisualElement.Query<Button>().ToList();
        foreach (var button in _menueButtons)
        {
            button.RegisterCallback<ClickEvent>(OnAllButtonClick);

        }
    }

    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnStartClick);
        foreach (var button in _menueButtons)
        {
            button.UnregisterCallback<ClickEvent>(OnAllButtonClick);
        }
    }
    private void OnAllButtonClick(ClickEvent evt)
    {
        Debug.Log("AnyButtonClicked");
        _audioSource.Play();
    }

    private void OnStartClick(ClickEvent evt)
    {
        GameManager.Instance.TryStartGame();
        Debug.Log("Clicked Start button");
    }
   
    
}
