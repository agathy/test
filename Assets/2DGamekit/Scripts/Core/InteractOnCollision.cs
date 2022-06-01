using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace hgcxt
{
    [RequireComponent(typeof(Collider))]
    public class InteractOnCollision : MonoBehaviour
    {
        public LayerMask layers;
        public UnityEvent OnCollision;
        public UnityEvent OutCollision;

        void Reset()
        {
            layers = LayerMask.NameToLayer("Everything");
        }

        void OnCollisionEnter(Collision c)
        {
            if (0 != (layers.value & 1 << c.transform.gameObject.layer))
            {
                OnCollision.Invoke();
            }
        }

        void OnCollisionExit(Collision c)
        {
            if (0 != (layers.value & 1 << c.transform.gameObject.layer))
            {
                OutCollision.Invoke();
            }
        }
        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "InteractionTrigger", false);
        }
    }
}