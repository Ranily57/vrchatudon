using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class RenameBoneHierarchy : EditorWindow
{
    private GameObject sourceArmature;
    private GameObject destinationArmature;

    public float proximityThreshold = 0.1f;

    [MenuItem("Tools/Rename Bone Hierarchy")]
    public static void ShowWindow()
    {
        GetWindow<RenameBoneHierarchy>("Rename Bone Hierarchy");
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        sourceArmature = (GameObject)EditorGUILayout.ObjectField("Source Armature", sourceArmature, typeof(GameObject), true);
        destinationArmature = (GameObject)EditorGUILayout.ObjectField("Destination Armature", destinationArmature, typeof(GameObject), true);
        proximityThreshold = EditorGUILayout.FloatField("Proximity Threshold", proximityThreshold);

        if (GUILayout.Button("Rename Bones"))
        {
            RenameBones();
        }

        EditorGUILayout.EndVertical();
    }

    private void RenameBones()
    {
        if (sourceArmature == null || destinationArmature == null)
        {
            Debug.LogError("Source or Destination Armature is not assigned.");
            return;
        }

        List<Transform> sourceBones = GetChildBonesRecursive(sourceArmature.transform);
        List<Transform> destinationBones = GetChildBonesRecursive(destinationArmature.transform);

        foreach (Transform destBone in destinationBones)
        {
            if (IsBoneHidden(destBone))
            {
                continue;
            }

            Transform closestSourceBone = GetClosestBone(destBone, sourceBones);

            if (closestSourceBone != null)
            {
                destBone.name = closestSourceBone.name;
            }
            else
            {
                Debug.LogWarning($"No matching bone found for {destBone.name}");
            }
        }
    }

    private List<Transform> GetChildBonesRecursive(Transform parent)
    {
        List<Transform> bones = new List<Transform>();

        foreach (Transform child in parent)
        {
            if (!IsBoneHidden(child))
            {
                bones.Add(child);
                bones.AddRange(GetChildBonesRecursive(child));
            }
        }

        return bones;
    }

    private bool IsBoneHidden(Transform bone)
    {
        return bone.name.StartsWith(".");
    }

    private Transform GetClosestBone(Transform destinationBone, List<Transform> sourceBones)
    {
        Transform closestBone = null;
        float closestDistance = float.MaxValue;

        foreach (Transform sourceBone in sourceBones)
        {
            float distance = Vector3.Distance(destinationBone.position, sourceBone.position);

            if (distance < closestDistance && distance <= proximityThreshold)
            {
                closestBone = sourceBone;
                closestDistance = distance;
            }
        }

        return closestBone;
    }
}
