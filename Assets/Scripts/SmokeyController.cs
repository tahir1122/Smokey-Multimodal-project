using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Vuforia;
using System.IO;

public class SmokeyController : MonoBehaviour {

	public static bool update;
	public static bool instantiate;
	public static string dataColor;
    public static int initPCG = 0;
    public static int initialSize = 0;

    public static List<TrackableBehaviour> all_targets = new List<TrackableBehaviour>();
    public static int batchCount = 0;
    public static List<int> AllbatchCounts = new List<int>();
    public static int eachSpecieCount = 0;
    public static List<GameObject> allHabitats = new List<GameObject>();
    public static List<GameObject> LayeredHabitats = new List<GameObject>();
    public static List<List<ModelInstantiator>> all_instantiators = new List<List<ModelInstantiator>>();
    public static List<ModelInstantiator> instantiators = new List<ModelInstantiator>();
	public static List<Graphs> graphList = new List<Graphs>();
    public static List<string> colors = new List<string> { "red", "green", "yellow", "magenta", "cyan", "blue", "white", "orange", "gray", "black", "purple"};

    public static List<Transform> allLayeredNodes = new List<Transform>();
    public static List<string> allNames = new List<string>();

    

    public Transform im;
    public Material white;

    public Transform redPrefab;
    public Transform bluePrefab;
    public Transform greenPrefab;
    public Transform magentaPrefab;
    public Transform yellowPrefab;
    public Transform cyanPrefab;
    public Transform purplePrefab;
    public Transform orangePrefab;
    public Transform grayPrefab;
    public Transform blackPrefab;
    public Transform whitePrefab;
    public Transform filterPrefab;
    public Transform envPrefab;
    public Transform textPrefab;
    public Transform historyPrefab;
    
    public Transform parentMap;
    public Transform blackwhite;
	public Transform nodePrefab;

    public int activeData = 2;
    public static int nodeCount = 0;

    public Transform a1; public Transform a2; public Transform a3; public Transform a4; public Transform a5; public Transform a6; public Transform a7; public Transform a8;
    public Transform a9; public Transform a10; public Transform a11; public Transform a12; public Transform a13; public Transform a14; public Transform a15; public Transform a16;
    public Transform a17; public Transform a18; public Transform a19; public Transform a20; public Transform a21; public Transform a22; public Transform a23; public Transform a24;
    public Transform a25; public Transform a26; public Transform a27;

    public ModelInstantiator MI;
	public static ParallelCoordInstantiator PI = new ParallelCoordInstantiator();
    public static List<Transform> Elayers;
    public static List<string> ENVnames;
    Camera mainCamera;
    public GameObject sub;
    public static bool yess=false;
    public static bool yessplus = false;
    public Vector3 difference = new Vector3(0, 0, 0);
    public RaycastHit hitInfo;
    public GameObject FocusedObject = null;
    public GameObject oldFocusedObject = null;

    public static Vector3 newPosition;
    private Vector3 newDirection;
    private Vector3 oldPosition;
    private Vector3 oldDirection;
    private string focusedobjectName = "none";
    private string path;
    private TextWriter writer;
    public static bool subspaceWeight = false;
    void Start()
    {
        mainCamera = Camera.main;
        Elayers = new List<Transform>() { a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15,a16,a17,a18,a19,a20,a21,a22,a23,a24,a25,a26,a27 };
        ENVnames = new List<string>() { "avg_yearly_rainfall","geology","hydrologic_soil_group", "parent_material", "seedling_mortalityl","soil_drainage_class","soil_hydric_rating_class",
            "soil_surface_texture","surficial_geology","type_disturbance","understory_density_class","vegetation","wetlands","years_since_fire","air_flow_height","aspect",
            "available_watersupply_at_100cm","available_watersupply_at_150cm","available_watersupply_at_25cm","available_watersupply_at_50cm","convergence_index",
            "convexity","cross_sectional_curvature","diffuse_solar_radiation","direct_duration_solar_radiation","direct_solar_radiation","elevation" };

        Subspaces.fab = im;
        Subspaces.white = white;
        sub = GameObject.Find("Text1");
        path = Path.Combine(Application.persistentDataPath, "MyFile11.txt");
        writer = File.CreateText(path);
    }
    Transform dataTrf;

    public void coordinates()
    {
        sub.GetComponent<TextMesh>().color = Color.green;
        difference = Camera.main.transform.position;
        yessplus = true;
    }
    void Update()
	{
        if (Input.GetKeyDown("l"))
        {
            sub.GetComponent<TextMesh>().color = Color.green;
            difference = Camera.main.transform.position;
            yessplus = true;
        }
        if (yessplus == true)
        {
            sub.transform.parent = all_targets[detectedImageCount].transform;
            sub.transform.localPosition = new Vector3(0, -0.3f, 2);
            sub.transform.localRotation = Quaternion.Euler(90,0,0);
            yessplus = false;
            subspaceWeight = true;
        }
        if (yess == true)
        {
            oldFocusedObject = FocusedObject;
            oldDirection = newDirection;
            oldPosition = newPosition;
            //sub.GetComponent<TextMesh>().text = (Camera.main.transform.position - difference).ToString();
            sub.GetComponent<TextMesh>().text = (Camera.main.transform.position - difference).ToString() + '\n' + Camera.main.transform.forward;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo))
            {
                FocusedObject = hitInfo.collider.gameObject;
                if(FocusedObject != oldFocusedObject)
                {
                    focusedobjectName = FocusedObject.name;
                    //print(FocusedObject.name);
                }
            }
            else
            {
                FocusedObject = null;
                focusedobjectName = "none";
            }
            newPosition = Camera.main.transform.position - difference;
            newDirection = Camera.main.transform.forward;
            if (newPosition != oldPosition)
            {
                //writer.WriteLine(focusedobjectName + "," + newPosition.ToString() + "," + Camera.main.transform.position + "," + difference + "," + Camera.main.transform.forward + ',' + Time.time);
            }
            if (newDirection != oldDirection)
            {
                //writer.WriteLine(focusedobjectName + "," + newPosition.ToString() + "," + Camera.main.transform.position + "," + difference + "," + Camera.main.transform.forward + ',' + Time.time);
            }

        }
        if (update == true)
        {
            CheckUI();
            update = false;
        }

        if (Input.GetKeyDown("m"))
        {
            Subspaces.merge_spaces();
        }
        if (Input.GetKeyDown("1"))
        {
            ModelInstantiator.hideAll();
            //for (int i = 0; i < allHabitats.Count; i++)
            //{
            //    allHabitats[i].SetActive(false);
            //    LayeredHabitats[i].SetActive(false);
            //}
            for (int i = 0; i < AllbatchCounts[0]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 1;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.dataList1);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("2"))
        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[0]; i < AllbatchCounts[1]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 2;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.Reptile1);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("3"))
        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[1]; i < AllbatchCounts[2]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 3;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.algae1);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("4"))
        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[2]; i < AllbatchCounts[3]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 4;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.Amphibian1);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("5"))
        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[3]; i < AllbatchCounts[4]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 5;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.Fish1);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("6"))
        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[4]; i < AllbatchCounts[5]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 6;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.Mammal1);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("7"))
        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[5]; i < AllbatchCounts[6]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 7;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.Bird1);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("8"))

        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[6]; i < AllbatchCounts[7]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 8;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.Plant11);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("9"))
        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[7]; i < AllbatchCounts[8]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 9;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.Plant21);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("0"))
        {
            ModelInstantiator.hideAll();
            for (int i = AllbatchCounts[8]; i < AllbatchCounts[9]; i++)
            {
                allHabitats[i].SetActive(true);
                LayeredHabitats[i].SetActive(true);
            }
            activeData = 10;
            ParallelCoordInstantiator.delete();
            DataManager.LoadEnvData("species_parallel_allSpecies", 49, ServerStream.Plant31);
            displayParallelCoord();
        }
        if (Input.GetKeyDown("b"))
        {
            ParallelCoordInstantiator.delete();
        }
        if (Input.GetKeyDown("z"))
        {
            //Subspaces.Highlight();
            //initHistory();
            //for (int i = 0; i < allHabitats.Count; i++)
            //{
            //    allHabitats[i].SetActive(true);
            //    //LayeredHabitats[i].SetActive(true);
            //}
        }
    }
    int historyCount = 0;

    public void highlightem()
    {
        Subspaces.Highlight();
    }
    public void alldata()
    {
        for (int i = 0; i < allHabitats.Count; i++)
        {
            allHabitats[i].SetActive(true);
            //LayeredHabitats[i].SetActive(true);
        }
    }

    public void datasetB()
    {
        ModelInstantiator.hideAll();
        for (int i = AllbatchCounts[2]; i < AllbatchCounts[3]; i++)
        {
            allHabitats[i].SetActive(true);
            LayeredHabitats[i].SetActive(true);
        }
        activeData = 4;
    }

    public void datasetA()
    {
        for (int i = 0; i < allHabitats.Count; i++)
        {
            allHabitats[i].SetActive(false);
            LayeredHabitats[i].SetActive(false);
        }
        for (int i = AllbatchCounts[0]; i < AllbatchCounts[1]; i++)
        {
            allHabitats[i].SetActive(true);
            LayeredHabitats[i].SetActive(true);
        }
        activeData = 2;
    }

    public void reset()
    {
        LayeredMapping.resetLayerPos();
        DeleteAllENV();
    }
    public void initHistory(bool a)
    {
        //stack();
        //dataTrf = GameObject.Instantiate(historyPrefab) as Transform;
        //dataTrf.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
        //dataTrf.transform.localRotation = Quaternion.identity;
        //dataTrf.transform.localScale = new Vector3(0.8f, 0.01f, 0.5f);
        //dataTrf.transform.localPosition = new Vector3(7.04f + (historyCount % 4 )* 1.7f, 0.3f, 1.87f + (Mathf.Floor(historyCount/4))*1f);
        //dataTrf.GetComponent<HistoryInstantiator>().dataset = 1;
        //foreach(Transform item in allENVlayers){
        //    dataTrf.GetComponent<HistoryInstantiator>().envID.Add(int.Parse(item.name));
        //    dataTrf.GetComponent<HistoryInstantiator>().envPos.Add(item.localPosition);}
        //foreach(Transform item in LayeredMapping.layers){
        //    dataTrf.GetComponent<HistoryInstantiator>().layerName.Add(item.name);
        //    dataTrf.GetComponent<HistoryInstantiator>().layerPos.Add(item.localPosition);}
        //dataTrf.name = "history" + historyCount;
        Color cc;
        Color ee;
        if(a == true)
        {
            cc = Color.blue;
            ee = Color.red;
        }else
        {
            cc = Color.gray;
            ee = Color.gray;
        }
        
        GameObject stack1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stack1.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
        stack1.GetComponent<Renderer>().material.color = ee;
        stack1.transform.localPosition = new Vector3(7.04f + (historyCount % 4) * 1.7f, -0.3f, 1.87f + (Mathf.Floor(historyCount / 4)) +0.11f);
        stack1.transform.localScale = new Vector3(0.6f, 0.6f, 0.05f);
        stack1.transform.localRotation = Quaternion.Euler(159.8f, -19.6f, -57.1f);
        stack1.layer = LayerMask.NameToLayer("Ignore Raycast");
        stack1.SetActive(true);

        GameObject stack2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stack2.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
        stack2.GetComponent<Renderer>().material.color = cc;
        stack2.transform.localPosition = new Vector3(7.04f + (historyCount % 4) * 1.7f, -0.3f, 1.87f + (Mathf.Floor(historyCount / 4)) );
        stack2.transform.localScale = new Vector3(0.6f, 0.6f, 0.05f);
        stack2.transform.localRotation = Quaternion.Euler(159.8f, -19.6f, -57.1f);
        stack2.layer = LayerMask.NameToLayer("Ignore Raycast");
        stack2.SetActive(true);

        GameObject stack3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stack3.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
        stack3.GetComponent<Renderer>().material.color = cc;
        stack3.transform.localPosition = new Vector3(7.04f + (historyCount % 4) * 1.7f, -0.3f, 1.87f + (Mathf.Floor(historyCount / 4)) -0.11f);
        stack3.transform.localScale = new Vector3(0.6f, 0.6f, 0.05f);
        stack3.transform.localRotation = Quaternion.Euler(159.8f, -19.6f, -57.1f);
        stack3.layer = LayerMask.NameToLayer("Ignore Raycast");
        stack3.SetActive(true);

        var text = Instantiate(textPrefab);
        text.parent = TrackableMonitor.mTrackableBehaviour.transform;
        text.localPosition = new Vector3(6.5f + (historyCount % 4) * 1.7f, -0.3f, 1.87f + (Mathf.Floor(historyCount / 4)) -0.33f);
        text.localScale = new Vector3(0.1f, 0.15f, 0.001f);
        text.localRotation = Quaternion.Euler(0, 0, 0);
        text.Rotate(90, 0, 0);
        text.gameObject.SetActive(true);
        TextMesh theText = text.transform.GetComponent<TextMesh>();
        historyCount++;
        theText.text = "History Instance " + historyCount;
    }

    public static int detectedImageCount = 0;                          
        ///////////////////
    public void UIUpdate()
	{
        Subspaces.make_subspaces();
        Subspaces.make_AllOutline();
        yess = true; yessplus = true;
        //update = true;
        //detectedImageCount = 0;
        ////////////////////
    }

    string specie_name;
    public static bool ONCEE = false;

    public static void Text(string line)
    {
        //print(line);
        string path = Path.Combine(Application.persistentDataPath, "MyFile11.txt");
        using (TextWriter writer = File.CreateText(path))
        {
            writer.WriteLine(line);
            writer.Flush();
        }
    }

	public void CheckUI()
	{	
		if (ServerStream.dataList != null)
		{	
			if (ServerStream.dataList.Count == 0)
            {
                displayParallelCoord();
                //displayLayers();
                //scatterplot.read();
                //ENVmds.read();
                FilteringTypes.filter_nodes(filterPrefab, textPrefab);
                //datasetB();
                //stopTracking();
                //LayeredMapping.furtherData();
                //LayeredMapping.hideLayers();
                //initHistory(false);
                //initHistory(true);
                //initHistory(false);
                //initHistory(false);
                //makeENVlayer(1);
                //makeENVlayer(2);
                //makeENVlayer(3);
                //SetEdgeBundle();
                //print("MI count" + instantiators.Count);
                //smokey_minimize();  // initialize the view
            }	
			if (ServerStream.dataList.Count != 0)
			{
                specie_name = ServerStream.dataList[0];
                ServerStream.LoadNext();
				BuildInstantiator();
                if (ServerStream.dataList.Count == 0 && ONCEE == false)
                {
                    ServerStream.newData();
                    displayLayers();
                    instantiators.Clear();
                    if (ONCEE == false)
                    {
                        //print("sdsad"+instantiators.Count);
                        //instantiators.Clear();
                    }
                    batchCount = allHabitats.Count;
                    AllbatchCounts.Add(eachSpecieCount);
                    print(eachSpecieCount);
                    //eachSpecieCount = 0;
                    ModelInstantiator.hideAll();
                    
                }
                if (ServerStream.dataList.Count == 0 && ONCEE == true) {
                    displayLayers();
                    AllbatchCounts.Add(eachSpecieCount);
                    print(eachSpecieCount);
                    //instantiators.Clear();
                }
                CheckUI();
			}
		}
	}

    public void stopTracking()
    {
        GameObject.Find("ARCamera").GetComponent<VuforiaBehaviour>().enabled = false;
    }
    public void startTracking()
    {
        GameObject.Find("ARCamera").GetComponent<VuforiaBehaviour>().enabled = true;

    }
    public void defaultLayers()
    {
        LayeredMapping.resetLayerPos();
    }
    public void showImage()
    {
        ImageSubspaces.show();
    }
    public void hideImage()
    {
        ImageSubspaces.hide();
    }
    public bool layers_once = false;
    public void showLayers()
    {
        if (layers_once == false)
        {
            displayLayers();
            layers_once = true;
        }
        else
        {
            LayeredMapping.display();
        }
    }
	public void BuildInstantiator() 
	{                               
        const int MaxLength = 19;           // setting a limit to the length of specie name
		if (nodePrefab != null) 
		{
			dataColor = FindColor();        // assigning a color to each specie
			MI = new ModelInstantiator();
			MI.dataSet = DataManager.dataSet;
			MI.color = dataColor;
            if(specie_name.Length > MaxLength)
                MI.name1 = specie_name.Substring(0, MaxLength);
            else
                MI.name1 = specie_name;
                
			MI.InstantiateDataPoints(DataManager.longitude, DataManager.lattitude, whitePrefab);
            allNames.Add(MI.name1);
			instantiators.Add(MI);
		}
	}
    bool makeOnlyLayer = false;
	public void displayLayers()
	{
        if (makeOnlyLayer == false)
        {
            LayeredMapping.BuildLayers(parentMap, whitePrefab);
            makeOnlyLayer = true;   
        }
        else
        {
            LayeredMapping.addDatatoMaps();
        }
	}
    bool pcp_once = false;
	public void displayParallelCoord()
	{
        if (pcp_once == false)
        {
            ParallelCoordInstantiator.InstantiateSelection(DataManager.envData, DataManager.axisRanges, nodePrefab);
            ParallelCoordInstantiator.environmentalLayers(envPrefab);
            pcp_once = true;
            return;
        }
        if (pcp_once == true)
        {
            ParallelCoordInstantiator.InstantiateSelection(DataManager.envData, DataManager.axisRanges, nodePrefab);
        }
    }
    public void show_subspaces()
    {
        Subspaces.show_subspaces();
    }
    public void hide_subspaces()
    {
        Subspaces.hide_subspaces();
    }
    int acb = 0;
    public void SetEdgesBundle()
    {
        //RemoveGraphs();
        foreach (ModelInstantiator MI in instantiators)
        {
            EdgeBundler EB = new EdgeBundler();
            if(acb == 0)
            {
                EB.BuildGraph(MI.dataPoints, MI.color, nodePrefab);
                graphList.Add(EB);
            }
            
            //EB.Mycolor = MI.color;
            //print(MI.name1);
            //update = true;
            acb++;
        }
    }
    int iter = 0;
    public void SetEdgeBundle()
    {
        foreach (ModelInstantiator MI in instantiators)
        {
            EdgeBundler EB = new EdgeBundler();
            if (iter == 2)
            {
                EB.BuildGraph(MI.dataPoints, MI.color, nodePrefab);
                graphList.Add(EB);
            }
            iter++;
            //update = true;
        }
    }
    //public void SetPillarGraph()
    //{
    //    //RemoveGraphs();

    //    foreach (ModelInstantiator MI in instantiators)
    //    {
    //        PillarGraph PG = new PillarGraph();
    //        PG.BuildGraph(MI.dataPoints, MI.color, ColorPrefab(MI.color));
    //        graphList.Add(PG);

    //        update = true;
    //    }
    //}

    //public void RemoveGraphs()
    //{
    //	if (graphList != null)
    //	{
    //		foreach (Graphs g in graphList)
    //		{	
    //			foreach (Connection c in g.connections)
    //			{
    //				if (c.gameObject != null)
    //				{
    //					DestroyImmediate(c.gameObject);
    //				}

    //			}
    //			foreach (Transform n in g.nodes){
    //				if (n.gameObject != null)
    //				{
    //					DestroyImmediate(n.gameObject);
    //				}
    //			}
    //			DestroyImmediate(g);
    //		}
    //	}
    //	graphList.Clear();	
    //}

    public string FindColor()
    {
        int count = instantiators.Count();
        count = count % 10;
        return (colors[count]);
    }
    public static List<Transform> allENVlayers = new List<Transform>();     // while working with history, if env is active then place it to appropriate pos
    public static float ENVscale = .3f;
    public static int ENVindex = 0;
    public static List<float> allYpos = new List<float> { 0,2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48,50,52 };
    public static List<int> ENVid = new List<int>();
    public static List<int> tempID = new List<int>();
    public static void makeENVlayer(int ID)
    {
        Transform myMap = GameObject.Instantiate(SmokeyController.Elayers[ID]) as Transform;
        myMap.parent = TrackableMonitor.mTrackableBehaviour.transform;
        myMap.localRotation = Quaternion.identity;
        myMap.localScale = new Vector3(ENVscale, ENVscale, ENVscale);
        myMap.Rotate(90f, 0f, 0f);
        Vector3 pos = new Vector3(10, allYpos[ENVindex]+0.5f, -3.6f);
        myMap.localPosition = pos;
        myMap.name = ENVnames[ID] + "_heatmap";
        myMap.gameObject.SetActive(true);
        var collider = myMap.transform.gameObject.AddComponent<BoxCollider>();
        allENVlayers.Add(myMap);
        myMap.GetComponent<ENVmap_id>().identifier = ID;
        ENVid.Add(ID);
        ENVindex++;
    }
    public static void removeENVlayer(int ID)
    {
        int index = ENVid.IndexOf(ID);
        Transform temp = allENVlayers[index];
        allENVlayers[index].gameObject.SetActive(false);
        allENVlayers.Remove(allENVlayers[index]);
        Destroy(temp);
        ENVid.Remove(ENVid[index]);
        ENVindex--;
        for(int i = index; i < allENVlayers.Count; i++)
        {
            if(allENVlayers[i].localPosition.x == 10)
            {
                Vector3 pp = allENVlayers[i].localPosition;
                pp.y -= 2;
                allENVlayers[i].localPosition = pp;
                allENVlayers[i].gameObject.SetActive(true);
            }
        }
    }

    public static void DeleteAllENV()
    {
        foreach(Transform item in allENVlayers)
        {
            Destroy(item.gameObject);
        }
        allENVlayers.Clear();
        ENVindex = 0;
        if(allENVlayers.Count != 0) { print("env DS not empty!!"); }
    }
    public void smokey_minimize(){
        //showLayers();

        Subspaces.smokey_min();
        Subspaces.layered_min();
        Subspaces.PCP_min();
        Subspaces.SP_min();
        Subspaces.SP2_min();


        Transform myMap = GameObject.Instantiate(SmokeyController.Elayers[3]) as Transform;
        myMap.parent = TrackableMonitor.mTrackableBehaviour.transform;
        myMap.localRotation = Quaternion.identity;
        myMap.localScale = new Vector3(0.12f, 0.1f, 0.01f);
        myMap.Rotate(90f, 0f, 0f);
        myMap.localPosition = new Vector3(2.6f, -0.02f, -1.1f);
        myMap.gameObject.SetActive(true);


        Transform bipartite = GameObject.Instantiate(SmokeyController.Elayers[26]) as Transform;
        bipartite.parent = TrackableMonitor.mTrackableBehaviour.transform;
        bipartite.localRotation = Quaternion.identity;
        bipartite.localScale = new Vector3(0.21f, 0.23f, 0.01f);
        bipartite.Rotate(90f, 0f, 0f);
        bipartite.localPosition = new Vector3(2.6f, -0.02f, -3.59f);
        bipartite.gameObject.SetActive(true);

        var text1 = Instantiate(textPrefab);
        text1.parent = TrackableMonitor.mTrackableBehaviour.transform;
        text1.localPosition = new Vector3(4.57f, 0.1f, -0.32f);
        text1.localScale = new Vector3(0.1f, 0.1f, 0.001f);
        text1.localRotation = Quaternion.Euler(270, 0, 0);
        text1.Rotate(180, 0, 0);
        text1.gameObject.SetActive(true);
        TextMesh theText1 = text1.transform.GetComponent<TextMesh>();
        theText1.text = "Visualizations";
        Color32 greyColour = new Color32(0xA5, 0xFF, 0xF0, 0xFF);
        theText1.color = greyColour;
        theText1.fontStyle = FontStyle.Bold;

        var text2 = Instantiate(textPrefab);
        text2.parent = TrackableMonitor.mTrackableBehaviour.transform;
        text2.localPosition = new Vector3(2f, 0.1f, -0.32f);
        text2.localScale = new Vector3(0.1f, 0.1f, 0.001f);
        text2.localRotation = Quaternion.Euler(270, 0, 0);
        text2.Rotate(180, 0, 0);
        text2.gameObject.SetActive(true);
        TextMesh theText2 = text2.transform.GetComponent<TextMesh>();
        theText2.text = "Derived Information";
        theText2.color = greyColour;
        theText2.fontStyle = FontStyle.Bold;

        var text3 = Instantiate(textPrefab);
        text3.parent = TrackableMonitor.mTrackableBehaviour.transform;
        text3.localPosition = new Vector3(-0.21f, 0.1f, -0.32f);
        text3.localScale = new Vector3(0.1f, 0.1f, 0.001f);
        text3.localRotation = Quaternion.Euler(270, 0, 0);
        text3.Rotate(180, 0, 0);
        text3.gameObject.SetActive(true);
        TextMesh theText3 = text3.transform.GetComponent<TextMesh>();
        theText3.text = "Data Components";
        theText3.color = greyColour;
        theText3.fontStyle = FontStyle.Bold;

        bulletPoints.make(blackPrefab, textPrefab);




    }
}
