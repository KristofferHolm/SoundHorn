using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using BaseClasses;

namespace script
{

    public class PlayerController : MonoBehaviour {


        public static Transform Cam;

        private void Awake()
        {
            Cam = Camera.main.transform; 
        }
        private void Update()
        {
            transform.Translate(Movement());
            transform.Rotate(Look());

#if UNITY_EDITOR

            if (Input.GetKey(KeyCode.Q))
                print(PlayerManager.Instance.Player.transform.localScale.y);



            if (Input.GetKey(KeyCode.LeftShift))
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
#endif
        }

        private Vector3 Look()
        {
            if (PlayerManager.Instance.LockMovement)
                return nVector.zero;
            var hor = Input.GetAxis("Mouse X");
            var ver = Input.GetAxis("Mouse Y");
            if (PlayerManager.Instance.InvertMouse)
                ver *= -1;
            Cam.Rotate(new Vector3(ver, 0, 0) * PlayerManager.Instance.MouseSensitivity * Time.deltaTime);
            return new Vector3(0, hor, 0) * PlayerManager.Instance.MouseSensitivity * Time.deltaTime;
        }

        private Vector3 Movement()
        {
            if (PlayerManager.Instance.LockMovement)
                return nVector.zero;
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");
            return new Vector3(hor, 0, ver).normalized * PlayerManager.Instance.MovementSpeed * Time.deltaTime;
        }

    }
}
