﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class MeleeAttackSMB : SceneLinkedSMB<PlayerCharacter>
    {
        int m_HashAirborneMeleeAttackState = Animator.StringToHash ("AirborneMeleeAttack");
    
        public override void OnSLStatePostEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.ForceNotHoldingGun();
            m_MonoBehaviour.EnableMeleeAttack();
            m_MonoBehaviour.SetHorizontalMovement(m_MonoBehaviour.meleeAttackDashSpeed * m_MonoBehaviour.GetFacing());
        }

        public override void OnSLStateNoTransitionUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //if (!m_MonoBehaviour.CheckForGrounded ())
                
            animator.Play (m_HashAirborneMeleeAttackState, layerIndex, stateInfo.normalizedTime);
        
            m_MonoBehaviour.GroundedHorizontalMovement (false);
            m_MonoBehaviour.GroundedVerticalMovement(false);
        }

        public override void OnSLStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.DisableMeleeAttack();
        }
    }
}