using PhoneNumbers;
using System.Text.RegularExpressions;
namespace Model;

internal static class Validation {

    public enum StringValidationType {
        NAME,
        FORENAME,
        SURNAME,
        DESCRIPTION,
        DATE,
        PHONE,
        ADDRESS,
        DATE_FUTURE,
        DATE_PAST,
        QUANTITY,
        PRICE,
        FALSE,
    }

    public static bool Validate(this string str, StringValidationType type) {
        return type switch {
            NAME => str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x) || x == '-') && str.Length < 20,
            FORENAME => str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x)) && str.Length < 20,
            SURNAME => str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x)) && str.Length < 20,
            ADDRESS => str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x)) && str.Length < 50,
            DATE => ValidateDate(str),
            PHONE => ValidatePhone(str),
            PRICE => ValidatePrice(str),
            DESCRIPTION => str.Length < 100 && str.All(x => char.IsAsciiLetterOrDigit(x) || char.IsWhiteSpace(x)),
            QUANTITY => ValidateQuantity(str),
            DATE_FUTURE => ValidateDateFuture(str),
            DATE_PAST => ValidateDatePast(str),
            FALSE => ValidateAlwaysFalse(),
            _ => true
        };
    }

    private static bool ValidatePhone(string str) {
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
        try {
            var phoneNumber = phoneUtil.Parse(str, "GB");
            return phoneUtil.IsValidNumber(phoneNumber);
        } catch (Exception) {
            return false;
        }
    }


    private static bool ValidatePrice(string str) {
        if (str.Length == 0) {
            return false;
        }

        if (str[0] == '$' || str[0] == '£') {
            str = str.Substring(1);
        }

        if (!decimal.TryParse(str, out decimal d) && d > 0 && d * 100 == Math.Floor(d * 100)) {
            return false;
        }

        return Regex.IsMatch(str, @"^-?(\d+|\d{1,3}(?:\,\d{3})+)?(\.\d+)?$");
    }

    private static bool ValidateQuantity(string str) {
        if (str.Length == 0) {
            return false;
        }

        if (str[0] == '$' || str[0] == '£') {
            str = str.Substring(1);
        }

        if (!int.TryParse(str, out int d) && d >= 0 && d <= 500) {
            return false;
        }
        return Regex.IsMatch(str, @"^-?(\d+|\d{1,3}(?:\,\d{3})+)?(\.\d+)?$");
    }

    private static bool ValidateAlwaysFalse() => false;

    private static bool ValidateDate(string str)
        => DateTime.TryParse(str, out DateTime _);

    private static bool ValidateDateFuture(string str) {
        if (!ValidateDate(str))
            return false;

        var dt = Convert.ToDateTime(str);

        if (DateTime.Now <= dt) {
            return false;
        }

        return true;
    }

    private static bool ValidateDatePast(string str) {
        if (!ValidateDate(str)) {
            return false;
        }

        var dt = Convert.ToDateTime(str);

        if (DateTime.Now >= dt) {
            return false;
        }

        return true;
    }
}

