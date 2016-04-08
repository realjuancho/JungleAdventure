using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {

    	public float testFloat;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                //m_Jump = CrossPlatformInputManager.GetButtonDown("Cross");
                m_Jump = Input.GetButtonDown(Hash.Buttons.Cross) || TouchPadInput.Button8;
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            //bool crouch = Input.GetAxis(Hash.Axis.LStick_UpDown) > 0.5f;
            bool crouch = false;

            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
			//float h = CrossPlatformInputManager.GetAxis("LStick_LeftRight");


			float h = Input.GetAxis(Hash.Axis.LStick_LeftRight);
            // Pass all parameters to the character control script.

 

			//If DS4
			m_Character.Move(h, crouch, m_Jump);

			//If Android
//			bool crouch_touch = (TouchPadInput.MovementAxis_Vertical < -1.0f);
//			float h_touch = 0;
//
//			if(TouchPadInput.MovementAxis_Horizontal != 0.0f)
//			{
//				if(TouchPadInput.MovementAxis_Horizontal > 0) h_touch = 1;
//				else h_touch = -1;
//			}
//			m_Character.Move(h_touch, false, m_Jump);


			m_Jump = false;
        }
    }
}
