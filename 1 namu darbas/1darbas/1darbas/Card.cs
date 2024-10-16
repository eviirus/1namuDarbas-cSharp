using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1darbas
{
    public class Card : IComparable<Card>, IEquatable<Card>, IFormattable
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public bool IsHealingCard => Strength < 0;

        public Card(string name, int strength)
        {
            Name = name;
            Strength = strength;
        }

        // Dekonstruktorius
        public void Deconstruct(out string name, out int strength)
        {
            name = this.Name;
            strength = this.Strength;
        }

        // IComparable<Card> implementacija
        public int CompareTo(Card other)
        {
            if (other == null) return 1;
            return this.Strength.CompareTo(other.Strength);
        }

        // IEquatable<Card> implementacija
        public bool Equals(Card other)
        {
            if (other == null) return false; 
            return this.Strength == other.Strength; 
        }

        // is naudojimas
        public override bool Equals(object obj)
        {
            if (obj is Card card)
            {
                return Equals(card); 
            }
            return false; 
        }

        // IFormattable naudojimas
        public string ToString(string format, IFormatProvider formatProvider)
        {
            format = string.IsNullOrEmpty(format) ? "G" : format.ToUpperInvariant();

            return format switch
            {
                "G" => IsHealingCard ? $"{Name} (Heal: {-Strength})" : $"{Name} (Strength: {Strength})",
                "N" => Name,
                "S" => Strength.ToString(),
                _ => throw new FormatException($"Format '{format}' is not supported.")
            };
        }

        // Operatoriaus + perkrovimas
        public static Card operator +(Card c1, Card c2)
        {
            return new Card($"{c1.Name} & {c2.Name}", c1.Strength + c2.Strength);
        }

        public override string ToString()
        {
            return ToString("G", null);
        }
    }
}
