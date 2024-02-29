using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PocBTG.Models
{
    // Model class for Knight
    public class KnightsDto
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public int Idade { get; private set; }
        public int Armas { get; set; }
        public int Ataque { get; private set; }
        public int Experiencia { get; private set; }

        // Method to convert a Knight object to a KnightsDto object
        public static KnightsDto FromKnight(Knight knight)
        {
            var age = CalculateAge(knight.Birthday);
            return new KnightsDto
            {    Id = knight.Id,            
                Nome = knight.Name,
                Idade = age,
                Apelido = knight.Nickname,
                Armas = knight.Weapons.Count,
                Ataque = GetAttck(knight),
                Experiencia = CalculateExperience(age),

            };
        }
        // Method to calculate the age of a knight
        private static int CalculateAge(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age)) age--;
            return age;
        }
        // Method to get the value of a key attribute
        private static int GetKeyAttributeValue(Attributes attributes, string KeyAttribute)
        {
            var propertyInfo = typeof(Attributes).GetProperty(KeyAttribute);
            if (propertyInfo != null)
            {
                return (int)propertyInfo.GetValue(attributes);
            }
            else
            {
                throw new Exception($"Atributo '{KeyAttribute}' não encontrado.");
            }
        }
        // Method to calculate the attack of a knight   
        private static int GetAttck(Knight knight)
        {
            int mod = GetKeyAttributeValue(knight.Attributes, knight.KeyAttribute) switch
            {
                >= 0 and <= 8 => -2,
                >= 9 and <= 10 => -1,
                >= 11 and <= 12 => 0,
                >= 13 and <= 15 => 1,
                >= 16 and <= 18 => 2,
                >= 19 and <= 20 => 3,
                _ => throw new Exception("unknown")
            };

            int weaponMod = knight.Weapons.FirstOrDefault(w => w.Attr == knight.KeyAttribute)?.Mod ?? 0;
            return 10 + mod + weaponMod;
        }
        // Method to calculate the experience of a knight
        private static int CalculateExperience(int age)
        {
            if (age < 7)
            {
                return 0;
            }
            else
            {
                return (int)Math.Floor((age - 7) * Math.Pow(22, 1.45));
            }
        }

    }
    
}
