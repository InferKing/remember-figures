using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickDifficulty : MonoBehaviour
{
    public void Click(GameSettings settings)
    {
        new FileManager().SaveSession(new Session(settings.Difficulty));
        SceneManager.LoadScene(1);
    }
}
