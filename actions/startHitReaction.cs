// Custom Action by DumbGameDev
// www.dumbgamedev.com
// All rights reserved Eric Vander Wal 2017

using UnityEngine;
using MLSpace;
using HutongGames;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Custom")]
    [Tooltip("Start a hit reaction using ragdoll function.")]

    public class startHitReaction : FsmStateAction

    {
        [RequiredField]
		[CheckForComponent(typeof(BodyColliderScript))]
		[Tooltip("The gameobject of the body part being hit. Must have body collider script attached")]
		[TitleAttribute ("Hit Part")]
        public FsmOwnerDefault gameObject;

		[RequiredField]
		[Tooltip("The direction of the hit into the body part.")]
		[TitleAttribute ("Hit Direction")]
		public FsmVector3 vector3Hit;

		[RequiredField]
		[Tooltip("Force multiplier to be applied to determine the strength of the hit.")]
		[TitleAttribute ("Hit Force")]
		public FsmFloat floatForce;

		public FsmBool everyFrame;

		BodyColliderScript theScript;

        public override void Reset()
        {

			vector3Hit = null;
			floatForce = null;
			everyFrame = false;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
			theScript = go.GetComponent<BodyColliderScript>();

            if (!everyFrame.Value)
            {
                MakeItSo();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                MakeItSo();
            }
        }


        void MakeItSo()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

			BodyColliderScript bcs = go.GetComponent<BodyColliderScript>();
			int[] parts = new int[] { bcs.index };
			bcs.ParentRagdollManager.startHitReaction(parts, vector3Hit.Value * floatForce.Value);

		}
			
     }

}