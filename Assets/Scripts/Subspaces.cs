using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subspaces : MonoBehaviour {
    public static List<float> x_pos = new List<float> { 2.8f, 10.1f, -4.3f };
    public static List<float> z_pos = new List<float> { -6.6f, -1.5f, 3.6f };
    public static List<GameObject> subspaces = new List<GameObject>();
    private static float y_comp = 0.24f;
    private static float y_pos = -0.2f;
    public static Transform focus25;
    public static Transform focus;
    public static Transform focus1;
    public static Transform focus2;
    public static Transform focus3;
    public static Transform focus4;
    public static Vector3 newpos;
    public static Vector3 newscale;
    private Vector3 currentCam;
    private GameObject latest = null;
    public static List<float> YSpaces = new List<float>();
    private List<GameObject> active_outlines = new List<GameObject>();
    private static Mesh cube_mesh = null;
    public static Material white;

    public static Transform fab;

    public static List<CubeObject> each_outline = new List<CubeObject>();

    void Start(){}
    void Update()
    {
        if(SmokeyController.subspaceWeight == true)
        {
            Vector3 pos = SmokeyController.newPosition;
            if (pos.x < 1.6f && pos.x > -0.1f && pos.y < 0.3f && pos.y > -0.8f)         // middle subspaces
            {
                graphnodes[4].GetComponent<Renderer>().material.color = Color.green;
            }else{graphnodes[4].GetComponent<Renderer>().material.color = Color.gray;}
            if(pos.x > -1.8f && pos.x < -0.1f && pos.y < 0.3f && pos.y > -0.8f)
            {
                graphnodes[3].GetComponent<Renderer>().material.color = Color.green;
            }else{graphnodes[3].GetComponent<Renderer>().material.color = Color.gray;}
            if(pos.x > 1.6f && pos.x < 3.3f && pos.y < 0.3f && pos.y > -0.8f)
            {
                graphnodes[5].GetComponent<Renderer>().material.color = Color.green;
            }else{ graphnodes[5].GetComponent<Renderer>().material.color = Color.gray;}



            if (pos.x < 1.6f && pos.x > -0.1f && pos.y < 1.3f && pos.y > 0.3f)         // top subspaces
            {
                graphnodes[1].GetComponent<Renderer>().material.color = Color.green;
            }else { graphnodes[1].GetComponent<Renderer>().material.color = Color.gray; }
            if (pos.x > -1.8f && pos.x < -0.1f && pos.y < 1.3f && pos.y > 0.3f)
            {
                graphnodes[0].GetComponent<Renderer>().material.color = Color.green;
            }else { graphnodes[0].GetComponent<Renderer>().material.color = Color.gray; }
            if (pos.x > 1.6f && pos.x < 3.3f && pos.y < 1.3f && pos.y > 0.3f)
            {
                graphnodes[2].GetComponent<Renderer>().material.color = Color.green;
            }else { graphnodes[2].GetComponent<Renderer>().material.color = Color.gray; }



            if (pos.x < 1.6f && pos.x > -0.1f && pos.y < -0.8f && pos.y > -1.7f)         // bottom subspaces
            {
                graphnodes[7].GetComponent<Renderer>().material.color = Color.green;
            }else { graphnodes[7].GetComponent<Renderer>().material.color = Color.gray; }
            if (pos.x > -1.8f && pos.x < -0.1f && pos.y < -0.8f && pos.y > -1.7f)
            {
                graphnodes[6].GetComponent<Renderer>().material.color = Color.green;
            }else { graphnodes[6].GetComponent<Renderer>().material.color = Color.gray; }
            if (pos.x > 1.6f && pos.x < 3.3f && pos.y < -0.8f && pos.y > -1.7f)
            {
                graphnodes[8].GetComponent<Renderer>().material.color = Color.green;
            }else { graphnodes[8].GetComponent<Renderer>().material.color = Color.gray; }
        }
        //float ii = -1 * (Camera.main.gameObject.transform.position.z);
        //    foreach (GameObject item in all_outlines)
        //    {
        //        if (-1 * (Camera.main.gameObject.transform.position.z) > (item.transform.localPosition.y / 5.5f))
        //        {
        //            item.SetActive(true);
        //            if (item != latest)
        //            {
        //                latest = item;
        //                y_comp = item.transform.localPosition.y + 0.3f;     // updating the y_comp so that when i move an object, it will be placed in currently active subspace
        //            }
        //        }
        //    }
        //    currentCam = Camera.main.gameObject.transform.position;
        //    foreach (GameObject item in all_outlines)
        //    {
        //        if (item != latest) { item.SetActive(false); }
        //    }
        //GameObject.Find("Text1").GetComponent<TextMesh>().text = ii.ToString() + "  " + (latest.transform.localPosition.y / 5.5f).ToString();
        if (inLerp)
        {
            focus.localPosition = Vector3.Lerp(focus.localPosition, newpos, Time.deltaTime * 3f);
            focus.localScale = Vector3.Lerp(focus.localScale, newscale, Time.deltaTime * 3f);
            if (Mathf.Abs(focus.localPosition.x - newpos.x) < 0.05f &&
                Mathf.Abs(focus.localPosition.y - newpos.y) < 0.05f &&
                Mathf.Abs(focus.localPosition.z - newpos.z) < 0.05f &&
                Mathf.Abs(focus.localScale.x - newscale.x) < 0.05f &&
                Mathf.Abs(focus.localScale.y - newscale.y) < 0.05f &&
                Mathf.Abs(focus.localScale.z - newscale.z) < 0.05f)
            {
                focus.localPosition = newpos;
                focus.localScale = newscale;
                inLerp = false;
            }
        }   
    }
    static int count= 0;
    public static void make_subspaces(){
        count = 0;
        subspaces = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var cube = UnityEngine.Object.Instantiate(Resources.Load("cube")) as GameObject;
                
                var rend = cube.GetComponent<Renderer>();
                rend.enabled = true;
                rend.material.color = Color.black;
                cube.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
                cube.transform.localPosition = new Vector3(x_pos[i], y_pos, z_pos[j]);
                cube.transform.localScale = new Vector3(7.2f, 5f, 0.1f);
                cube.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
                cube.layer = LayerMask.NameToLayer("Ignore Raycast");
                cube.GetComponent<spaceTapped>().ID = count; count++;
                cube.SetActive(false);
                if (j == 1 && i ==0) { cube.SetActive(true); focus25 = cube.transform; cube.name = "subspace_2x2"; }// smokey map
                if (j == 0 && i == 0) { cube.SetActive(true); focus1 = cube.transform; cube.name = "subspace_3x2"; }// individual maps
                if (j == 0 && i == 1) { cube.SetActive(true); cube.name = "subspace_3x3"; }
                if (j == 0 && i == 2) { cube.SetActive(true); cube.name = "subspace_3x1"; }
                if (j == 1 && i == 1) {
                    cube.SetActive(true);
                    focus2 = cube.transform;
                    cube.transform.localPosition = new Vector3(x_pos[i]-0.08f, y_pos, z_pos[j] + 0.14f); cube.name = "subspace_2x3";
                }// PCP
                if (j == 1 && i == 2) { cube.SetActive(true); focus3 = cube.transform; cube.name = "subspace_2x1"; }// scatterplot
                if (j == 2 && i == 2) { cube.SetActive(true); focus4 = cube.transform; cube.name = "subspace_1x1"; }// ENV scatterplot
                if (j == 2 && i == 1) { cube.SetActive(true); cube.name = "subspace_1x3"; }
                if (j == 2 && i == 0) { cube.SetActive(true); cube.name = "subspace_1x2"; }
                subspaces.Add(cube);
                Shader shader = Shader.Find("Standard");
                rend.material.shader = shader;
                rend.material.color = Color.black;
                cube.GetComponent<Renderer>().material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
                cube.GetComponent<Renderer>().material.SetFloat("_SpecularHighlights", 0f);
                var mesh = cube.GetComponent<MeshFilter>();
                cube_mesh = mesh.mesh;
                mesh.mesh = null;

                //var col = cube.GetComponent<BoxCollider>();                 // removing box collider from prefab...
                //col.enabled = false;
            }
        }
        //focus4.localPosition = new Vector3(17.4f, -0.2f, -0.6f);
    }
    public static void makeGraph()
    {
        foreach(GameObject i in graphnodes)
        {
            foreach(GameObject j in graphnodes)
            {
                if(i != j)
                {
                    if(Math.Abs(j.transform.localPosition.x - i.transform.localPosition.x) < 7.5f && Math.Abs(j.transform.localPosition.z - i.transform.localPosition.z) < 1)
                    {
                        if (int.Parse(i.name) < int.Parse(j.name))
                        {
                            var link = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                            link.transform.parent = i.transform;
                            link.transform.localScale = new Vector3(0.2f, 2f, 0.12f);
                            link.transform.localPosition = new Vector3(1.7f, 0, 0);
                            link.transform.localRotation = Quaternion.Euler(0, 0, 90);
                            link.GetComponent<Renderer>().material = white;
                            link.GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
                    if(Math.Abs(j.transform.localPosition.x - i.transform.localPosition.x) < 1f && Math.Abs(j.transform.localPosition.z - i.transform.localPosition.z) < 4.3f)
                    {
                        if(int.Parse(i.name) < int.Parse(j.name))
                        {
                            var link = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                            link.transform.parent = i.transform;
                            link.transform.localScale = new Vector3(2, 0.1f, 0.15f);
                            link.transform.localPosition = new Vector3(0.04f, 0f, -1.1f);
                            link.transform.localRotation = Quaternion.Euler(90, 0, 90);
                            link.GetComponent<Renderer>().material = white;
                            link.GetComponent<Renderer>().material.color = Color.white;
                        }
                        
                    }
                }
            }
        }
    }

    public static List<CubeObject> target_outlines;
    public static List<GameObject> graphnodes;
    public static void make_AllOutline(){

        target_outlines = new List<CubeObject>();
        graphnodes = new List<GameObject>();
        if(SmokeyController.detectedImageCount == 0)
        {
            outlines(-0.2f);                      // for taking screenshots, make call to outlines();
            subspaces_3D();                       // otherwise use boardOutline();
            makeGraph();
        }
        else
        {
            outlines(-0.2f);
            //outlines(8.25f);
            //make_outline(12.2f);
            //make_outline(28.2f);  
            subspaces_3D();
            //ppd();
        }

    }
    public static void subspaces_3D() {
        
        foreach (CubeObject item in target_outlines)
        {
            Transform image1 = GameObject.Instantiate(fab) as Transform;
            image1.parent = item.left.transform;
            //image1.localPosition = new Vector3(0, 0, -210);
            //image1.localScale = new Vector3(46.64622f, 0.132f, 0.1f);
            image1.localPosition = new Vector3(0, 0, -353.5f);
            image1.localScale = new Vector3(78.5f, 0.132f, 0.1f);
            image1.localRotation = Quaternion.Euler(0, 90, 0);
            image1.name = item.left.name;

            Transform image2 = GameObject.Instantiate(fab) as Transform;
            image2.parent = item.right.transform;
            //image2.localPosition = new Vector3(0, 0, -210);
            //image2.localScale = new Vector3(46.64622f, 0.132f, 0.1f);
            image2.localPosition = new Vector3(0, 0, -353.5f);
            image2.localScale = new Vector3(78.5f, 0.132f, 0.1f);
            image2.localRotation = Quaternion.Euler(0, 90, 0);
            image2.name = item.right.name;

            Transform image3 = GameObject.Instantiate(fab) as Transform;
            image3.parent = item.top.transform;
            //image3.localPosition = new Vector3(0, 314f, 0f);
            //image3.localScale = new Vector3(70.60487f, 0.132f, 0.1f);
            image3.localPosition = new Vector3(0, 531.9f, 0f);
            image3.localScale = new Vector3(117.5f, 0.132f, 0.1f);
            image3.localRotation = Quaternion.Euler(180, 0, 90);
            image3.name = item.top.name;

            Transform image4 = GameObject.Instantiate(fab) as Transform;
            image4.parent = item.bottom.transform;
            //image4.localPosition = new Vector3(0, 314f, 0f);
            //image4.localScale = new Vector3(70.60487f, 0.132f, 0.1f);
            image4.localPosition = new Vector3(0, 531.9f, 0f);
            image4.localScale = new Vector3(117.5f, 0.132f, 0.1f);
            image4.localRotation = Quaternion.Euler(180, 0, 90);
            image4.name = item.bottom.name;
        }
    }
    // 6.17,  -0.0128, 0        parallel   -90,90,0
    // 3.204, -0.0128, -1.867   ppd     -90, 90, 0
    // -0.002, -1.694, -1.253   bottom  0, 0, 0
    //402BA9FF purple
    public static void ppd()
    {
        foreach (CubeObject item in each_outline)
        {
            Transform image1 = GameObject.Instantiate(fab) as Transform;
            image1.parent = item.left.transform;
            image1.localPosition = new Vector3(0, 0, -208.6f);
            image1.localScale = new Vector3(46.2765f, 0.132f, 0.1f);
            image1.localRotation = Quaternion.Euler(0, 90, 0);

            Transform image2 = GameObject.Instantiate(fab) as Transform;
            image2.parent = item.right.transform;
            image2.localPosition = new Vector3(0, 0, -208.6f);
            image2.localScale = new Vector3(46.2765f, 0.132f, 0.1f);
            image2.localRotation = Quaternion.Euler(0, 90, 0);

            Transform image3 = GameObject.Instantiate(fab) as Transform;
            image3.parent = item.top.transform;
            image3.localPosition = new Vector3(0, 314f, 0f);
            image3.localScale = new Vector3(69.34119f, 0.132f, 0.1f);
            image3.localRotation = Quaternion.Euler(180, 0, 90);

            Transform image4 = GameObject.Instantiate(fab) as Transform;
            image4.parent = item.bottom.transform;
            image4.localPosition = new Vector3(0, 314f, 0f);
            image4.localScale = new Vector3(69.34119f, 0.132f, 0.1f);
            image4.localRotation = Quaternion.Euler(180, 0, 90);
        }
    }
    public static void merge_spaces()
    {
        print(each_outline[11].right.transform.position);
        print(each_outline[0].left.transform.position);
        if (each_outline[11].left.transform.position.z - each_outline[0].left.transform.position.z == 0)    //checking if z-AXIS Is alligned        // add little +- range
        {   
            foreach(CubeObject item in each_outline)
            {
                if(true)
                {
                    foreach(CubeObject cube in each_outline)
                    {
                        if(cube.left.transform.position.x < item.right.transform.position.x && cube.left.transform.position.x > item.left.transform.position.x)
                        {
                            cube.left.SetActive(false);
                            item.right.SetActive(false);
                        }
                    }
                }
            }
        }     
    }
    static void translateX(float diff)
    {
        for(int i = 0; i < 9; i++)
        {
            Vector3 left = each_outline[i].left.transform.position;
            left = new Vector3(left.x + diff, left.y, left.z);
            each_outline[i].left.transform.position = left;

            Vector3 right = each_outline[i].right.transform.position;
            right = new Vector3(right.x + diff, right.y, right.z);
            each_outline[i].right.transform.position = right;

            Vector3 top = each_outline[i].top.transform.position;
            top = new Vector3(top.x + diff, top.y, top.z);
            each_outline[i].top.transform.position = top;

            Vector3 bottom = each_outline[i].left.transform.position;
            bottom = new Vector3(bottom.x + diff, bottom.y, bottom.z);
            each_outline[i].bottom.transform.position = bottom;
        }
    }
    public static List<GameObject> greens = new List<GameObject>();
    public static void outlines(float y){
        var top_left = parent_axis(-7.81f, y, 3.291f, 4.2f, "1x1");
        var top_middle = parent_axis(-0.68f, y, 3.291f, 4.2f, "1x2");
        var top_right = parent_axis(6.43f, y, 3.291f, 4.2f, "1x3");
        var middle_left = parent_axis(-7.81f, y, -0.891f, 4.2f, "2x1");
        var middle_middle = parent_axis(-0.68f, y, -0.891f, 4.2f, "2x2");
        var middle_right = parent_axis(6.43f, y, -0.891f, 4.2f, "2x3");
        var bottom_left = parent_axis(-7.81f, y, -5.065f, 4.2f, "3x1");
        var bottom_middle = parent_axis(-0.68f, y, -5.065f, 4.2f,"3x2");
        var bottom_right = parent_axis(6.43f, y, -5.065f, 4.2f,"3x3");
    }
    public static void board_outlines(float y){
        float scale = 5;
        var top_left = Boardparent_axis(-8.3f, y, 2.82f, scale);
        var top_middle = Boardparent_axis(-0.55f, y, 2.82f, scale);
        var top_right = Boardparent_axis(7.21f, y, 2.82f, scale);
        var middle_left = Boardparent_axis(-8.3f, y, -2.15f, scale);
        var middle_middle = Boardparent_axis(-0.55f, y, -2.15f, scale);
        var middle_right = Boardparent_axis(7.21f, y, -2.15f, scale);
        var bottom_left = Boardparent_axis(-8.3f, y, -7.13f, scale);
        var bottom_middle = Boardparent_axis(-0.55f, y, -7.13f, scale);
        var bottom_right = Boardparent_axis(7.21f, y, -7.13f, scale);
    }

    public static CubeObject Boardparent_axis(float x, float y, float z, float scale)
    {
        CubeObject aCube = new CubeObject();
        Color color = Color.white;
        var instance = GameObject.CreatePrimitive(PrimitiveType.Cube);
        instance.GetComponent<Renderer>().material.color = color;
        instance.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        instance.transform.localPosition = new Vector3(x, y, z);
        instance.transform.localScale = new Vector3(0.03f, scale, 0.03f);
        instance.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        aCube.left = instance;

        var right = GameObject.CreatePrimitive(PrimitiveType.Cube);
        right.GetComponent<Renderer>().material.color = color;
        right.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        right.transform.localPosition = new Vector3(x + 7.74f, y, z);
        right.transform.localScale = new Vector3(0.03f, scale, 0.03f);
        right.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        aCube.right = right;

        var top = GameObject.CreatePrimitive(PrimitiveType.Cube);
        top.GetComponent<Renderer>().material.color = color;
        top.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        top.transform.localPosition = new Vector3(x + 3.88f, y, z + 2.49f);
        top.transform.localScale = new Vector3(-7.75f, 0.02f, 0.05f);
        top.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        aCube.top = top;

        var bottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bottom.GetComponent<Renderer>().material.color = color;
        bottom.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        bottom.transform.localPosition = new Vector3(x + 3.88f, y, z - 2.49f);
        bottom.transform.localScale = new Vector3(-7.75f, 0.02f, 0.05f);
        bottom.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        aCube.bottom = bottom;

        //var space = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //space.transform.parent = aCube.left.transform;
        //space.transform.localPosition = new Vector3(118.7f, 0, 187.6f);
        //space.transform.localScale = new Vector3(235.931f, 1, 365.6683f);
        //space.transform.localRotation = Quaternion.Euler(0, 0, 0);
        ////Material newmat = new Material("space");
        //Material newmat = (Material)Resources.Load("Materials/space");
        ////space.GetComponent<Renderer>().material = newmat;
        //space.GetComponent<MeshRenderer>().material = newmat;
        ////FF263E24
        //Color color1 = new Color(0xFF, 0x26, 0x3E, 0x24);
        ////color1.a = 0.2f;
        //space.GetComponent<Renderer>().material.color = color1;

        target_outlines.Add(aCube);
        //aCube.name = each_outline.Count.ToString();
        each_outline.Add(aCube);
        return aCube;
    }
    public static CubeObject parent_axis(float x, float y, float z, float scale, string name){
        CubeObject aCube = new CubeObject();
        Color color = Color.white;
        var instance = GameObject.CreatePrimitive(PrimitiveType.Cube);
        instance.GetComponent<Renderer>().material.color = color;
        instance.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        instance.transform.localPosition = new Vector3(x, y, z);
        instance.transform.localScale = new Vector3(0.03f, scale, 0.03f);
        instance.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        instance.name = "none";
        aCube.left = instance;

        GameObject box = new GameObject();
        box.AddComponent<BoxCollider>();
        var collider = box.GetComponent<BoxCollider>();
        box.transform.parent = instance.transform;
        collider.transform.localPosition = new Vector3(117.8f, 0, 1.3f);
        collider.transform.localScale = new Vector3(0, 1, 240);
        collider.transform.localRotation = Quaternion.Euler(0, 90, 0);
        box.name = "subspace_" + name;

        var right = GameObject.CreatePrimitive(PrimitiveType.Cube);
        right.GetComponent<Renderer>().material.color = color;
        right.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        right.transform.localPosition = new Vector3(x+7.11f, y, z);
        right.transform.localScale = new Vector3(0.03f, scale, 0.03f);
        right.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        right.name = "none";
        aCube.right = right;

        var top = GameObject.CreatePrimitive(PrimitiveType.Cube);
        top.GetComponent<Renderer>().material.color = color;
        top.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        top.transform.localPosition = new Vector3(x+3.548f,y,z+2.09f);
        top.transform.localScale = new Vector3(-7.14f, 0.02f, 0.05f);
        top.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        top.name = "none";
        aCube.top = top;

        var bottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bottom.GetComponent<Renderer>().material.color = color;
        bottom.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        bottom.transform.localPosition = new Vector3(x+3.548f, y,z-2.09f);
        bottom.transform.localScale = new Vector3(-7.14f, 0.02f, 0.05f);
        bottom.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        bottom.name = "none";
        aCube.bottom = bottom;


        var graph = GameObject.CreatePrimitive(PrimitiveType.Cube);
        graph.transform.parent = SmokeyController.all_targets[SmokeyController.detectedImageCount].transform;
        graph.transform.localPosition = new Vector3(x + 3.57f, y + 9.6f, z);
        graph.transform.localRotation = Quaternion.Euler(0, 0, 0);
        graph.transform.localScale = new Vector3(2f, 2f, 2f);
        graph.GetComponent<Renderer>().material = white;
        graph.GetComponent<Renderer>().material.color = Color.gray;
        graph.name = (graphnodes.Count + 1).ToString();
        graphnodes.Add(graph);

        //var space = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //space.transform.parent = aCube.left.transform;
        //space.transform.localPosition = new Vector3(118.7f, 0, 187.6f);
        //space.transform.localScale = new Vector3(235.931f, 1, 365.6683f);
        //space.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //Material newmat = (Material)Resources.Load("Materials/space");
        //space.GetComponent<MeshRenderer>().material = newmat;
        ////FF263E24
        ////402BA9FF purple
        //Color color1 = new Color(0xFF, 0x26, 0x3E, 0x24);
        //space.GetComponent<Renderer>().material.color = color1;



        target_outlines.Add(aCube);
        each_outline.Add(aCube);
        return aCube;
    }



    public static void Highlight()
    {
        foreach(GameObject item in greens)
        {
            item.SetActive(true);
        }
    }

    private static GameObject Instantiate(object p)
    {
        throw new NotImplementedException();
    }
    public static void show_subspaces()
    {
        foreach (GameObject e in subspaces)
        {
            e.SetActive(true);
        }
    }
    public static void hide_subspaces()
    {
        foreach(GameObject e in subspaces)
        {
            e.SetActive(false);
        }
    }

    public static List<Vector3> findNeighbors(Vector3 position)
    {
        List<Vector3> neighbors = new List<Vector3>();
        neighbors.Add(new Vector3(x_pos[1], y_comp, z_pos[1]));     // adding the middle subspace to neighbors
        if(position.x <= x_pos[1])
        {
            if(position.z <= z_pos[1])
            {
                neighbors.Add(new Vector3(x_pos[0], y_comp, z_pos[0]));
                neighbors.Add(new Vector3(x_pos[0], y_comp, z_pos[1]));                 ///  y_comp
                neighbors.Add(new Vector3(x_pos[1], y_comp, z_pos[0]));
            }
            else               // position.z > z_pos[1] 
            {
                neighbors.Add(new Vector3(x_pos[0], y_comp, z_pos[1]));
                neighbors.Add(new Vector3(x_pos[0], y_comp, z_pos[2]));
                neighbors.Add(new Vector3(x_pos[1], y_comp, z_pos[2]));
            }
        }
        else                  // position.x > x_pos[1]
        {
            if(position.z <= z_pos[1])
            {
                neighbors.Add(new Vector3(x_pos[2], y_comp, z_pos[0]));
                neighbors.Add(new Vector3(x_pos[2], y_comp, z_pos[1]));
                neighbors.Add(new Vector3(x_pos[1], y_comp, z_pos[0]));
            }
            else             // position.z > z_pos[1]  
            {
                neighbors.Add(new Vector3(x_pos[2], y_comp, z_pos[1]));
                neighbors.Add(new Vector3(x_pos[2], y_comp, z_pos[2]));
                neighbors.Add(new Vector3(x_pos[1], y_comp, z_pos[2]));
            }
        }
        return neighbors;
    }
    
    static bool inLerp = false;
    public static void smokey_min()
    {
        focus = subspaces[1].transform;
        //focus.localPosition = new Vector3(-3.15f, -0.2f, 1.5f);
        focus.localPosition = new Vector3(5f, -0.2f, -1.1f);
        focus.localScale = new Vector3(2, 1.4f, 0.1f);
        //focus.gameObject.layer = LayerMask.NameToLayer("Default");
        if(cube_mesh != null)
        {
            var mesh = focus.GetComponent<MeshFilter>();
            //mesh.mesh = cube_mesh;
        }
    }
    public static void layered_min() {
        focus = focus1;
        //focus.localPosition = new Vector3(-3.15f, -0.2f, 0.2f);
        focus.localPosition = new Vector3(5f, 0f, -2.3f);
        focus.localScale = new Vector3(2, 1.4f, 0.1f);
        LayeredMapping.flatten();
        //focus.gameObject.layer = LayerMask.NameToLayer("Default");
        if (cube_mesh != null)
        {
            var mesh = focus.GetComponent<MeshFilter>();
            //mesh.mesh = cube_mesh;
        }
    }
    public static void PCP_min() {
        focus = focus2;
        //focus.localPosition = new Vector3(-3.15f, -0.2f, -1.1f);
        focus.localPosition = new Vector3(5f, 0.1f, -3.6f);
        focus.localScale = new Vector3(2, 1.4f, 0.1f);
        if (cube_mesh != null)
        {
            var mesh = focus.GetComponent<MeshFilter>();
            //mesh.mesh = cube_mesh;
        }
    }
    public static void SP_min()
    {
        focus = focus3;
        focus.localPosition = new Vector3(-3.15f, -0.2f, -1.8f);
        focus.localScale = new Vector3(2, 1.4f, 0.1f);
        //focus.gameObject.layer = LayerMask.NameToLayer("Default");
        if (cube_mesh != null)
        {
            var mesh = focus.GetComponent<MeshFilter>();
            //mesh.mesh = cube_mesh;
        }
    }
    public static void SP2_min()
    {
        focus = focus4;
        focus.localPosition = new Vector3(2.6f, -0.7f, -2.3f);
        focus.localScale = new Vector3(2, 1.4f, 0.1f);
        //focus.gameObject.layer = LayerMask.NameToLayer("Default");
        if (cube_mesh != null)
        {
            var mesh = focus.GetComponent<MeshFilter>();
            //mesh.mesh = cube_mesh;
        }
    }
    public static void space_tap(int ID) {
        if (ID == 1)
        {
            newpos = new Vector3(2.8f, -0.2f, -1.5f);
        }
        if (ID == 0)
        {
            newpos = new Vector3(2.8f, -0.2f, -6.6f);
            LayeredMapping.unflatten();
        }
        if(ID == 4)
        {
            newpos = new Vector3(10.1f, -0.2f, -1.5f);
        }
        if(ID == 7)
        {
            newpos = new Vector3(17.4f, -0.2f, -1.5f);
        }
        focus = subspaces[ID].transform;
        var mesh = focus.GetComponent<MeshFilter>();
        //cube_mesh = mesh.mesh;
        mesh.mesh = null;
        focus.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        newscale = new Vector3(7.2f, 5, 0.1f);
        inLerp = true;
    }
}