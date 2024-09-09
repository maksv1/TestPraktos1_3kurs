using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class Pass
    {
        public int ValidatePassword(string password)
        {
            int score = 0;

            // Проверка на наличие цифр
            if (Regex.IsMatch(password, @"\d"))
                score++;

            // Проверка на наличие строчных букв
            if (Regex.IsMatch(password, "[a-z]"))
                score++;

            // Проверка на наличие заглавных букв
            if (Regex.IsMatch(password, "[A-Z]"))
                score++;

            // Проверка на наличие специальных символов
            if (Regex.IsMatch(password, @"[^\w\s]"))
                score++;

            // Проверка на длину пароля
            if (password.Length > 10)
                score++;

            return score;
        }
    }
}