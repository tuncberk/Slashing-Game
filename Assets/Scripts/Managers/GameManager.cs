using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public GameObject db;
    public GameObject faderObj;
    private Color fadeTransparency = new Color(0, 0, 0, .04f);
    public Image faderImg;
    public bool gameOver = false;
    private string currentScene;
    private AsyncOperation async;
    public float fadeSpeed = .02f;
    
    //public Text playerDisplay;


    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = GetComponent<GameManager>();
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
            
        }
        else
        {
            Destroy(gameObject);
        }
        //delete
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ReturnToMenu();
            GUIManager.instance.activatePauseMenu();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ScreenshotHandler.TakeScreenShot_Static(Screen.width, Screen.height);
            ScreenshotHandler.TakeScreenShot_Static(1920, 1080);
        }
    }
    public void LoadScene(string sceneName)
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        instance.StartCoroutine(Load(sceneName));
        instance.StartCoroutine(FadeOut(instance.faderObj, instance.faderImg));
    }
    IEnumerator Load(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        yield return async;
        isReturning = false;
    }
    // Get the current scene name
    public string CurrentSceneName
    {
        get
        {
            return currentScene;
        }
    }
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.name;
        instance.StartCoroutine(FadeIn(instance.faderObj, instance.faderImg));
    }
    public void ExitGame()
    {
        // If we are running in a standalone build of the game
#if UNITY_STANDALONE
        // Quit the application
        Application.Quit();
#endif

        // If we are running in the editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private bool isReturning = false;
    public void ReturnToMenu()
    {
        if (isReturning)
        {
            return;
        }

        if (CurrentSceneName != "MainMenu")
        {
            StopAllCoroutines();
            LoadScene("MainMenu");
            isReturning = true;
        }
    }
    IEnumerator FadeOut(GameObject faderObject, Image fader)
    {
        faderObject.SetActive(true);
        while (fader.color.a < 1)
        {
            fader.color += fadeTransparency;
            yield return new WaitForSeconds(fadeSpeed);
        }
        ActivateScene(); //Activate the scene when the fade ends
    }
    // Allows the scene to change once it is loaded
    public void ActivateScene()
    {
        async.allowSceneActivation = true;
    }
    // Iterate the fader transparency to 0%
    IEnumerator FadeIn(GameObject faderObject, Image fader)
    {
        while (fader.color.a > 0)
        {
            fader.color -= fadeTransparency;
            yield return new WaitForSeconds(fadeSpeed);
        }
        faderObject.SetActive(false);
    }
}
