using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace BrieYourself
{
    public class ArtificialInput : MonoBehaviour {
        [SerializeField] float _hostileDetectionRadius;
        [SerializeField] LayerMask _whatIsHostile;
        [SerializeField] Animator _attachedAnimator;
        Transform _closestHostile;
        
        protected void FixedUpdate()
        { 
            DetectHostiles();
        }
        
        void DetectHostiles()
        {
            var hits = Physics.SphereCastAll(this.transform.position, _hostileDetectionRadius,
                transform.forward, _hostileDetectionRadius, _whatIsHostile);
            
            foreach(var hit in hits) {
                if (!_closestHostile) {
                    _closestHostile = hit.transform;
                }
                float hitDistance = Mathf.Abs(Vector3.Distance(transform.position, hit.transform.position));
                float closestHostileDistance = Mathf.Abs(Vector3.Distance(transform.position, _closestHostile.position));
                if (hitDistance < closestHostileDistance) {
                    _closestHostile = hit.transform;
                }
                closestHostileDistance = Mathf.Abs(Vector3.Distance(transform.position, _closestHostile.position));
                Debug.Log(closestHostileDistance);
                _attachedAnimator.SetFloat("closestHostileDistance", closestHostileDistance);
            }
        }
        protected void OnValidate() {
            if (!_attachedAnimator) {
                TryGetComponent(out _attachedAnimator);
            }
        }
    }
}
