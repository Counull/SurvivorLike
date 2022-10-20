using System;
using System.Collections;
using GameController;
using Sirenix.OdinInspector;
using UnityEngine;

namespace WeaponBehavior {
    [ShowInInspector]
    public class MagicStoneBehavior : WeaponController {
        [ShowInInspector] public float _angularVelocity;


        private void Start() {
            StartCoroutine(nameof(Surround));
        }

        IEnumerator Surround() {
            while (true) {
                transform.localPosition = Quaternion.AngleAxis(_angularVelocity * Time.deltaTime, Vector3.forward) *
                                          transform.localPosition;
                yield return null;
            }
        }
    }
}