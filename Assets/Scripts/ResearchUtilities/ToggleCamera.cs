using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia
{
	//disable camera to take photos
	//enable to continue tracking behavior
	
	public class ToggleCamera : MonoBehaviour {

		public void DisableCamera () 
		{
			CameraDevice.Instance.Stop();
		}

		public void EnableCamera () 
		{
			CameraDevice.Instance.Start();
		}

	}
}
