﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class DeadLandingSMB : SceneLinkedSMB<PlayerCharacter>
    {
        public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        
        }

        public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.GroundedHorizontalMovement (false);
            m_MonoBehaviour.GroundedVerticalMovement(false);
        }

        public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}