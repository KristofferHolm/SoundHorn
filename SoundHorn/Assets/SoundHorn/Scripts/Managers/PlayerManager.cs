using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseClasses;

namespace Managers
{
    public class PlayerManager : BaseSingleton<PlayerManager> {

        public float MovementSpeed;
        public float MouseSensitivity;
        public float JoystickSensitivity;
        public float TopDownRotationLock = 10;
        public float Footstep = 0.1f;
        public bool LockMovement = false;
        public bool InvertMouse = false;
        //references

        public GameObject Player;
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
        }
    }
}