using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EdgeBundler : Graphs
{

    static float northPull = 0;
    static float westPull = 0;
    static float eastPull = 0;
    static float southPull = 0;

    public void BuildGraph(Transform[] transforms, string color, Transform nodePrefab)
    {
        Transform[] bundleHeads;

        int closestNeighborIndex;
        int closestBundleIndex;
        int[] bundleIndexes = new int[transforms.Count()];      // values will start at 1
        int bundleNumber = 0;   // indexing will start at 1, stored in "bundleIndexes" list
        int localBundle;
        int connectionCnt;

        float layerOffset = .5f; //larger will create taller graph
        float xTotal;
        float yTotal;
        float zTotal;
        float curveWeight = .05f;

        Connection conn = new Connection();

        for (int i = 0; i < bundleIndexes.Count(); i++)
        {
            closestNeighborIndex = findClosestNeighbor(transforms, i);

            if (bundleIndexes[i] != 0)
            {
                if (bundleIndexes[closestNeighborIndex] != 0)
                {

                }
                else
                {
                    bundleIndexes[closestNeighborIndex] = bundleIndexes[i];
                }
            }
            else if (bundleIndexes[closestNeighborIndex] != 0)
            {
                bundleIndexes[i] = bundleIndexes[closestNeighborIndex];
            }
            else
            {
                localBundle = -1;
                for (int j = 0; j < bundleIndexes.Count(); j++)
                {
                    if (localBundle == -1 && bundleIndexes[j] != 0 && (Vector3.Distance(transforms[i].position, transforms[j].position) <= .02))
                    {
                        localBundle = j;
                    }
                }

                if (localBundle != -1)
                {
                    bundleIndexes[i] = localBundle;
                    bundleIndexes[closestNeighborIndex] = localBundle;
                }
                else
                {
                    bundleNumber += 1;
                    bundleIndexes[i] = bundleNumber;
                    bundleIndexes[closestNeighborIndex] = bundleNumber;
                }

            }
        }
        bundleHeads = new Transform[bundleNumber];

        for (int i = 1; i < bundleNumber + 1; i++)
        {
            xTotal = 0;
            yTotal = 0;
            zTotal = 0;
            connectionCnt = 0;

            Transform nodeTrf = GameObject.Instantiate(nodePrefab) as Transform;
            nodeTrf.parent = TrackableMonitor.mTrackableBehaviour.transform;

            for (int j = 0; j < bundleIndexes.Count(); j++)
            {
                if (bundleIndexes[j] == i)
                {
                    xTotal = xTotal += transforms[j].localPosition.x;
                    yTotal = yTotal += transforms[j].localPosition.y;
                    zTotal = zTotal += transforms[j].localPosition.z;
                    connectionCnt += 1;
                }

            }

            nodeTrf.localPosition = new Vector3(xTotal / connectionCnt, layerOffset + (yTotal / connectionCnt) * .3f, zTotal / connectionCnt + northPull);
            nodeTrf.localRotation = Quaternion.identity;
            nodeTrf.localScale = new Vector3(.0f, .0f, .0f);

            nodes.Add(nodeTrf);

            bundleHeads[i - 1] = nodeTrf;

        }

        for (int i = 0; i < transforms.Count(); i++)
        {
            closestBundleIndex = closestBundle(transforms[i], bundleHeads);

            ConnectionManager.CreateConnection(transforms[i], bundleHeads[closestBundleIndex]);
            conn = ConnectionManager.FindConnection(transforms[i], bundleHeads[closestBundleIndex]);

            conn.points[0].color = SetColor(color);
            conn.points[1].color = SetColor(color);

            conn.points[0].weight = curveWeight;
            conn.points[1].weight = curveWeight;

            conn.points[0].direction = ConnectionPoint.ConnectionDirection.North;
            conn.points[1].direction = ConnectionPoint.ConnectionDirection.South;

            connections.Add(conn);
        }

        //recursivle bundles until convergence
        if (bundleHeads.Count() > 1)
        {
            BuildGraph(bundleHeads, color, nodePrefab);
        }
        else
        { }

    }

    public static int findClosestNeighbor(Transform[] transforms, int index)
    {
        float closestProximity = 99999;
        int closestNeighbor = -1;

        for (int i = 0; i < transforms.Count(); i++)
        {
            if (index != i)
            {
                if (Vector3.Distance(transforms[index].position, transforms[i].position) <= closestProximity)
                {
                    closestProximity = Vector3.Distance(transforms[index].position, transforms[i].position);
                    closestNeighbor = i;
                }
            }
        }
        return closestNeighbor;
    }

    public static int closestBundle(Transform dp, Transform[] bundleHeads)
    {
        int closestBundleIndex = -1;
        float closestProximity = 99999;

        for (int i = 0; i < bundleHeads.Count(); i++)
        {
            if (Vector3.Distance(dp.position, bundleHeads[i].position) <= closestProximity)
            {
                closestProximity = Vector3.Distance(dp.position, bundleHeads[i].position);
                closestBundleIndex = i;
            }
        }

        return closestBundleIndex;
    }

    public static Color SetColor(string c)
    {
        Color color = Color.white;

        switch (c)
        {
            case "red":
                color = Color.red;
                break;
            case "blue":
                color = Color.blue;
                break;
            case "green":
                color = Color.green;
                break;
            case "magenta":
                color = Color.magenta;
                break;
            case "yellow":
                color = Color.yellow;
                break;
            case "cyan":
                color = Color.cyan;
                break;
            case "unavailable":
                color = Color.white; ;
                break;
            default:
                break;
        }
        return color;
    }


}
