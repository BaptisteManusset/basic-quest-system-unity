using UnityEngine;
using TMPro;

namespace ItsBaptiste.QuestSystem
{
  public class QuestViewer : MonoBehaviour
  {



    [SerializeField] TextMeshProUGUI texte;

    private void Start()
    {
      Subscribe();
    }


    public void Subscribe()
    {
      QuestManager.instance.questViewers.Add(this);
    }

    public void UpdateUi()
    {
      texte.text = "";
      //texte.text += $"<size=200%>{QuestManager.GetStep().title}</size>\n";
      //texte.text += $"{QuestManager.GetStep().description}\n";
    }

  }
}
