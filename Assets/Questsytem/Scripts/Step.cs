using System.Collections.Generic;
using UnityEngine;


namespace ItsBaptiste.QuestSystem
{
  [CreateAssetMenu(fileName = "Step", menuName = "⚙Step", order = 1)]
  public class Step : ScriptableObject
  {
    public string title = "Titre de l'étape";
    [TextArea]
    public string description = "Description de l'étape";

    public Step nextStep;
    public Step nextStepWithError;


    public QuestElement questElement;


    public void Subscribe(QuestElement element)
    {
      questElement = element;
    }

  }
}



