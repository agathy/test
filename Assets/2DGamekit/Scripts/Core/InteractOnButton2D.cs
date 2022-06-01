using UnityEngine;
using UnityEngine.Events;

namespace hgcxt
{
    public class InteractOnButton2D : InteractOnCollision2D
    {
        public UnityEvent OnButtonPressDown;
        public UnityEvent OnButtonPressUp;
        public UnityEvent OnSkillPressDown;

        bool m_CanExecuteButtons;

        protected override void ExecuteOnEnter(Collision2D other)
        {
         
            m_CanExecuteButtons = true;
          
            OnCollision.Invoke ();
            
        }
      
        protected override void ExecuteOnExit(Collision2D other)
        {
           
            m_CanExecuteButtons = false;
            OutCollision.Invoke();
           // OnExit.Invoke ();
        }

        void Update()
        {
            if (m_CanExecuteButtons)
            {
            
                if (OnButtonPressDown.GetPersistentEventCount() > 0 && PlayerInput.Instance.Interact.Down)
                {
                  
                    OnButtonPressDown.Invoke();
                }
                if (OnButtonPressUp.GetPersistentEventCount() > 0 && PlayerInput.Instance.Interact.Up)
                {
                   
                    OnButtonPressUp.Invoke();
                    
                }
                if (OnSkillPressDown.GetPersistentEventCount() > 0 && PlayerInput.Instance.Skill.Down)
                {
                    print("omgosh");
                    OnSkillPressDown.Invoke();

                }
               
            }
        }
    }
}