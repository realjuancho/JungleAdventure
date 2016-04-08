using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class Hash : MonoBehaviour
{

	#region Game Settings

	public static class Layers{

		public static string Floor = "Floor";
		public static string Grabbables = "Grabbables";
		public static string Platform = "Platform";
		public static string PlatformActivator = "PlatformActivator";
		public static string EnemyBody = "EnemyBody";
		public static string DeadBody = "DeadBody";


	}

	#endregion

	#region Input Buttons / Axis Names

	public static class Buttons
	{

		public static string Square = "Square";
		public static string Circle = "Circle";
		public static string Triangle = "Triangle";
		public static string Cross = "Cross";

		public static string L1_Button = "L1_Button";
		public static string R1_Button = "R1_Button";

		public static string L2_Button = "L2_Button";
		public static string R2_Button = "R2_Button";

		public static string L3_Button = "L3_Button";
		public static string R3_Button = "R3_Button";

		public static string Options = "Options";
		public static string Share = "Share";
		public static string TouchPadClick = "TouchPadClick";
		public static string PSButton = "PS_Button";


	}


	public static class Axis
	{
		public static string DPad_UpDown = "DPad_UpDown";
		public static string DPad_LeftRight = "DPad_LeftRight";

		public static string LStick_UpDown = "LStick_UpDown";
		public static string LStick_LeftRight = "LStick_LeftRight";

		public static string RStick_UpDown = "RStick_UpDown";
		public static string RStick_LeftRight = "RStick_LeftRight";

	}

	#endregion

	#region resources
	public static class Sprites
	{
		public static class AttackSprites{

			public static string SimpleAttack = "Sprites/Attacks/SimpleAttack";
			public static string FireAttack = "Sprites/Attacks/FireAttack";
			public static string IceAttack = "Sprites/Attacks/IceAttack";
			public static string LightningAttack = "Sprites/Attacks/LightningAttack";
			public static string EarthAttack = "Sprites/Attacks/EarthAttack";

		}

		public static class PlatformSprites
		{
			public static string PlatformActivator_Inactive = "Sprites/Platforms/platform_Activator_0";
			public static string PlatformActivator_Active = "Sprites/Platforms/platform_Activator_1";
			
		}


	}


	public static class Particles
	{
		public static class AttackParticles{

			public static string SimpleAttack = "Particles/SimpleAttack";
			public static string FireAttack = "Particles/FireAttack";
			public static string IceAttack = "Particles/IceAttack";
			public static string LightningAttack = "Particles/LightningAttack";
			public static string EarthAttack = "Particles/EarthAttack";

		}
	}



	#endregion

	#region Animation
	public static class Animations
	{
		public static class Platforms
		{
			public static string PlatformActivator_Activate_Bool = "activated";
		}

		public static class Enemies
		{
			public static string Walk_Bool = "Walk";
			public static string Die_Trigger = "Die";
			public static string Attack_Trigger = "Attack";

		}

	}



	#endregion
}

