using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBoardTriggerr : MonoBehaviour
{
    public GameObject openedDoor;
    public GameObject closedDoor;
    public LevelManager levelManager;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelManager.score >= 6)
        {
            closedDoor.SetActive(false);
            openedDoor.SetActive(true);
        }
    }
}
