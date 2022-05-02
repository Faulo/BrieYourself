using MyBox;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [SerializeField]
    SceneReference sceneToLoad = new();
    [SerializeField]
    GameObject UIElements;
    [SerializeField]
    GameObject buttons;
    [SerializeField]
    Button ButtonHighlightedOnStart;

    protected void Start() {
        //Force unity to select the button which will then highlight it
        ButtonHighlightedOnStart.Select();
    }

    public void PlayCredits() {
        // Debug.Log("Credits Start");
        UIElements.GetComponent<Animation>().Play();
    }

    public void StartGame() {
        // Debug.Log("Start Game Please");
        sceneToLoad.LoadScene();
    }

    public void CloseGame() {
        // Debug.Log("CLOSE THE GAME!!!!");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
}
