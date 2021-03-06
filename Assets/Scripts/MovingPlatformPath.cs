﻿using UnityEngine;

public class MovingPlatformPath : MonoBehaviour
{

    const float gizmoSize = 0.3f;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector2 gizmoPosition = GetPathpoint(i);
            Vector2 nextGizmoPosition = GetPathpoint(NextPosition(i));

            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(gizmoPosition, gizmoSize);
            Gizmos.DrawLine(gizmoPosition, nextGizmoPosition);
        }
    }

    public int NextPosition(int i)
    {
        return i == transform.childCount - 1
            ? 0
            : i + 1;
    }

    public Vector2 GetPathpoint(int i)
    {
        return transform.GetChild(i).position;
    }
}
