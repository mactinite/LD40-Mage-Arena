using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(SimpleFSM.State))]
public class StateEditor : Editor
{

    private ReorderableList transitionList;
    private SerializedProperty selectedTransition = null;

    private void OnEnable()
    {
        var state = target as SimpleFSM.State;
        selectedTransition = null;
        transitionList = new ReorderableList(serializedObject,
        serializedObject.FindProperty("transitions"),
        true, true, true, true)
        {
            drawHeaderCallback = (Rect rect) =>
            {
                EditorGUI.LabelField(rect, "Transitions");
            },
            onSelectCallback = (ReorderableList list) =>
            {
                selectedTransition = list.serializedProperty.GetArrayElementAtIndex(list.index);
            },
            drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = transitionList.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                EditorGUI.LabelField(
                new Rect(rect.x, rect.y, 200, EditorGUIUtility.singleLineHeight),
                new GUIContent(state.name + " ->"));
                EditorGUI.PropertyField(
                new Rect(rect.x + 200, rect.y, rect.width - 200, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("trueState"), GUIContent.none);
            }
        };
    }

    public override void OnInspectorGUI()
    {
        var state = target as SimpleFSM.State;


        serializedObject.Update();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("actions"), new GUIContent("Actions"), true);
        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();


        transitionList.DoLayoutList();

        if (selectedTransition != null)
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.LabelField(state.name + " -> " + state.transitions[transitionList.index].trueState.ToString(), EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(selectedTransition.FindPropertyRelative("conditions"), new GUIContent("Conditions"), true);
            EditorGUILayout.EndVertical();
        }

        serializedObject.ApplyModifiedProperties();

        EditorUtility.SetDirty(target);
}

}
