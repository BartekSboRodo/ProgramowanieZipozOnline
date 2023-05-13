using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour, IObserver
{
  //  [SerializeField]
  //  private GameObject observerGameObject;
    private SpriteRenderer sr;

    void Start()
    {        
        sr = GetComponent<SpriteRenderer>();
    }

  
    void Update()
    {
        
    }

    public void OnNotify(NotificationType type)
    {
        if(type == NotificationType.DwarfPressesX)
        {
            sr.flipX = true;
        }
        if (type == NotificationType.DwarfPressesY)
        {
            sr.flipY = true;
        }
        if (type == NotificationType.DwarfStopsX)
        {
            sr.flipX = false;
        }
        if (type == NotificationType.DwarfStopsY)
        {
            sr.flipY = false;
        }
    }
}

public interface IObserver{
    public void OnNotify(NotificationType type);
}


