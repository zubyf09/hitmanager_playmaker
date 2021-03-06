// Custom Action by DumbGameDev
// www.dumbgamedev.com
// All rights reserved Eric Vander Wal 2017

using UnityEngine;
using MLSpace;
using HutongGames;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Custom")]
    [Tooltip("Start rag doll functions.")]

    public class startGetUpRagDoll : FsmStateAction

    {
        [RequiredField]
		[CheckForComponent(typeof(RagdollManagerHum))]
		[Tooltip("The gameobject of the body part being hit. Must have body collider script attached")]
		[TitleAttribute ("GameObject")]
        public FsmOwnerDefault gameObject;

		public FsmBool everyFrame;

		private RagdollManagerHum theScript;

        public override void Reset()
        {

			everyFrame = false;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
			theScript = go.GetComponent<RagdollManagerHum>();

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

//			BodyColliderScript bcs = go.GetComponent<BodyColliderScript>();
//			int[] parts = new int[] { bcs.index };
//			bcs.ParentRagdollManager.OnGetUpFunc ();
//			bcs.ParentRagdollManager.OnStartTransition ();
			theScript.blendToMecanim ();


		}
			
     }

}