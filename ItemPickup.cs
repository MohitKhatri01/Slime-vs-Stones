using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    
   
    public void Pickup()
    {
        FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>().AddToList(this.gameObject);
        Destroy(gameObject);
    }

    
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.Find("Popup(Clone)"))
        {

            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Pickup();
            }
        }
    }
}
