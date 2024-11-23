using System.Linq;
using TMPro;
using UnityEngine;

namespace OneHourJam.Map
{
    public class MathOperator : MonoBehaviour
    {
        private TMP_Text _text;
        private Rigidbody2D _rb;

        private Operator _operator;

        private int _number;

        private void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();

            _number = Random.Range(-10, 11);
            var values = System.Enum.GetValues(typeof(Operator)).Cast<Operator>().ToArray();
            _operator = values[Random.Range(0, values.Length)];


            char opChar = _operator switch
            {
                Operator.Plus => '+',
                Operator.Minus => '-',
                Operator.Mult => 'x',
                Operator.Divide => '/',
                _ => throw new System.NotImplementedException()
            };
            _text.text = $"{opChar}{_number}";

            _rb.linearVelocity = Vector2.right * 5f;
        }

        private void OnMouseUpAsButton()
        {
            
        }

        public enum Operator
        {
            Plus,
            Minus,
            Mult,
            Divide
        }
    }
}
