using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseClasses
{
    public class nVector : MonoBehaviour{

        public static Vector3 up;
        public static Vector3 one;
        public static Vector3 zero;
        private void Awake()
        {
            up = Vector3.up;
            one = Vector3.one;
            zero = Vector3.zero;
        }
    }
}
