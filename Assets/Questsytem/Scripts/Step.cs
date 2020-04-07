using UnityEngine;


namespace ItsBaptiste.QuestSystem
{
  [CreateAssetMenu(fileName = "Step", menuName = "⚙Step", order = 1)]
  [System.Serializable]
  public class Step : ScriptableObject
  {
    public string title = "Titre de l'étape";
    [TextArea]
    public string description = "Description de l'étape";
  }
}



