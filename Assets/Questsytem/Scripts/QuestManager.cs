using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ItsBaptiste.QuestSystem
{

  public class QuestManager : MonoBehaviour
  {
    #region singleton
    public static QuestManager instance;
    #endregion

    [Header("Initialisation")]
    private List<QuestElement> questElements;
    public List<QuestViewer> questViewers;
    public QuestElement firstStep;

    [Header("Etape Actuelle")]
    public QuestElement actualStep;

    public static bool isCompleted = false;




    private void Awake()
    {
      if (instance == null)
      {
        instance = this;
      } else
      {
        Debug.LogError("Quest Manager allready exist");
      }

      actualStep = firstStep;

      QuestManager.instance.UpdateUis();
    }

    //public static void Subscribe(QuestElement element)
    //{
    //  QuestManager.instance.questElements.Add(element);
    //}

    public static void CompleteStep()
    {

      if (QuestManager.instance.actualStep != null)
      {
        QuestManager.instance.actualStep = QuestManager.instance.actualStep.nextQuestElement;
      } else
      {
        Debug.Log("il n'y a pas de suite");
      }
    }
    public static void CompleteStepWithError()
    {
      if (QuestManager.instance.actualStep == null) return;

      if (QuestManager.instance.actualStep.nextQuestElementWithError != null)
      {
        QuestManager.instance.actualStep = QuestManager.instance.actualStep.nextQuestElementWithError;
      } else
      {
        Debug.Log("il n'y a pas de suite");
      }
    }
    public static void ResetStep()
    {
      if (QuestManager.instance.firstStep == null) return;
      QuestManager.instance.actualStep = QuestManager.instance.firstStep;
    }

    private void UpdateUis()
    {
      foreach (var item in questViewers)
      {
        item.UpdateUi();
      }
    }



    #region editor
    private void OnDrawGizmos()
    {
      if (actualStep)
      {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(actualStep.transform.position, .5f);
      }
    }
    #endregion


    public static Step CreateSCriptableObject(string name = null, string description = null)
    {
      Step asset = ScriptableObject.CreateInstance<Step>();

      AssetDatabase.CreateAsset(asset, "Assets/Questsytem/Step/" + (name.Length == 0 ? "Step " + Time.time.ToString("f6") : name) + ".asset");
      AssetDatabase.SaveAssets();

      asset.title = name;
      asset.description = description;
      return asset;
    }
  }



}
