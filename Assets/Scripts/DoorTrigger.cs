using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
   [SerializeField]
   private DoorSetActive door;

   private void Update() {
       if (Input.GetKeyDown(KeyCode.F)) {
           door.OpenDoor();
       }
       if (Input.GetKeyDown(KeyCode.G)) {
           door.CloseDoor();
       }
   }
}
