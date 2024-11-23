using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneHourJam.Manager
{
    public class MenuManager : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
