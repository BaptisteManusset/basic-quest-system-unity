using UnityEngine;


namespace ItsBaptiste.QuestSystem
{
  [DisallowMultipleComponent]
  public class QuestElement : MonoBehaviour
  {
    public Step quest;
    public QuestElement nextQuestElement;
    public QuestElement nextQuestElementWithError;


    [ContextMenu("Reset les étapes")]

    public void ResetStep()
    {
      QuestManager.ResetStep();
    }


    [ContextMenu("Completer l'étape")]
    public void CompleteStep()
    {
      QuestManager.CompleteStep();
    }

    [ContextMenu("Completer l'étape avec erreur")]
    public void CompleteStepWithError()
    {
      QuestManager.CompleteStepWithError();
    }

    [ContextMenu("Creer scriptable object")]
    public void CreateStep()
    {
      quest = QuestManager.CreateSCriptableObject(gameObject.name);
    }


    #region Editor
    private void OnDrawGizmos()
    {
      Color green = new Color(0.33f, 0.67f, 0.42f);

      Gizmos.color = (quest == null ? Color.red : green);
      Gizmos.DrawWireSphere(transform.position, .75f); ;


      if (nextQuestElement != null)
        Debug.DrawLine(transform.position, nextQuestElement.transform.position);

      if (nextQuestElementWithError != null)
      {
        Debug.DrawLine(transform.position, nextQuestElementWithError.transform.position, Color.red);
      }

    }

    #endregion



  }


}

