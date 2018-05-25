using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSelection : MonoBehaviour {

	public static string b1Selection;
	public static string b2Selection;
	public static Queue dataQueue = new Queue();
	public static int buttonNum;

	public static List<string> currentFiles = new List<string>();
	public static string[] pannelData = new string[] {"Abaeis_nicippe", "Carpinus_caroliniana", "Carex_intumescens", "Scoparia_biplagialis", "Troglodytes_troglodytes", "Viburnum_lantanoides"};
	

	// void Start(){
	// 	Button1();
	// 	Button2();
	// 	// Button3();
	// 	// Button4();
	// 	// Button5();
	// 	// Button6();
	// 	// HeightMapSelection HS= new HeightMapSelection();
	// 	// HS.Button1();
	// }

	public void Button1() {
		buttonNum = 1;
		if(!currentFiles.Contains(pannelData[buttonNum-1]) && pannelData[buttonNum-1] != "empty"){
			dataQueue.Enqueue(pannelData[buttonNum-1]);
			currentFiles.Add(pannelData[buttonNum-1]);
			TrackableMonitor.UIChange = true;
		}
	}

	public void Button2() {
		buttonNum = 2;
		if(!currentFiles.Contains(pannelData[buttonNum-1]) && pannelData[buttonNum-1] != "empty"){
			dataQueue.Enqueue(pannelData[buttonNum-1]);
			currentFiles.Add(pannelData[buttonNum-1]);
			TrackableMonitor.UIChange = true;
		}
	}

	public void Button3() {
		buttonNum = 3;
		if(!currentFiles.Contains(pannelData[buttonNum-1]) && pannelData[buttonNum-1] != "empty"){
			dataQueue.Enqueue(pannelData[buttonNum-1]);
			currentFiles.Add(pannelData[buttonNum-1]);
			TrackableMonitor.UIChange = true;
		}
	}

	public void Button4() {
		buttonNum = 4;
		if(!currentFiles.Contains(pannelData[buttonNum-1]) && pannelData[buttonNum-1] != "empty"){
			dataQueue.Enqueue(pannelData[buttonNum-1]);
			currentFiles.Add(pannelData[buttonNum-1]);
			TrackableMonitor.UIChange = true;
		}
	}

	public void Button5() {
		buttonNum = 5;
		if(!currentFiles.Contains(pannelData[buttonNum-1]) && pannelData[buttonNum-1] != "empty"){
			dataQueue.Enqueue(pannelData[buttonNum-1]);
			currentFiles.Add(pannelData[buttonNum-1]);
			TrackableMonitor.UIChange = true;
		}
	}

	public void Button6() {
		buttonNum = 6;
		if(!currentFiles.Contains(pannelData[buttonNum-1]) && pannelData[buttonNum-1] != "empty"){
			dataQueue.Enqueue(pannelData[buttonNum-1]);
			currentFiles.Add(pannelData[buttonNum-1]);
			TrackableMonitor.UIChange = true;
		}
	}	

	public static void LoadNext(){
		DataManager.LoadData(dataQueue.Dequeue().ToString());
	}
}


