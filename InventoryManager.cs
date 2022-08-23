using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{

    [SerializeField]
    Text stonesCountText;

    public List<GameObject> stonesList = new List<GameObject>();

    public void AddToList(GameObject stone)
    {
        stonesList.Add(stone);
        stonesCountText.text = "X" + " " + stonesList.Count.ToString();
        
        
    }

    public void RemoveFromList()
    {
        stonesList.RemoveAt(stonesList.Count - 1);
        stonesCountText.text = "X" + " " + stonesList.Count.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
