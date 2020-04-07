using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ItsBaptiste.QuestSystem
{
  public class QuestEditor : EditorWindow
  {

    QuestElement previousElement;
    QuestElement actualElement;

    bool foldoutOpen = true;


    int toolbarInt = 0;
    string[] toolbarStrings = { "Creer une Step", "blblblbl", "bbllbblsjhdToolbar3" };
    string stepName;
    string stepDescription;


    [MenuItem("Window/QuestEditor")]
    public static void OpenWindow()
    {
      GetWindow<QuestEditor>("Quest editor");
    }

    private void OnGUI()
    {

      toolbarInt = GUILayout.Toolbar(toolbarInt, toolbarStrings);
      switch (toolbarInt)
      {
        case 0:
          GUILayout.Label("Creer une Step");
          GUILayout.Label("Nom");
          stepName = GUILayout.TextField(stepName, 15, "textfield");

          GUILayout.Label("Description");
          stepDescription = GUILayout.TextField(stepDescription, 300, EditorStyles.textArea);

          GUILayout.BeginHorizontal();
          if (GUILayout.Button("Creer un Gameobject Etape"))
          {
            if (Selection.activeGameObject.GetComponent<QuestElement>() == null)
            {
              QuestElement questElement = Selection.activeGameObject.AddComponent<QuestElement>();
              questElement.quest = QuestManager.CreateSCriptableObject(stepName, stepDescription);
            }
          }

          GUILayout.EndHorizontal();

          break;
        case 1:
          break;
        case 2:
          //#region creer une etape
          //if (GUILayout.Button("Creer un Gameobject Etape"))
          //{


          //  #region init
          //  GameObject go = new GameObject();
          //  if (go == null) return;
          //  go.name = "Quest Element";
          //  #endregion

          //  if (Selection.activeGameObject != null)
          //    go.transform.position = Selection.activeGameObject.transform.position;
          //  Selection.activeGameObject = go;

          //  QuestElement questElement = Selection.activeGameObject.AddComponent<QuestElement>();
          //  questElement.quest = CreateSCriptableObject();


          //}
          //#endregion       
          //#region Lier deux etapes
          //foldoutOpen = EditorGUILayout.Foldout(foldoutOpen, "Lier deux etapes");
          //if (foldoutOpen)
          //{
          //  EditorGUILayout.LabelField("Etape précédente");
          //  previousElement = EditorGUILayout.ObjectField(previousElement, typeof(QuestElement), true) as QuestElement;



          //  if (GUILayout.Button("Lier deux etapes"))
          //  {
          //    QuestElement element = Selection.activeGameObject.GetComponent<QuestElement>();

          //    //if (element)
          //    //  element.SetPreviousQuestElement(previousElement);

          //    previousElement.SetNextQuestElement(element);
          //    EditorGUILayout.Space();
          //  }
          //}
          //#endregion
          //#region Add Step
          //if (GUILayout.Button("Ajouter une ScriptableObj etape"))
          //{
          //  QuestElement element = Selection.activeGameObject.GetComponent<QuestElement>();

          //  if (element)
          //  {
          //    if (element.quest == null)
          //      element.quest = CreateSCriptableObject();
          //  }

          //  EditorGUILayout.Space();
          //}

          //#endregion
          break;
      }
    }


   


    public void OnInspectorUpdate()
    {
      this.Repaint();
    }
  }
}

