using UnityEngine;

public class inventoryUi : MonoBehaviour
{
   // Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        //inventory = Inventory.instance;
           // inventory.onItemChangedCallback += UpdateUI;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        Debug.Log("UPDATING UI");
    } 
}
