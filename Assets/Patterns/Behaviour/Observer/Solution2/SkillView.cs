using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Behaviour.Observer.Solution2
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _chargesText;
        [SerializeField] private Button _skillButton;

        public void Configure(ISkill skill)
        {
            _skillButton.onClick.AddListener(skill.Use);

            skill.OnChargesUpdated += charges => _chargesText.SetText(charges.ToString());
            skill.OnIsReadyUpdated += isReady => _skillButton.interactable = isReady;
        }
    }
}
