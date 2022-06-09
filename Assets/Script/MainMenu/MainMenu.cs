using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame ()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void ReseumeGame()
    {
        bool runComplete = PlayerPrefs.GetInt("Run") > 0;
        bool villageComplete = PlayerPrefs.GetInt("Village") > 0;
        bool pyramidComplete = PlayerPrefs.GetInt("Pyramid") > 0;

        string scene = "Temple";
        
        if(runComplete && villageComplete && pyramidComplete)
        {
            scene = "Ending";
        }else if (runComplete || villageComplete || pyramidComplete)
        {
            scene = "TempleMidGame";
        }

        SceneManager.LoadScene(scene);
    }
}
