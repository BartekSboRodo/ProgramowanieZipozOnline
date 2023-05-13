using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface MainObjectInterface
{
    void Movement();   
    void OnCollisionEnter2D(Collision2D coll);
    void OnCollisionExit2D(Collision2D coll);
}

    

    public class MainObject : MonoBehaviour
    {
    bool isMoving;
    [SerializeField]
    private float movSpeed = 3;

    private List<Observer> observers = new List<Observer>();

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.X))
        {
            Notify(NotificationType.DwarfPressesX);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Notify(NotificationType.DwarfPressesY);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Notify(NotificationType.DwarfStopsX);
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            Notify(NotificationType.DwarfStopsY);
        }
    }

    public void Notify(NotificationType type)
    {
        foreach (Observer obj in observers)
        {
            obj.OnNotify(type);
        }
    }

   

    public void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("kolizja");

        if (!observers.Contains(coll.gameObject.GetComponent<Observer>()))
        {
            Debug.Log("dodany ten");
            observers.Add(coll.gameObject.GetComponent<Observer>());
        }        
    }

  //  public void OnTriggerExit2D(Collider2D coll)
 //   {
 //       if (observers.Contains(coll.gameObject.GetComponent<Observer>()))
 //       {
 //           observers.Remove(coll.gameObject.GetComponent<Observer>());
 //           Debug.Log("usuniety ten");
  //      }
  //  }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, movSpeed, 0) * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -movSpeed, 0) * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-movSpeed, 0, 0) * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
           transform.position += new Vector3(movSpeed, 0, 0) * Time.deltaTime;
            isMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isMoving = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isMoving = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {           
            isMoving = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {          
            isMoving = false;
        }
    }
}



public enum NotificationType
{
    DwarfPressesX,
    DwarfPressesY,
    DwarfStopsX,
    DwarfStopsY
}
