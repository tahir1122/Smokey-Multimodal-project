using System.Collections.Generic;
using UnityEngine;

public class GestureActionLayers : MonoBehaviour
{                                                   // gesture action for layers
    public float RotationSensitivity = 10.0f;
    private Vector3 manipulationPreviousPosition;
    private float rotationFactor;
    private bool inLerp = false;
    public Vector3 newPos = Vector3.zero;
    void Update()
    {
        //PerformRotation();
        if (inLerp)
        {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, newPos, Time.deltaTime * 8f);
            if (Mathf.Abs(transform.localPosition.x - newPos.x) < 0.1f &&
                Mathf.Abs(transform.localPosition.y - newPos.y) < 0.1f &&
                Mathf.Abs(transform.localPosition.z - newPos.z) < 0.1f)
            {
                inLerp = false;
                completed();
            }
        }
    }
    private void PerformRotation()
    {
        if (GestureManager.IsNavigating)
        {
            rotationFactor = GestureManager.NavigationPosition.x * RotationSensitivity;
            transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
        }
    }
    void PerformManipulationStart(Vector3 position)
    {
        manipulationPreviousPosition = position;
    }
    void PerformManipulationUpdate(Vector3 position)
    {
        if (GestureManager.IsManipulating)
        {
            Vector3 moveVector = Vector3.zero;
            // 4.a: Calculate the moveVector as position - manipulationPreviousPosition.
            moveVector = position - manipulationPreviousPosition;
            // 4.a: Update the manipulationPreviousPosition with the current position.
            manipulationPreviousPosition = position;
            // 4.a: Increment this transform's position by the moveVector.
            this.transform.position += 1.5f * moveVector;
        }
    }
    public void PerformManipulationComplete()
    {
        //List<Vector3> neighbors = new List<Vector3>();
        //Vector3 currentPos = this.transform.localPosition;

        //neighbors = Subspaces.findNeighbors(currentPos);
        //newPos = neighborSelect(neighbors);
        //inLerp = true;
    }
    Vector3 neighborSelect(List<Vector3> neighbors)
    {
        Vector3 newPos = Vector3.zero;
        float tempValue = 100000f;

        foreach (Vector3 item in neighbors)
        {
            float magn = Vector3.Distance(item, this.transform.localPosition);
            if (tempValue > magn)
            {
                tempValue = magn;
                newPos = item;
            }
        }
        return newPos;
    }

    void completed()
    {
        this.transform.localPosition = newPos;

    }
}