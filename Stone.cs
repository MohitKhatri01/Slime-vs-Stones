using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    public GameObject PickupPopup;
    
    public Transform popupPosition;
    
    GameObject popup = null;
    bool popupInstantiated = false;
    bool popupDestroyAllow = false;
    private void IsAllowToCollect()
    {
        if (Physics2D.OverlapCircle(transform.position,
            .3f, LayerMask.GetMask("Player")))
        {
            if (!popupInstantiated)
            {
                popup = Instantiate<GameObject>(
                    PickupPopup,
                popupPosition.position
                    , Quaternion.identity);
                popup.transform.parent = transform;
                popupInstantiated = true;
                popupDestroyAllow = true;
            }
        }
        else
        {
            if(popupInstantiated&&popupDestroyAllow)
            {
                Destroy(popup);
                popupInstantiated = false;
                popupDestroyAllow = false;
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
     IsAllowToCollect();
       
    }
}
