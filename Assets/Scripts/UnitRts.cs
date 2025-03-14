using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class UnitsRTS : MonoBehaviour
{
   private GameObject selectedGameObject;

    private void Awake()
    {
        selectedGameObject= transform.Find("Selected").gameObject;
        SetSelectedVisible(false);
    }

    public void SetSelectedVisible(bool visible)
    {
       selectedGameObject.SetActive(visible); 
    } 

}
