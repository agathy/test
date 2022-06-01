using UnityEngine;
using UnityEngine.Events;

namespace hgcxt
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractOnCollision2D : MonoBehaviour
    {
        public LayerMask layers;
        public UnityEvent OnCollision;
        public UnityEvent OutCollision;

        void Reset()
        {
            layers = LayerMask.NameToLayer("Everything");
        }

        void OnCollisionEnter2D (Collision2D collision)
        {


            if (layers.Contains(collision.gameObject))
            {
                
                ExecuteOnEnter(collision);
            }


        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (layers.Contains(collision.gameObject))
            {
                ExecuteOnExit(collision);
            }
        }


        protected virtual void ExecuteOnEnter(Collision2D other)
        {
            OnCollision.Invoke();
           
        }

        protected virtual void ExecuteOnExit(Collision2D other)
        {
            OutCollision.Invoke();
        }


        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "InteractionTrigger", false);
        }
    }
}