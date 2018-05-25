using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;
using System;

public class TrackableMonitor : MonoBehaviour, ITrackableEventHandler
{
	public static TrackableBehaviour mTrackableBehaviour;
	public static SmokeyController SC = new SmokeyController();
	public static bool UIChange;

	// Use this for initialization
	void Start ()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        SmokeyController.all_targets.Add(mTrackableBehaviour);


        if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

	}               

	// Update is called once per frame
	void Update ()
	{
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED)
		{
            //UIChange = true;
            OnTrackingFound();
		}

	}

	private void OnTrackingFound()
	{
        if (UIChange == true)
        {
            SC.UIUpdate();
            //Camera.main.transform.position = new Vector3(0, 0, 0.7f);                                         /////////////////////////////////////////////////////
            //GameObject.Find("ARCamera").transform.position = new Vector3(0, 0, 0.7f);      // make it +ve     /////////////////////////////////////////////////////

        }
        //UIChange = false;
    }
    
}
