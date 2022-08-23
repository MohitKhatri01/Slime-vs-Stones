using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{

    public void nApplicationQuit()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
