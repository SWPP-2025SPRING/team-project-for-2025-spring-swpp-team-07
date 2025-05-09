using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadScene(string sceneName)
    {
=======
public class SceneManager : MonoBehaviour {
    public void loadScene(string sceneName) {
>>>>>>> main
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
