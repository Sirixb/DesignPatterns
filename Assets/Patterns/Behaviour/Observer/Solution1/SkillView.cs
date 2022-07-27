using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Behaviour.Observer.Solution1
{
    public class SkillView : MonoBehaviour, Observer
    {
        [SerializeField] private TextMeshProUGUI _chargesText;
        [SerializeField] private Button _skillButton;

        public void Configure(Skill skill)
        {
            _skillButton.onClick.AddListener(skill.Use);
            
            skill.Subscribe(this);
        }
        
        public void Updated(Subject subject)
        {
            if (subject is Skill skill)
            {
                _skillButton.interactable = skill.IsReady;
                _chargesText.SetText(skill.Charges.ToString());
            }
        }
    }
}
