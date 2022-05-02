using UnityEngine;
using UnityEngine.SceneManagement;

namespace BrieYourself {
    public class WinCon : MonoBehaviour {
        protected void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
