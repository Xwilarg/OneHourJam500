using TMPro;
using UnityEngine;

namespace OneHourJam.Manager
{
    public class VictoryManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        private void Awake()
        {
            _text.text = $"You reached 500 in {CommonManager.ClickAmount} clicks, {Mathf.FloorToInt(CommonManager.Time / 60f)} minutes and {Mathf.FloorToInt(CommonManager.Time % 60f)} seconds";
        }
    }
}
