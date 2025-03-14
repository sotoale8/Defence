using System.Collections.Generic;
using UnityEngine;

public class RtsController : MonoBehaviour
{   
    Vector3  mouseScreenPos;
    Vector3 mouseWorldPos;

    Vector3 startPosition;
    Vector3 finalPosition;

    List<UnitsRTS> selectedUnits;

    

    void Start()
    {
        selectedUnits= new List<UnitsRTS>();
        print("prueba");
        print("prueba");
    }

    void Update()
    {
          if (Input.GetMouseButtonDown(0))
          {
            startPosition= GetMouseWorldPosition();
            
          }  
          if (Input.GetMouseButtonUp(0))
          { 
           
            finalPosition= GetMouseWorldPosition();
           

            Collider2D[] collidersArray = Physics2D.OverlapAreaAll(startPosition,finalPosition);

             foreach (UnitsRTS unitsRTS in selectedUnits)
             {
                  unitsRTS.SetSelectedVisible(false);  
             }

            selectedUnits.Clear();
            foreach (Collider2D collider in collidersArray)
            {
               if(collider.GetComponent<UnitsRTS>()!=null)
               {    
                    collider.GetComponent<UnitsRTS>().SetSelectedVisible(true);
                    selectedUnits.Add(collider.GetComponent<UnitsRTS>());
               }
             Debug.Log(collider.name);
            }
          }  
    }

    public Vector3 GetMouseWorldPosition()
    {
        mouseScreenPos=Input.mousePosition;
        mouseWorldPos=Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z=0f;
        return mouseWorldPos;

    }
}
