using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [SerializeField]
    int sceneToLoadBuildIndex;
    [SerializeField]
    GameObject UIElements;
    [SerializeField]
    GameObject buttons;
    [SerializeField]
    Button ButtonHighlightedOnStart;


    // Start is called before the first frame update
    void Start() {

    }

    void OnEnable() {
        ButtonHighlightedOnStart.Select(); //Force unity to select the button which will then highlight it
    }

    public void PlayCredits() {
        Debug.Log("Credits Start");
        UIElements.GetComponent<Animation>().Play();
    }

    public void StartGame() {
        Debug.Log("Start Game Please");
        SceneManager.LoadScene(sceneToLoadBuildIndex);
    }

    public void CloseGame() {
        Debug.Log("CLOSE THE GAME!!!!");
        Application.Quit();
    }
}
