using System;
using System.Collections;
using GameController;
using UnityEngine;

namespace WeaponBehavior {
    public class MagicStoneBehavior : WeaponController {
        public float angularVelocity;


        private void Start() {
            StartCoroutine(nameof(Surround));
        }

        IEnumerator Surround() {
            while (true) {
                transform.localPosition = Quaternion.AngleAxis(angularVelocity * Time.deltaTime,Vector3.forward) *
                                          transform.localPosition;
                yield return null;
            }
        }


        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Enemy")) {
                Debug.Log(col.gameObject.name + "get hurt");
            }
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag("Enemy")) {
                Debug.Log(col.gameObject.name + "get hurt");
            }
        }
    }
}