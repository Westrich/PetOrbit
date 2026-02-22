using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
 private static GameManager _instance;
 
 public static GameManager Instance {get{return _instance;}}
 // [SerializeField] private GameObject _loadingBar;
 private void Awake()
 {
   if (_instance != null && _instance != this)
   {
    Destroy(this.gameObject);
   }
   else
   {
    _instance = this;
   }
   
   LoadMainMenu();
 }

 
 public void TryStartGame()
 {
  StartGame();
 }

 private void LoadMainMenu()
 {
  AddScene("MainMenu");
 }
 
 private void StartGame()
 {
   AddScene("PetShelter");
   UnloadScene("MainMenu");
 }

 #region SceneLoading
 
 private void UnloadScene(int sceneIndex)
  {
   SceneManager.UnloadSceneAsync(sceneIndex);
  }
  private void UnloadScene(string sceneName)
  {
   SceneManager.UnloadSceneAsync(sceneName);
  }
  private void LoadScene(string sceneName)
  {
   SceneManager.LoadScene(sceneName);
  }
  private void LoadScene(int sceneIndex)
  {
   SceneManager.LoadScene(sceneIndex);
  }
  private void AddScene(string sceneName)
  {
   SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
  }
  
  private void AddScene(int sceneIndex)
  {
   SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Additive);
  }
 #endregion
}
